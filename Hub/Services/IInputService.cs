namespace Hub.Services
{
    public interface IInputService
    {
        Task<HttpResponseMessage> GetInputDataResponse(int day);

        Task<Stream> CreateStreamFromHttpResponseMessage(HttpResponseMessage response);
    }
}