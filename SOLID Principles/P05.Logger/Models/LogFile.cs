using System;
using System.Collections.Generic;
using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class LogFile : IFile
    {
        public string Path { get; set; }

        public void Write(ICollection<IAppender> appenders)
        {
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
