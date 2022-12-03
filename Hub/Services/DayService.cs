using System.IO.Pipes;
using Hub.Days;
using Hub.Helpers;

namespace Hub.Services
{
    public class DayService : IDayService
    {
        private readonly IInputService _inputService;
        private readonly IFileService _fileService;

        public DayService(IInputService service, IFileService fileService)
        {
            _inputService = service;
            _fileService = fileService;
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
            if (await SetUpDayData(3))
            {
                await Days.Day3.Run();
            }
            else
            {
                Console.WriteLine("Day 3, could not write data to file");
            }
        }

        public async Task Day4()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SetUpDayData(int day)
        {
            var fileName = FileNameHelper.GetRealFileName(day);
            if (!_fileService.FileExists(fileName))
            {
                var response = await _inputService.GetInputDataResponse(day);
                var stream = await _inputService.CreateStreamFromHttpResponseMessage(response);
                return await _fileService.WriteRealDataToFile(stream, fileName);
            }

            return true;
        }
    }
}