using System.Reflection;

namespace Hub.Services
{
    public class FileService : IFileService
    {
        public async Task WriteRealDataToFile(Stream streamToReadFrom, string fileName)
        {
            try
            {
                var fileToWriteTo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
                await using Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create);
                await streamToReadFrom.CopyToAsync(streamToWriteTo);

                if (FileExists(fileToWriteTo))
                {
                    Console.WriteLine($"File {fileName} created");
                }
                else
                {
                    Console.WriteLine("Failed to create file: " + fileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName));
        }
    }
}