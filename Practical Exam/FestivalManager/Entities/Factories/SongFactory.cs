namespace FestivalManager.Entities.Factories
{
	using System;
	using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
		    var songType = typeof(Song);

		    if (songType == null)
		    {
		        throw new Exception(); // ? ?????
		    }

		    ISong song = (ISong)Activator.CreateInstance(songType, name, duration);

		    return song;
        }
	}
}