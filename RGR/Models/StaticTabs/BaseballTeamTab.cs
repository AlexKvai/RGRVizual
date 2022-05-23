using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;

namespace RGR.Models
{
    public class BaseballTeamTab : StaticTab
    {
        public BaseballTeamTab(string h = "", DbSet<BaseballTeam>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ProperName");
            DataColumns.Add("Record");
            DataColumns.Add("PlayoffAppearances");
            DataColumns.Add("Seasons");
            DataColumns.Add("City");
        }
        new public DbSet<BaseballTeam>? DBS { get; set; }
    }
}