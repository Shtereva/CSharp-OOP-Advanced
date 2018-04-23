namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
	    public override TimeSpan MaxDuration => TimeSpan.FromSeconds(15 * 60);

	    public Short(string name) 
	        : base(name)
	    {
	    }
	}
}