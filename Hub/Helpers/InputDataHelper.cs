using System.Reflection;

namespace Hub.Helpers
{
    public static class InputDataHelper
    {
        public const string Day1File = "Day1.txt";
        public const string Day2File = "Day2.txt";
        public const string RealFile = "RealFile.txt";
        private const string TestFiles = "testfiles";

        public static async Task<string[]> GetTestData(string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{TestFiles}/{fileName}");
            return await File.ReadAllLinesAsync(path);
        }

        public static async Task<string[]> GetRealData()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), RealFile);
            return await File.ReadAllLinesAsync(path);
        }
    }

    
}