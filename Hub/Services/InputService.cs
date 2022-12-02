using System.Reflection;
using Hub.Helpers;
using PuzzleCode;

namespace Hub.Services
{
    public class InputService : IInputService
    {
        private readonly IInputClient _inputClient;

        public InputService(IInputClient inputClient)
        {
            _inputClient = inputClient;
        }

        public async Task<HttpResponseMessage> GetInputDataResponse(int day)
        {
            if (day is < 0 or > 26)
                return null;

            var response = await _inputClient.GetInputData(day);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<Stream> CreateStreamFromHttpResponseMessage(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStreamAsync();
        }
    }
}