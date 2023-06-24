﻿using FileAsStringUI.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileAsStringUI
{
    public partial class MainForm : Form
    {
        private string _originalFilePath = string.Empty;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private const string _fileSuffix = "restored-";
        private const string _password = "1234";
        private const int _maxFileSizeMb = 30;

        public MainForm()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        // Set up the BackgroundWorker object by
        // attaching event handlers.
        private void InitializeBackgroundWorker()
        {
            //_backgroundWorker.WorkerReportsProgress = true;
            //_backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            //_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            //_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fullFileName = openFileDialog.FileName;
                    var fileName = openFileDialog.SafeFileName;

                    var megabytesSize = new FileInfo(fullFileName).Length / 1000000;
                    if (megabytesSize > _maxFileSizeMb)
                    {
                        MessageBox.Show($"File should be less then {_maxFileSizeMb}MB");
                        return;
                    }

                    _originalFilePath = fullFileName.Replace(fileName, "");

                    //labelSelectedFile.Text = openFileDialog.FileName;
                    //_backgroundWorker.RunWorkerAsync(openFileDialog.FileName);

                    labelSelectedFile.Text = fullFileName;
                    var encryptedFileName = EncryptService.EncryptStringAES(fileName, _password);
                    var fileBytes = File.ReadAllBytes(fullFileName);
                    var base64FileBytes = Convert.ToBase64String(fileBytes);

                    var outputString = $"{encryptedFileName}:{base64FileBytes}";

                    textBoxSerialize.Text = outputString;
                    Clipboard.SetText(outputString);
                }
            }
        }

        private void buttonDeserialize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDeserialize.Text))
            {
                MessageBox.Show("Cannot deserialize from empty data");
                return;
            }
            if (!textBoxDeserialize.Text.Contains(":"))
            {
                MessageBox.Show("Invalid data format");
                return;
            }

            var inputData = textBoxDeserialize.Text.Split(':');
            if (inputData.Count() != 2)
            {
                MessageBox.Show("Invalid data format");
                return;
            }

            var fileName = _fileSuffix + EncryptService.DecryptStringAES(inputData[0], _password);
            var fileBytes = Convert.FromBase64String(inputData[1]);
            string currentPath;
            if (string.IsNullOrEmpty(_originalFilePath))
            {
                currentPath = Directory.GetCurrentDirectory() + @"\";
            }
            else
            {
                currentPath = _originalFilePath;
            }
            
            var fullFileName = currentPath + fileName;
            labelOutputFile.Text = fullFileName;
            File.WriteAllBytes(fullFileName, fileBytes);
        }

        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;
            var filePath = (string)e.Argument;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the
            // RunWorkerCompleted eventhandler.
            var fileBytes = ReadAllBytesWithProgress(worker, filePath);
            var base64String = Convert.ToBase64String(fileBytes);
            var encryptedText = EncryptService.EncryptStringAES(base64String, _password);
            e.Result = encryptedText;
        }

        // This event handler deals with the results of the
        // background operation.
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled
                // the operation.
                // Note that due to a race condition in
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                //resultLabel.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation
                // succeeded.
                var result = e.Result.ToString();
                textBoxSerialize.Text = result;
                Clipboard.SetText(result);
            }

            // Enable the Start button.
            //startAsyncButton.Enabled = true;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private static byte[] ReadAllBytesWithProgress(BackgroundWorker worker, string filePath)
        {
            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;
            long totalBytesRead = 0;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                long fileSize = fileStream.Length;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                        var progressPercentage = totalBytesRead / fileSize * 100;
                        // Call the progress callback with the current progress
                        worker.ReportProgress(Convert.ToInt32(progressPercentage));
                    }

                    return memoryStream.ToArray();
                }
            }
        }
    }
}