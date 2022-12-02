using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Services
{
    public class FileService : IFileService
    {
        public async Task<bool> WriteRealDataToFile(Stream streamToReadFrom, string fileName)
        {
            var fileToWriteTo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            await using Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create);
            await streamToReadFrom.CopyToAsync(streamToWriteTo);

            return FileExists(fileToWriteTo);
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName));
        }
    }
}
