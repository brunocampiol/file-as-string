using File2MailUI.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace File2MailUI
{
    public partial class MainForm : Form
    {
        private string _originalFilePath = string.Empty;
        private const string _password = "1234";

        public MainForm()
        {
            InitializeComponent();
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

                    _originalFilePath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
                    labelSelectedFile.Text = openFileDialog.FileName;

                    var fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                    var base64String = Convert.ToBase64String(fileBytes);
                    var encryptedText = EncryptService.EncryptStringAES(base64String, _password);
                    textBoxSerialize.Text = encryptedText;
                    Clipboard.SetText(encryptedText);
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
    }
}