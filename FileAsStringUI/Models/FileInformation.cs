using System;

namespace FileAsStringUI.Models
{
    public class FileInformation
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string AbsoluteFileName { get { return FilePath + FileName; } }

        public FileInformation(string filePath, string fileName) 
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            FilePath = filePath;
            FileName = fileName;
        }
    }
}