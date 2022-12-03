using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public class Day3
    {
        public static async Task Run()
        {
            Console.WriteLine("\n--- Day 3 --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(3));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(3));
            //PuzzleOne(sampleData);
            PuzzleOne(realData);

            //PuzzleTwo(sampleData);
            //PuzzleTwo(realData);
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            foreach (var input in inputData)
            {
                var half = input.Length / 2;
                var first = input.Substring(0, (int)(half));
                var last = input.Substring((int)(half), (int)(half));
                Console.WriteLine(first + " " + last);
            }

        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

           
        }
    }
}
