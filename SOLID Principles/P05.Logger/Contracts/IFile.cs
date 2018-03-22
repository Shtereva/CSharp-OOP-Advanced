using System.Collections.Generic;

namespace P05.Logger.Contracts
{
    public interface IFile
    {
        string Path { get; }

        void Write(ICollection<IAppender> appenders);
    }
}
