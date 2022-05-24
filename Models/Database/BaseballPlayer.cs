using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class BaseballPlayer
    {
        public string ProperName { get; set; }
        public string TeamSName { get; set; }
        public string Born { get; set; }
        public long Age { get; set; }
        public string Bats { get; set; }

        public virtual BaseballTeam TeamSNameNavigation { get; set; }
    }
}
