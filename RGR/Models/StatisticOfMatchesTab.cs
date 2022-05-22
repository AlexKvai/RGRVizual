using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;

namespace RGR.Models
{
    public class StatisticOfMatchesTab : Tabs
    {
        public StatisticOfMatchesTab(string h = "", DbSet<StatisticOfMatches>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Date");
            DataColumns.Add("Venue");
            DataColumns.Add("Points");
            DataColumns.Add("GameDuration");
        }
        new public DbSet<StatisticOfMatches>? DBS { get; set; }
    }
}