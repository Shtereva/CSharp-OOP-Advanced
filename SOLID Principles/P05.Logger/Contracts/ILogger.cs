namespace P05.Logger.Contracts
{
    public interface ILogger
    {
        void Log(IError error);
    }
}
