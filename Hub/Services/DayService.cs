using System.Runtime.InteropServices.ComTypes;
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

        public async Task SetUpDayData()
        {
            var day = DateTime.Today.Day;
            for (var i = 1; i <= day; i++)
            {
                var fileName = FileNameHelper.GetRealFileName(i);

                if (!_fileService.FileExists(fileName))
                {
                    var response = await _inputService.GetInputDataResponse(i);
                    var stream = await _inputService.CreateStreamFromHttpResponseMessage(response);
                    await _fileService.WriteRealDataToFile(stream, fileName);
                }
            }
        }

        public async Task Day1()
        {
            var day = new Day1();
            await day.Run();
            await Days.Day1.Run();
        }

        public async Task Day2()
        {
            await Days.Day2.Run(2);
        }

        public async Task Day3()
        {
            await Days.Day3.Run(3);
        }

        public async Task Day4()
        {
            await Days.Day4.Run(4);
        }

        public async Task Day5()
        {
            await Days.Day5.Run(5);
        }

        public async Task Day6()
        {
            await Days.Day6.Run(6);
        }

        public async Task Day7()
        {
            await Days.Day7.Run(7);
        }

        public async Task Day8()
        {
            var day = new Day8();
            await day.Run();
        }

        public async Task Day9()
        {
            var day = new Day9();
            await day.Run();
        }

        public Task Day10()
        {
            throw new NotImplementedException();
        }

        public Task Day11()
        {
            throw new NotImplementedException();
        }

        public Task Day12()
        {
            throw new NotImplementedException();
        }

        public Task Day13()
        {
            throw new NotImplementedException();
        }

        public Task Day14()
        {
            throw new NotImplementedException();
        }

        public Task Day15()
        {
            throw new NotImplementedException();
        }

        public Task Day16()
        {
            throw new NotImplementedException();
        }

        public Task Day17()
        {
            throw new NotImplementedException();
        }

        public Task Day18()
        {
            throw new NotImplementedException();
        }

        public Task Day19()
        {
            throw new NotImplementedException();
        }

        public Task Day20()
        {
            throw new NotImplementedException();
        }

        public Task Day21()
        {
            throw new NotImplementedException();
        }

        public Task Day22()
        {
            throw new NotImplementedException();
        }

        public Task Day23()
        {
            throw new NotImplementedException();
        }

        public Task Day24()
        {
            throw new NotImplementedException();
        }

        public Task Day25()
        {
            throw new NotImplementedException();
        }
    }
}