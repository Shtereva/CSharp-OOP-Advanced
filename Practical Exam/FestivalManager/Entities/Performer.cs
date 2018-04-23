namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Performer : IPerformer
	{
		private  IList<IInstrument> instruments;
	    public string Name { get; protected set; }

	    public int Age { get; protected set; }

	    public IReadOnlyCollection<IInstrument> Instruments => (IReadOnlyCollection<IInstrument>)this.instruments;

        public Performer(string name, int age)
		{
			this.Name = name;
			this.Age = age;
            this.instruments = new List<IInstrument>();
		}

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
