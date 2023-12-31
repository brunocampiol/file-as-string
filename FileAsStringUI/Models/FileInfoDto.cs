﻿using System;

namespace FileAsStringUI.Models
{
    public class FileInfoDto
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string AbsoluteFileName { get { return FilePath + FileName; } }
        public string SerializationResult { get; set; }
        public byte[] FileBytes { get; set; }
        
        public FileInfoDto(string filePath, string fileName)
        {
            const string _argumentErrorMessage = "Cannot be null, empty or consists only of white-space characters";
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException(_argumentErrorMessage, nameof(filePath));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException(_argumentErrorMessage, nameof(fileName));

            FilePath = filePath;
            FileName = fileName;
        }
    }
}