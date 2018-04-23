namespace FestivalManager.Entities
{
	using System;
	using Contracts;

	public class Song : ISong
    {
        public string Name { get; protected set; }

        public TimeSpan Duration { get; protected set; }

        public Song(string name, TimeSpan duration)
		{
			this.Name = name;
			this.Duration = duration;
		}

	    public override string ToString()
	    {
		    return $"{this.Name} ({this.Duration:mm\\:ss})";
	    }
    }
}
