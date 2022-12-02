namespace Hub.Services
{
    public interface IInputService
    {
        Task<HttpResponseMessage> GetInputDataResponse(int day);
        Task<bool> WriteRealDataToFile(Stream streamToReadFrom);
        Task<Stream> CreateStreamFromHttpResponseMessage(HttpResponseMessage response);
    }
}