using FileAsStringUI.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FileAsStringUI
{
    public partial class MainForm : Form
    {
        private int _highestPercentageReached = 0;
        private string _originalFilePath = string.Empty;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private const string _password = "1234";

        public MainForm()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        // Set up the BackgroundWorker object by
        // attaching event handlers.
        private void InitializeBackgroundWorker()
        {
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var megabytesSize = new FileInfo(openFileDialog.FileName).Length / 1000000;
                    if (megabytesSize > 10)
                    {
                        MessageBox.Show("File should be less then 10MB");
                        return;
                    }

                    //_originalFilePath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
                    //labelSelectedFile.Text = openFileDialog.FileName;

                    //var fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                    //var base64String = Convert.ToBase64String(fileBytes);
                    //var encryptedText = EncryptService.EncryptStringAES(base64String, _password);
                    //textBoxSerialize.Text = encryptedText;
                    //Clipboard.SetText(encryptedText);

                    _highestPercentageReached = 0;
                    _backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void buttonDeserialize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDestinationFileName.Text))
            {
                MessageBox.Show("Cannot deserialize to empty destination file name");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxDeserialize.Text))
            {
                MessageBox.Show("Cannot deserialize from empty data");
                return;
            }

            var base64String = EncryptService.DecryptStringAES(textBoxDeserialize.Text, _password);
            var fileBytes = Convert.FromBase64String(base64String);

            string currentPath;
            if (string.IsNullOrEmpty(_originalFilePath))
            {
                currentPath = Directory.GetCurrentDirectory() + @"\";
            }
            else
            {
                currentPath = _originalFilePath;
            }
            
            var filePath = currentPath + textBoxDestinationFileName.Text;
            File.WriteAllBytes(filePath, fileBytes);
        }

        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the
            // RunWorkerCompleted eventhandler.
            //e.Result = ComputeFibonacci((int)e.Argument, worker, e);
            e.Result = ForIteration(worker, e);
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
                //resultLabel.Text = e.Result.ToString();
            }

            // Enable the Start button.
            //startAsyncButton.Enabled = true;
        }

        // This event handler updates the progress bar.
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private int ForIteration(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var cursor = 0;
            const int maxSize = 99999999;
            for (int i = 0; i < maxSize; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }

                int percentComplete = (int)((float)i / (float)maxSize * 100);
                if (percentComplete > _highestPercentageReached)
                {
                    _highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
                cursor = i;
            }

            return cursor;
        }
    }
}