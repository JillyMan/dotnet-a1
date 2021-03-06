﻿namespace FileSystemVisitor.Models
{
    public class FileNode : FileSystemNode, IChildNode
    {
        public string Extension { get; }

        public FolderNode Parent { get; }

        public FileNode(FolderNode parent, string filePath, string fileName, string extension, long size)
        {
            Size = size;
            Path = filePath;
            Name = fileName;
            Extension = extension;
            Parent = parent;
        }
    }
}