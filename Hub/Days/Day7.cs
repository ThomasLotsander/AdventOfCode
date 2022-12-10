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
        private static Dictionary<int, List<Dir>> _hierarchyManager = new();
        static List<Dir> _structure = new();
        static Dir _currentDir = null;
        static Dir _parrent = null;
        static int _directoryDepthIndex = 0;
        private static int _finalResult = 0;

        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            PuzzleOne(sampleData);
            //PuzzleTwo(sampleData);

            //PuzzleOne(realData);
            //PuzzleTwo(realData);
        }

        private static void FuckingHell(List<Dir> dirs)
        {
            if (dirs.Any(x => x.Directories.Any()))
            {
                foreach (var dir in dirs)
                {
                    FuckingHell(dir.Directories);
                }
            }

            foreach (var dir in dirs)
            {
                int totalSum = 0;
                totalSum = CalculateFileSizes(dir, totalSum, dir.Name);
                if (totalSum <= 100000)
                {
                    Console.WriteLine("Dir: " + dir.Name + " size " + totalSum);
                    _finalResult += totalSum;
                }
            }
                    
        }


        private static int CalculateFileSizes(Dir dir, int totalSize, string dirName)
        {
            if (dir.Directories.Any())
            {
                foreach (var d in dir.Directories)
                {
                    totalSize = CalculateFileSizes(d, totalSize, d.Name);
                }
            }

            if (!dir.Files.Any())
            {
                return totalSize;
            }

            var dirSize = dir.Files.Select(x => x.FileSize).Sum();
            totalSize += dirSize;
            return totalSize;
        }

        private static void SetCurrentDirectory(string directoryName)
        {
            var current = _hierarchyManager
                .Where(x => x.Key == _directoryDepthIndex)
                .Select(x => x.Value.FirstOrDefault(y => y.Name == directoryName)).FirstOrDefault();
            _currentDir = current;
        }

        private static void PuzzleOne(string[] inputData)
        {
            _currentDir = new Dir
            {
                Name = "/",
                Index = 0
            };

            _structure.Add(_currentDir);
            _parrent = _currentDir;

            Console.WriteLine("--- Puzzle 1 ---");

            // Skip first line
            for (int i = 1; i < inputData.Length; i++)
            {
                var row = inputData[i];
                var isCommand = row.StartsWith("$");

                if (isCommand)
                {
                    if (row.StartsWith("$ cd"))
                    {
                        var directoryName = row.Split(' ').Last();
                        SetCurrentDirectory(directoryName);
                        _parrent = _currentDir;
                        if (directoryName == "..")
                        {
                            _directoryDepthIndex--;

                        }
                        else
                        {
                            _directoryDepthIndex++;
                        }


                        //foreach (var dir in _structure)
                        //{
                        //    DirExists(dir, directoryName);
                        //}
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
                            var newDir = new Dir
                            {
                                Name = dirName,
                                Index = _directoryDepthIndex,
                                Parrent = _parrent
                            };
                            _currentDir.Directories.Add(newDir);

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

                        var data = new List<Dir>();
                        if (_hierarchyManager.Any(x => x.Key == _directoryDepthIndex))
                        {
                            //data = _hierarchyManager[_directoryDepthIndex];
                            //data.AddRange(_currentDir.Directories);

                        }
                        else
                        {
                            _hierarchyManager.Add(_directoryDepthIndex, _currentDir.Directories);

                        }


                    }
                }
            }


            FuckingHell(_structure);
            Console.WriteLine("Result: " + _finalResult);

        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");
        }
    }
}
