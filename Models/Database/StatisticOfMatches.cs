using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class StatisticOfMatches
    {
        public string TeamSName { get; set; }
        public string Date { get; set; }
        public string Venue { get; set; }
        public long? Points { get; set; }
        public string GameDuration { get; set; }

        public virtual BaseballTeam TeamSNameNavigation { get; set; }
    }
}
