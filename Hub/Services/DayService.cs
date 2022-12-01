using Hub.Days;
using Hub.Interfaces;

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
            var inputData = await _inputService.GetInputData(1);
            if (inputData != null)
            {
                DayOne.Run(inputData);
            }
        }

        public async Task Day2()
        {
            var inputData = await _inputService.GetInputData(2);

            throw new NotImplementedException();
        }

        public async Task Day3()
        {
            throw new NotImplementedException();
        }

        public async Task Day4()
        {
            throw new NotImplementedException();
        }
    }
}