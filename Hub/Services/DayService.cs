using System.IO.Pipes;
using Hub.Days;
using Hub.Helpers;

namespace Hub.Services
{
    public class DayService : IDayService
    {
        private readonly IInputService _inputService;

        public DayService(IInputService service)
        {
            _inputService = service;
        }

        public async Task Day1()
        {
            if (await SetUpDayData(1))
            {
                await Days.Day1.Run();
            }
            else
            {
                Console.WriteLine("Day 1, could not write data to file");
            }
        }

        public async Task Day2()
        {
            if (await SetUpDayData(2))
            {
                await Days.Day2.Run();
            }
            else
            {
                Console.WriteLine("Day 2, could not write data to file");
            }
        }

        public async Task Day3()
        {
            throw new NotImplementedException();
        }

        public async Task Day4()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SetUpDayData(int day)
        {
            var response = await _inputService.GetInputDataResponse(day);
            var stream = await _inputService.CreateStreamFromHttpResponseMessage(response);
            return await _inputService.WriteRealDataToFile(stream);
        }
    }
}