using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Helpers
{
    public static class FileNameHelper
    {
        //public const string Day1File = "Day1.txt";
        //public const string Day2File = "Day2.txt";
        //public const string Day3File = "Day3.txt";

        //public const string Day1RealData = "Day1RealData.txt";
        //public const string Day2RealData = "Day2RealData.txt";
        //public const string Day3RealData = "Day3RealData.txt";

        public static string GetSampleDataFileName(int day)
        {
            return $"Day{day}.txt";
        }

        public static string GetRealFileName(int day)
        {
            return $"Day{day}RealData.txt";
        }
    }
}
