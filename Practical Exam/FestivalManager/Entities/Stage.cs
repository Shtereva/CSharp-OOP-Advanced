using System;
using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
	    private IList<ISet> sets;
	    private IList<ISong> songs;
	    private IList<IPerformer> performers;

	    public IReadOnlyCollection<ISet> Sets => (IReadOnlyCollection<ISet>)this.sets;
	    public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;
	    public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>) this.performers;

	    public Stage()
	    {
	        this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
	    }
	    public IPerformer GetPerformer(string name)
	    {
	        if (!this.HasPerformer(name))
	        {
	            throw new InvalidOperationException("Invalid performer provided");
            }

	        return this.performers.First(s => s.Name == name);
        }

	    public ISong GetSong(string name)
	    {
	        if (!this.HasSong(name))
	        {
	            throw new InvalidOperationException("Invalid song provided");
	        }

	        return this.songs.First(s => s.Name == name);
        }

	    public ISet GetSet(string name)
	    {
	        if (!this.HasSet(name))
	        {
	            throw new InvalidOperationException("Invalid set provided");
	        }

	        return this.sets.First(s => s.Name == name);
        }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
	        this.songs.Add(song);
	    }

	    public void AddSet(ISet performer)
	    {
	        this.sets.Add(performer);
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.performers.Any(p => p.Name == name);
	    }

	    public bool HasSong(string name)
	    {
	        return this.songs.Any(p => p.Name == name);
        }

	    public bool HasSet(string name)
	    {
	        return this.sets.Any(p => p.Name == name);
        }
	}
}
