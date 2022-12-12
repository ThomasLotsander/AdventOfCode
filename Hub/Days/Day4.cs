using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public static class Day4
    {
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

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            var counter = 0;
            foreach (var tasks in inputData.Select(x => x.Split(',')).ToList())
            {
                var firstStart = int.Parse(tasks[0].Split('-').First());
                var firstEnd = int.Parse(tasks[0].Split('-').Last());
                
                var lastStart = int.Parse(tasks[1].Split('-').First());
                var lastEnd = int.Parse(tasks[1].Split('-').Last());

                if (firstStart <= lastStart && firstEnd >= lastEnd)
                {
                    counter++;
                }

                else if (lastStart <= firstStart && lastEnd >= firstEnd)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

            var counter = 0;
            foreach (var tasks in inputData.Select(x => x.Split(',')).ToList())
            {
                var firstStart = int.Parse(tasks[0].Split('-').First());
                var firstEnd = int.Parse(tasks[0].Split('-').Last());
               
                var lastStart = int.Parse(tasks[1].Split('-').First());
                var lastEnd = int.Parse(tasks[1].Split('-').Last());

               
                var firstRow = Enumerable.Range(firstStart, firstEnd - firstStart + 1).ToList();
                var lastRow = Enumerable.Range(lastStart, lastEnd - lastStart + 1).ToList();

                if (firstRow.Intersect(lastRow).Any() || lastRow.Intersect(firstRow).Any())
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
