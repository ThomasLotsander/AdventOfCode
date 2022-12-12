using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public abstract class DefaultDaySetup
    {
        protected string[]? SampleData { get; private set; }
        protected string[]? RealData { get; private set; }
        public abstract Task Run();
        public abstract Task PuzzleOne(string[] inputData);

        public abstract Task PuzzleTwo(string[] inputData);

        protected async Task Setup(int day)
        {
            SampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            RealData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));
        }
        //public abstract async Task Run(int day)
        //{
        //    Console.WriteLine($"\n--- Day {day} --- \n");

        //    var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
        //    var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

        //    PuzzleOne(sampleData);
        //    PuzzleTwo(sampleData);

        //    PuzzleOne(realData);
        //    PuzzleTwo(realData);
        //}

        //private static void PuzzleOne(string[] inputData)
        //{
        //    Console.WriteLine("--- Puzzle 1 ---");
           
        //}

        //private static void PuzzleTwo(string[] inputData)
        //{
        //    Console.WriteLine("--- Puzzle 2 ---");

        //}
    }
}
