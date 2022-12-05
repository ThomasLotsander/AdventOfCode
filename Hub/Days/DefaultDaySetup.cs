using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    internal class DefaultDaySetup
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

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
           
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

        }
    }
}
