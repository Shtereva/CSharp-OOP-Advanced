using System.Collections.Generic;
using P05.Logger.Contracts;

namespace P05.Logger
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (appender.ReportLevel <= error.ReportLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
