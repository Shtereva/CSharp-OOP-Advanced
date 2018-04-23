using System;

namespace FestivalManager.Entities.Sets
{
	public class Medium : Set
	{
	    public override TimeSpan MaxDuration => TimeSpan.FromSeconds(40 * 60);
        public Medium(string name)
	        : base(name)
	    {
	    }
	}
}