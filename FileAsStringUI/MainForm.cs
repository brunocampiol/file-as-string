using FileAsStringUI.Models;
using FileAsStringUI.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileAsStringUI
{
    public partial class MainForm : Form
    {
        private BackgroundWorker _serializerBgWorker;
        private BackgroundWorker _deserializerBgWorker;

        private const string _fileSuffix = "restored-";
        private const string _password = "7D03E278-9EF5-4F0F-990C-1D88F4F71CD5";
        private const int _maxFileSizeMb = 55;
        private const int _bufferSize = 4096;

        public MainForm()
        {
            InitializeComponent();
            InitializeBackgroundWorkers();
        }

        private void InitializeBackgroundWorkers()
        {
            _serializerBgWorker = new BackgroundWorker();
            _serializerBgWorker.WorkerReportsProgress = true;
            _serializerBgWorker.DoWork += 
                new DoWorkEventHandler(serializerBgWorker_DoWork);
            _serializerBgWorker.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(serializerBgWorker_RunWorkerCompleted);
            _serializerBgWorker.ProgressChanged += 
                new ProgressChangedEventHandler(serializerBgWorker_ProgressChanged);

            _deserializerBgWorker = new BackgroundWorker();
            _deserializerBgWorker.WorkerReportsProgress = true;
            _deserializerBgWorker.DoWork +=
                new DoWorkEventHandler(deserializerBgWorker_DoWork);
            _deserializerBgWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(deserializerBgWorker_RunWorkerCompleted);
            _deserializerBgWorker.ProgressChanged +=
                new ProgressChangedEventHandler(deserializerBgWorker_ProgressChanged);
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.SafeFileName;
                    var filePath = openFileDialog.FileName.Replace(fileName, "");
                    var fileInformation = new FileInfoDto(filePath, fileName);

                    var megabytesSize = new FileInfo(fileInformation.AbsoluteFileName).Length / 1000000;
                    if (megabytesSize > _maxFileSizeMb)
                    {
                        MessageBox.Show($"File should be less then {_maxFileSizeMb}MB");
                        return;
                    }

                    buttonSelectFile.Enabled = false;
                    labelSelectedFile.Text = $"Reading {fileInformation.AbsoluteFileName}";
                    _serializerBgWorker.RunWorkerAsync(fileInformation);
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

            var currentDirectory = Directory.GetCurrentDirectory() + "\\";
            var fileName = _fileSuffix + EncryptService.DecryptStringAES(inputData[0], _password);
            var fileInformation = new FileInfoDto(currentDirectory, fileName);
            fileInformation.FileBytes = Convert.FromBase64String(inputData[1]);

            buttonDeserialize.Enabled = false;
            labelOutputFile.Text = $"Writing to file {fileInformation.AbsoluteFileName}";
            _deserializerBgWorker.RunWorkerAsync(fileInformation);
        }

        private void serializerBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;
            var fileInformation = (FileInfoDto)e.Argument;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the
            // RunWorkerCompleted eventhandler.
            var encryptedFileName = EncryptService.EncryptStringAES(fileInformation.FileName, _password);
            var fileBytes = ReadAllBytesWithProgress(worker, fileInformation.AbsoluteFileName);
            var base64FileBytes = Convert.ToBase64String(fileBytes);
            fileInformation.SerializationResult = $"{encryptedFileName}:{base64FileBytes}";
            e.Result = fileInformation;
        }

        private void serializerBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                // TODO: update label based on cancelled button
            }
            else
            {
                // Finally, handle the case where the operation
                // succeeded.
                var fileInformation = (FileInfoDto)e.Result;
                labelSelectedFile.Text = $"Complete reading {fileInformation.AbsoluteFileName}";
                textBoxSerialize.Text = fileInformation.SerializationResult;
                Clipboard.SetText(fileInformation.SerializationResult);
            }

            buttonSelectFile.Enabled = true;
        }

        private void serializerBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void deserializerBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;
            var fileInformation = (FileInfoDto)e.Argument;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the
            // RunWorkerCompleted eventhandler.
            WriteBytesWithProgress(worker, fileInformation.FileBytes, fileInformation.AbsoluteFileName);
            e.Result = fileInformation;
        }

        private void deserializerBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                // TODO: update label based on cancelled button
            }
            else
            {
                // Finally, handle the case where the operation
                // succeeded.
                var fileInformation = (FileInfoDto)e.Result;
                labelOutputFile.Text = $"Restored file {fileInformation.AbsoluteFileName}";
            }

            buttonDeserialize.Enabled = true;
        }

        private void deserializerBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private static byte[] ReadAllBytesWithProgress(BackgroundWorker worker, string filePath)
        {
            byte[] buffer = new byte[_bufferSize];
            int bytesRead;
            long totalBytesRead = 0;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                long fileSize = fileStream.Length;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    while ((bytesRead = fileStream.Read(buffer, 0, _bufferSize)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                        var progressPercentage = totalBytesRead / fileSize * 100;
                        worker.ReportProgress(Convert.ToInt32(progressPercentage));
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        private static void WriteBytesWithProgress(BackgroundWorker worker, byte[] bytes, string filePath)
        {
            int totalBytesWritten = 0;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                int bytesRead;
                byte[] buffer = new byte[_bufferSize];

                using (MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    while ((bytesRead = memoryStream.Read(buffer, 0, _bufferSize)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                        totalBytesWritten += bytesRead;
                        double progressPercentage = (double)totalBytesWritten / bytes.Length * 100;
                        worker.ReportProgress(Convert.ToInt32(progressPercentage));
                    }
                }
            }
        }
    }
}