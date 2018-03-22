using System;
using P05.Logger.Contracts;
using P05.Logger.Models;

namespace P05.Logger.Factories
{
    public class AppenderFactory
    {
        public IAppender Create(string appenderType, ILayout layout, ReportLevel level)
        {
            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, level);
                case "FileAppender":
                    return new FileAppender(layout, level);
            }

            throw new InvalidOperationException("Invalid Appender");
        }
    }
}
