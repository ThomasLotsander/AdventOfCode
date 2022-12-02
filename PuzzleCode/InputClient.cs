using System.Reflection;

namespace PuzzleCode
{
    public class InputClient : IInputClient
    {
        private readonly HttpClient _client;

        public InputClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetInputData(int day)
        {
            return await _client.GetAsync($"{day}/input");
        }
    }
}