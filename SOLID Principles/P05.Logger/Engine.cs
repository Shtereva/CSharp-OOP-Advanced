using System;
using System.Collections.Generic;
using System.Globalization;
using P05.Logger.Contracts;
using P05.Logger.Factories;
using P05.Logger.Models;

namespace P05.Logger
{
    public class Engine
    {
        public void Run()
        {
            int numOfAppenders = int.Parse(Console.ReadLine());
            string appenderType = string.Empty;
            string layoutType = string.Empty;
            ReportLevel reportLevel = 0;

            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory();

            var appenders = new List<IAppender>();

            for (int i = 0; i < numOfAppenders; i++)
            {
                var lines = Console.ReadLine().Split();

                appenderType = lines[0];
                layoutType = lines[1];

                if (lines.Length > 2)
                {
                    reportLevel = Enum.Parse<ReportLevel>(lines[2]);
                }

                var layout = layoutFactory.Create(layoutType);
                var appender = appenderFactory.Create(appenderType, layout, reportLevel);
                appenders.Add(appender);
                reportLevel = 0;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var messages = input.Split("|");

                reportLevel = Enum.Parse<ReportLevel>(messages[0]);
                var date = DateTime.ParseExact(messages[1], "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                string message = messages[2];

                var error = new Error(date, reportLevel, message);
                var logger = new Logger(appenders);
                logger.Log(error);
            }

            var logFile = new LogFile();
            Console.WriteLine("Logger info");
            logFile.Write(appenders);
        }
    }
}
