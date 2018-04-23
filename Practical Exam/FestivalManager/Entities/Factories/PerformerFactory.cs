using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
		    var performerType = typeof(Performer);

		    if (performerType == null)
		    {
		        throw new Exception(); // ? ?????
		    }

		    IPerformer performer = (IPerformer)Activator.CreateInstance(performerType, name, age);

		    return performer;
        }
	}
}