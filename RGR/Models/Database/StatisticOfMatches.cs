using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class StatisticOfMatches
    {
        public byte[] TeamSName { get; set; }
        public byte[] Date { get; set; }
        public byte[] Venue { get; set; }
        public long? Points { get; set; }
        public byte[] GameDuration { get; set; }

        public virtual BaseballTeam TeamSNameNavigation { get; set; }
    }
}
