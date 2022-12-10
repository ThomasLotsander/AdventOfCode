using Hub.Days;
using Hub.Helpers;

namespace Hub.Services
{
    public class DayService : IDayService
    {
        private readonly IInputService _inputService;
        private readonly IFileService _fileService;
        private IDayService _dayServiceImplementation;

        public DayService(IInputService service, IFileService fileService)
        {
            _inputService = service;
            _fileService = fileService;
        }

        public async Task Day1()
        {
            await SetUpDayData(1);
            await Days.Day4.Run(1);
        }

        public async Task Day2()
        {
            await SetUpDayData(2);
            await Days.Day4.Run(2);
        }

        public async Task Day3()
        {
            await SetUpDayData(3);
            await Days.Day4.Run(3);
        }

        public async Task Day4()
        {
            await SetUpDayData(4);
            await Days.Day4.Run(4);
        }

        public async Task Day5()
        {
            await SetUpDayData(5);
            await Days.Day5.Run(5);
        }

        public async Task Day6()
        {
            await SetUpDayData(6);
            await Days.Day6.Run(6);
        }

        public async Task Day7()
        {
            await SetUpDayData(7);
            await Days.Day7.Run(7);
        }

        private async Task SetUpDayData(int day)
        {
            var fileName = FileNameHelper.GetRealFileName(day);
            if (!_fileService.FileExists(fileName))
            {
                var response = await _inputService.GetInputDataResponse(day);
                var stream = await _inputService.CreateStreamFromHttpResponseMessage(response);
                await _fileService.WriteRealDataToFile(stream, fileName);
            }
        }
    }
}