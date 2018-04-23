
using System;
using System.Linq;
using System.Reflection;
using FestivalManager.Entities.Factories.Contracts;
using FestivalManager.Entities.Contracts;


namespace FestivalManager.Entities.Factories
{
    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var assembly = Assembly.GetCallingAssembly();

            var instrumentType = assembly
                .GetTypes()
                .First(s => s.Name == type);

            if (instrumentType == null)
            {
                throw new Exception(); // ? ?????
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
        }
    }
}