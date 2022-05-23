using System;
using System.Collections.Generic;

#nullable disable

namespace RGR.Models.Database
{
    public partial class BaseballPlayer
    {
        public byte[] ProperName { get; set; }
        public byte[] TeamSName { get; set; }
        public byte[] Born { get; set; }
        public long Age { get; set; }
        public byte[] Bats { get; set; }

        public virtual BaseballTeam TeamSNameNavigation { get; set; }
    }
}
