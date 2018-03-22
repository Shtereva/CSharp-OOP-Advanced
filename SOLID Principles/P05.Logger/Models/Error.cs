using System;
using P05.Logger.Contracts;

namespace P05.Logger.Models
{
    public class Error : IError
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public Error(DateTime date, ReportLevel reportLevel, string message)
        {
            this.Date = date;
            this.Message = message;
            this.ReportLevel = reportLevel;
        }
    }
}
