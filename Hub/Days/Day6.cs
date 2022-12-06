using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public static class Day6
    {
        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            PuzzleOne(sampleData);
            PuzzleTwo(sampleData);

            PuzzleOne(realData);
            PuzzleTwo(realData);
        }

        private static void Solver(string input, int divider)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, divider).Distinct().Count() == divider)
                {
                    Console.WriteLine(i + divider);
                    break;
                }
            }
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            foreach (var input in inputData)
            {
                Solver(input, 4);
            }
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");
            foreach (var input in inputData)
            {
                Solver(input, 14);
            }
        }
    }
}
