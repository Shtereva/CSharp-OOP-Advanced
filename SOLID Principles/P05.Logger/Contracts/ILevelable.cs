using System;
using System.Collections.Generic;
using System.Text;

namespace P05.Logger.Contracts
{
    public interface ILevelable
    {
        ReportLevel ReportLevel { get; }
    }
}
