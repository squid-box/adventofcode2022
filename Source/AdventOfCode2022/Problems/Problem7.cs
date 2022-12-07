namespace AdventOfCode2022.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2022/day/7">Day 7</a>.
/// </summary>
public class Problem7 : ProblemBase
{
    public Problem7(InputDownloader inputDownloader) : base(7, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return SolvePartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return SolvePartTwo(Input);
    }

    internal static int SolvePartOne(ICollection<string> input)
    {
        var fs = new FileSystem(input.WithNoEmptyLines());
        return fs.FindSumSizeOfDirectoriesSmallerThan(100000);
    }

    internal static int SolvePartTwo(ICollection<string> input)
    {
        var fs = new FileSystem(input.WithNoEmptyLines());
        return fs.FindDirectorySizeToDeleteToGetEnoughSpaceForUpdate(30000000);
    }

    /// <summary>
    /// Represents a simple file system.
    /// </summary>
    private class FileSystem
    {
        private readonly Directory _root = new("/", null);

        /// <summary>
        /// Creates a new <see cref="FileSystem"/>.
        /// </summary>
        /// <param name="input">Input describing the file system.</param>
        public FileSystem(IEnumerable<string> input)
        {
            CurrentWorkingDirectory = _root;

            foreach (var line in input)
            {
                if (line.StartsWith("$ cd"))
                {
                    ChangeDirectory(line.Split(' ')[2]);
                }
                else if (line.StartsWith("dir "))
                {
                    CurrentWorkingDirectory.Contents.Add(new Directory(line.Split(' ')[1], CurrentWorkingDirectory));
                }
                else if (char.IsDigit(line[0]))
                {
                    var split = line.Split(' ');
                    CurrentWorkingDirectory.Contents.Add(new File(split[1], Convert.ToInt32(split[0])));
                }
            }
        }

        public int FindSumSizeOfDirectoriesSmallerThan(int maxSize)
        {
            var allDirSize = 0;

            if (_root.CalculateTotalSize() < maxSize)
            {
                allDirSize += _root.CalculateTotalSize();
            }

            allDirSize += _root.GetAllSubDirectories()
                .Where(directory => directory.CalculateTotalSize() <= maxSize)
                .Sum(directory => directory.CalculateTotalSize());

            return allDirSize;
        }

        public int FindDirectorySizeToDeleteToGetEnoughSpaceForUpdate(int requiredSpace)
        {
            var needToFreeAtLeast = requiredSpace - (70000000 - _root.CalculateTotalSize());

            return _root.GetAllSubDirectories()
                .Where(x => x.CalculateTotalSize() >= needToFreeAtLeast)
                .OrderBy(dir => dir.CalculateTotalSize())
                .First().CalculateTotalSize();
        }

        private Directory CurrentWorkingDirectory { get; set; }

        private void ChangeDirectory(string directory)
        {
            switch (directory)
            {
                case "..":
                    CurrentWorkingDirectory = CurrentWorkingDirectory.Parent;
                    return;
                case "/":
                    CurrentWorkingDirectory = _root;
                    return;
                default:
                    CurrentWorkingDirectory = CurrentWorkingDirectory.Contents.First(obj => obj.Name.Equals(directory)) as Directory;
                    return;
            }
        }

        /// <summary>
        /// Base class for any object in a <see cref="FileSystem"/>.
        /// </summary>
        private abstract class FileSystemObject
        {
            /// <summary>
            /// Name of the <see cref="FileSystemObject"/>.
            /// </summary>
            public string Name { get; protected init; }
        }

        /// <summary>
        /// Represents a <see cref="File"/> in the <see cref="FileSystem"/>.
        /// </summary>
        private class File : FileSystemObject
        {
            /// <summary>
            /// Creates a new <see cref="File"/>.
            /// </summary>
            /// <param name="name">Name of the file.</param>
            /// <param name="size">Size of the file.</param>
            public File(string name, int size)
            {
                Name = name;
                Size = size;
            }

            /// <summary>
            /// Gets the size of this <see cref="File"/>, in bytes.
            /// </summary>
            public int Size { get; }
        }

        /// <summary>
        /// Represents a <see cref="Directory"/> in the <see cref="FileSystem"/>.
        /// </summary>
        private class Directory : FileSystemObject
        {
            /// <summary>
            /// Creates a new <see cref="Directory"/>.
            /// </summary>
            /// <param name="name">Name of the directory.</param>
            /// <param name="parent">Parent of this directory.</param>
            public Directory(string name, Directory parent)
            {
                Name = name;
                Parent = parent;

                Contents = new List<FileSystemObject>();
            }

            /// <summary>
            /// Gets the parent <see cref="Directory"/>.
            /// </summary>
            public Directory Parent { get; }

            /// <summary>
            /// Gets all the contents of this <see cref="Directory"/>.
            /// </summary>
            public List<FileSystemObject> Contents { get; }

            /// <summary>
            /// Gets the total size of this directory, its contents, and any subdirectories.
            /// </summary>
            /// <returns>The total size of this directory and *all* its contents.</returns>
            public int CalculateTotalSize()
            {
                var size = 0; 

                foreach (var obj in Contents)
                {
                    if (obj is Directory dir)
                    {
                        size += dir.CalculateTotalSize();
                    }
                    else if (obj is File file)
                    {
                        size += file.Size;
                    }
                }

                return size;
            }

            /// <summary>
            /// Gets all subdirectories of this <see cref="Directory"/>, recursively.
            /// </summary>
            /// <returns>A lists of *all* subdirectories.</returns>
            public IEnumerable<Directory> GetAllSubDirectories()
            {
                var result = new HashSet<Directory>();

                foreach (var obj in Contents)
                {
                    if (obj is not Directory dir)
                    {
                        continue;
                    }

                    result.Add(dir);
                    result.AddRange(dir.GetAllSubDirectories());
                }

                return result;
            }
        }
    }
}