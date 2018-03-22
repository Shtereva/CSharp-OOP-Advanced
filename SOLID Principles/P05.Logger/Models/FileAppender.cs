using System;
using System.IO;
using System.Linq;
using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class FileAppender : IAppender
    {
        public ILayout Layout { get; }
        public int AddedMessages { get; set; }
        public ReportLevel ReportLevel { get; set; }
        public int Size { get; set; }

        public FileAppender(ILayout layout, ReportLevel level)
        {
            this.Layout = layout;
            this.ReportLevel = level;
        }

        public void Append(IError error)
        {
            string line = string.Format(this.Layout.MessageFormat, error.Date, error.ReportLevel, error.Message);

            this.AddedMessages++;
            this.Size += line
                .Where(char.IsLetter)
                .Select(c => (int)c)
                .Sum();
        }

        public override string ToString()
        {
            return  $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.AddedMessages}, File size: {this.Size}";
        }
    }
}
