using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models.Database
{
    public partial class BaseballTeam
    {
        public string Name { get; set; }

        public string Record { get; set; }

        public string PlayoffAppearances { get; set; }

        public int Seasons { get; set; }

    }
}
