using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class BaseballTeam
    {
        public BaseballTeam()
        {
            BaseballPlayers = new HashSet<BaseballPlayer>();
            Cities = new HashSet<City>();
        }

        public byte[] ProperName { get; set; }
        public byte[] Record { get; set; }
        public byte[] PlayoffAppearances { get; set; }
        public long Seasons { get; set; }
        public byte[] City { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<BaseballPlayer> BaseballPlayers { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
