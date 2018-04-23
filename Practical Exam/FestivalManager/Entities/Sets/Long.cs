using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public override TimeSpan MaxDuration => TimeSpan.FromSeconds(60 * 60);
        public Long(string name) 
            : base(name)
        {
        }
    }
}
