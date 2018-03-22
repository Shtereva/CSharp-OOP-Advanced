using System;
using System.Dynamic;

namespace P05.Logger.Contracts
{
    public interface IError : ILevelable
    {
        DateTime Date { get; set; }

        string Message { get; set; }

    }
}
