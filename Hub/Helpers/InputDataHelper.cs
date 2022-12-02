using System.Reflection;

namespace Hub.Helpers
{
    public static class InputDataHelper
    {
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