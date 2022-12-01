using Hub.Interfaces;
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

        public async Task<string?> GetInputData(int day)
        {
            if (day is < 0 or > 26)
                return null;

            var response = await _inputClient.GetInputData(day);
            return await response.Content.ReadAsStringAsync();
        }
    }
}