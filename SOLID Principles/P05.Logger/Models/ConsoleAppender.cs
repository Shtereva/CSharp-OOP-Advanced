using System;
using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        public ILayout Layout { get; }
        public int AddedMessages { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public ConsoleAppender(ILayout layout, ReportLevel level)
        {
            this.Layout = layout;
            this.ReportLevel = level;
        }

        public void Append(IError error)
        {
            Console.WriteLine(string.Format(this.Layout.MessageFormat, error.Date, error.ReportLevel, error.Message));
            this.AddedMessages++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.AddedMessages}";
        }
    }
}
