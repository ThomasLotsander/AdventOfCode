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
            var response = await _client.GetAsync($"{day}/input");
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}