﻿using FileSystemVisitor.Models;
using System;
using System.Collections.Generic;

namespace FileSystemVisitor.Core
{
	public abstract class BaseApplication
	{
		protected FileSystemVisitor FileVisitor { get; private set;}
		protected FileSystemNodeFilter FileFilter { get; private set; }

		protected FolderNode FolderNode => FileVisitor.RootNode;

		protected BaseApplication()
		{
			FileVisitor = new FileSystemVisitor();
			FileFilter = new FileSystemNodeFilter();

			FileVisitor.StartHandler += FileVisitorOnStartHandler;
			FileVisitor.EndHandler += FileVisitorOnEndHandler;

			FileVisitor.FileFound += FileVisitorOnFileFound;
			FileVisitor.FolderFound += FileVisitorOnFolderFound;

			FileFilter.FilteredFileFound += FileVisitorOnFilteredFileFound;
			FileFilter.FilteredFolderFound += FileVisitorOnFilteredFolderFound;
		}

        protected void BuildTree(string root, Predicate<FileSystemNode> predicate)
        {
			FileVisitor.Start(root, predicate);
        }

		protected IEnumerable<FileSystemNode> GetItems(Predicate<FileSystemNode> pr) => FileFilter.FilterBy(FolderNode, pr);

		protected virtual void FileVisitorOnFilteredFolderFound(object sender, Infrastructure.FolderNodeFindEvent e)
		{
		}

		protected virtual void FileVisitorOnFilteredFileFound(object sender, Infrastructure.FileNodeFindEvent e)
		{
		}

		protected virtual void FileVisitorOnFolderFound(object sender, Infrastructure.FolderNodeFindEvent e)
		{
		}

		protected virtual void FileVisitorOnFileFound(object sender, Infrastructure.FileNodeFindEvent e)
		{
		}

		protected virtual void FileVisitorOnStartHandler(object sender, EventArgs e)
		{
		}

		protected virtual void FileVisitorOnEndHandler(object sender, EventArgs e)
		{
		}
	}
}
