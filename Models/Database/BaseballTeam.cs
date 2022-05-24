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

        public string ProperName { get; set; }
        public string Record { get; set; }
        public string PlayoffAppearances { get; set; }
        public long Seasons { get; set; }
        public string City { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<BaseballPlayer> BaseballPlayers { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
