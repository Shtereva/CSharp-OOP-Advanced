namespace FestivalManager.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
