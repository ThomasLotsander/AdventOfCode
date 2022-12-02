using System.Reflection;

namespace Hub.Helpers
{
    public static class InputDataHelper
    {
        public const string Day1File = "Day1.txt";
        public const string Day2File = "Day2.txt";

        public const string Day1RealData = "Day1RealData.txt";
        public const string Day2RealData = "Day2RealData.txt";
        
        //public const string RealFile = "RealFile.txt";
        private const string TestFilesPath = "testfiles";

        public static async Task<string[]> GetTestData(string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{TestFilesPath}/{fileName}");
            return await File.ReadAllLinesAsync(path);
        }

        public static async Task<string[]> GetRealData(string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            return await File.ReadAllLinesAsync(path);
        }
    }

    
}