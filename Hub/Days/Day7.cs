using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public static class Day7
    {
        static List<Directory> _directories;
        static Directory _currentDir;
        private static int _finalResult;
        private static Dictionary<int, string> _sizeManager;

        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            PuzzleOne(sampleData);
            PuzzleOne(realData);
            PuzzleTwo(sampleData);
            PuzzleTwo(realData);
        }

        private static void FuckingHell(List<Directory> directories)
        {
            if (directories.Any(x => x.Children.Any()))
            {
                foreach (var child in directories)
                {
                    FuckingHell(child.Children);
                }
            }

            foreach (var directory in directories)
            {
                var totalSum = 0;
                totalSum = CalculateFileSizes(directory, totalSum);
                if (totalSum <= 100000)
                {
                    Console.WriteLine("Dir: " + directory.Name + " size " + totalSum);
                    _finalResult += totalSum;
                }
            }
        }

        private static void FuckingHell2(List<Directory> directories, int freeSpaceNeeded)
        {
            if (directories.Any(x => x.Children.Any()))
            {
                foreach (var child in directories)
                {
                    FuckingHell2(child.Children, freeSpaceNeeded);
                }
            }

            foreach (var directory in directories)
            {
                var totalSum = 0;
                totalSum = CalculateFileSizes(directory, totalSum);
                if (totalSum >= freeSpaceNeeded)
                {
                    Console.WriteLine("Dir: " + directory.Name + " size " + totalSum);
                    _finalResult += totalSum;
                    _sizeManager.Add(totalSum, directory.Name);
                }
            }
        }

        private static int CalculateFileSizes(Directory directory, int totalSize)
        {
            if (directory.Children.Any())
            {
                foreach (var d in directory.Children)
                {
                    totalSize = CalculateFileSizes(d, totalSize);
                }
            }

            if (!directory.Files.Any())
            {
                return totalSize;
            }

            var dirSize = directory.Files.Select(x => x.FileSize).Sum();
            totalSize += dirSize;
            return totalSize;
        }

        private static void SetCurrentDirectory(string directoryName)
        {
            var current = _currentDir.Children.FirstOrDefault(x => x.Name == directoryName);
            _currentDir = current;
        }

        private static void CreateDirectoryFileSystem(string[] inputData)
        {
            for (int i = 1; i < inputData.Length; i++)
            {
                var row = inputData[i];
                var isCommand = row.StartsWith("$");

                if (isCommand)
                {
                    if (row.StartsWith("$ cd"))
                    {
                        var directoryName = row.Split(' ').Last();

                        if (directoryName == "..")
                        {
                            _currentDir = _currentDir.Parent;
                        }
                        else
                        {
                            SetCurrentDirectory(directoryName);
                        }
                    }

                    else if (row.Equals("$ ls"))
                    {
                        var items = inputData
                            .Skip(i + 1)
                            .TakeWhile(x => !x.StartsWith("$")).ToList();

                        var dirs = items.Where(x => x.StartsWith("dir")).ToList();
                        var files = items.Where(x => int.TryParse(x.Split(' ').First(), out _)).ToList();

                        foreach (var dir in dirs)
                        {
                            var dirName = dir.Split(' ').Last();
                            var newDir = new Directory
                            {
                                Name = dirName,
                                Parent = _currentDir
                            };

                            _currentDir.Children.Add(newDir);
                        }

                        foreach (var file in files)
                        {
                            var fileSize = int.Parse(file.Split(' ').First());
                            var fileName = file.Split(' ').Last();
                            var newFile = new DirectoryFile()
                            {
                                FileName = fileName,
                                FileSize = fileSize,
                            };

                            _currentDir.Files.Add(newFile);
                        }
                    }
                }
            }
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            _finalResult = 0;
            _directories = new List<Directory>();
            _currentDir = new Directory
            {
                Name = "/",
                Index = 0
            };

            _directories.Add(_currentDir);


            // Skip first line
            CreateDirectoryFileSystem(inputData);


            FuckingHell(_directories);
            Console.WriteLine("Result: " + _finalResult);
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");
            _sizeManager = new Dictionary<int, string>();


            _directories = new List<Directory>();
            _currentDir = new Directory
            {
                Name = "/",
                Index = 0
            };

            _directories.Add(_currentDir);
            // Skip first line
            CreateDirectoryFileSystem(inputData);

            var test = CalculateFileSizes(_directories.First(), 0);
            var neededSpace = GetHowMuchDiskSpaceNeededToFreeUp(test);
            Console.WriteLine(neededSpace);

            FuckingHell2(_directories, neededSpace);
            var result = _sizeManager.Min(x => x.Key);
        }

        private static int GetHowMuchDiskSpaceNeededToFreeUp(int usedSpace)
        {
            var totalDiskSpaceAvailable = 70000000;
            var neededAvailableSpace = 30000000;
            
            //usedSpace = 48381165;

            var unUsedSpace = totalDiskSpaceAvailable - usedSpace;
            var neededSpace = neededAvailableSpace - unUsedSpace;

            return neededSpace;
        }
    }
}
