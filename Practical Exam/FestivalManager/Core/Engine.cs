
using System;
using System.Linq;
using System.Reflection;
using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core
{

    public class Engine : IEngine
    {
        private const string Suffix = "Command";

        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private IServiceProvider serviceProvider;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller,
            ISetController setCоntroller, IServiceProvider serviceProvider)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            string input;
            string result;

            while ((input = this.reader.ReadLine()) != "END")
            {
                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (Exception e)
                {
                    result = "ERROR: " + e.Message;
                }

                this.writer.WriteLine(result);
            }

            this.writer.WriteLine(this.festivalCоntroller.ProduceReport());
        }

        public string ProcessCommand(string input)
        {
            var data = input.Split();
            string commandName = data[0];
            data = data.Skip(1).ToArray();

            ICommand command = this.CreateCommand(commandName, data);

            return command.Execute(data);
        }

        private ICommand CreateCommand(string commandName, string[] data)
        {
            var assembly = Assembly.GetCallingAssembly();

            var commandType = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == commandName + Suffix);

            if (commandName == null)
            {
                //thr
            }

            var ctorParams = commandType
                .GetConstructors()
                .First()
                .GetParameters();

            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            return (ICommand)Activator.CreateInstance(commandType, args);
        }
    }
}