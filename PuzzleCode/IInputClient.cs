namespace PuzzleCode
{
    public interface IInputClient
    {
        Task<HttpResponseMessage> GetInputData(int day);
    }
}