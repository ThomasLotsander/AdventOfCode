namespace Hub.Interfaces
{
    public interface IInputService
    {
        Task<string?> GetInputData(int day);
    }
}