using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class StatisticOfCareerAllTime
    {
        public string PlayerSName { get; set; }
        public string TeamSName { get; set; }
        public double? War { get; set; }
        public long? Ab { get; set; }
        public long? H { get; set; }
        public long? Hr { get; set; }

        public virtual BaseballPlayer PlayerSNameNavigation { get; set; }
    }
}
