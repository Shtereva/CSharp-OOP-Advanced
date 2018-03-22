namespace P05.Logger.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }
        int AddedMessages { get; }
        void Append(IError error);
    }
}
