namespace Hub.Services;

public interface IFileService
{
    Task<bool> WriteRealDataToFile(Stream streamToReadFrom, string fileName);

    bool FileExists(string fileName);
}