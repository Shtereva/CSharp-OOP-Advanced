using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private const string LongSongDuration = "Song is over the set limit!";

        private IList<IPerformer> performers;
        private IList<ISong> songs;

        public string Name { get; protected set; }
        public virtual TimeSpan MaxDuration { get; protected set; }

        public TimeSpan ActualDuration => TimeSpan.FromSeconds(this.Songs.Sum(s => (s.Duration.Minutes * 60) + s.Duration.Seconds));
        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>)this.performers;
        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;

        protected Set(string name)
        {
            this.Name = name;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException(LongSongDuration);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            bool conditions = this.Performers.Any() && this.Songs.Any() &&
                              this.Performers.All(p => p.Instruments.Any(i => i.IsBroken == false));
            if (conditions)
            {
                return true;
            }

            return false;
        }
    }
}
