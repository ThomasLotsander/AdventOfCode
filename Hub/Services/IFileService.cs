namespace Hub.Services;

public interface IFileService
{
    Task WriteRealDataToFile(Stream streamToReadFrom, string fileName);

    bool FileExists(string fileName);
}