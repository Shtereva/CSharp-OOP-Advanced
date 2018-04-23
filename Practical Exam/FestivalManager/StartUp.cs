using System;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            var serviseProvider = ConfigureServices();
            IStage stage = serviseProvider.GetService<IStage>();
            IFestivalController festivalController = serviseProvider.GetService<IFestivalController>();
            ISetController setController = serviseProvider.GetService<ISetController>();

            IWriter writer = serviseProvider.GetService<IWriter>();
            IReader reader = serviseProvider.GetService<IReader>();

            var engine = new Engine(reader, writer, festivalController, setController, serviseProvider);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IStage, Stage>();
            services.AddSingleton<IFestivalController, FestivalController>();
            services.AddSingleton<ISetController, SetController>();

            services.AddSingleton<IWriter, ConsoleWriter>();
            services.AddSingleton<IReader, ConsoleReader>();

            services.AddTransient<IInstrumentFactory, InstrumentFactory>();
            services.AddTransient<IPerformerFactory, PerformerFactory>();
            services.AddTransient<ISetFactory, SetFactory>();
            services.AddTransient<ISongFactory, SongFactory>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}