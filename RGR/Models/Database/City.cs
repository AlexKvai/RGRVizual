using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class City
    {
        public City()
        {
            BaseballTeams = new HashSet<BaseballTeam>();
        }

        public byte[] TeamSName { get; set; }
        public byte[] NameOfTheCity { get; set; }

        public virtual BaseballTeam TeamSNameNavigation { get; set; }
        public virtual ICollection<BaseballTeam> BaseballTeams { get; set; }
    }
}
