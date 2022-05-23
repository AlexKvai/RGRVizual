using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;

namespace RGR.Models
{
    public class StatisticOfCareerAllTimeTab : StaticTab
    {
        public StatisticOfCareerAllTimeTab(string h = "", DbSet<StatisticOfCareerAllTime>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("NameTeam");
            DataColumns.Add("War");
            DataColumns.Add("AB");
            DataColumns.Add("H");
            DataColumns.Add("HR");
        }

        new public DbSet<StatisticOfCareerAllTime>? DBS { get; set; }

    }
}
