using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;


namespace RGR.Models
{
    public class BaseballPlayerTab : StaticTab
    {
        public BaseballPlayerTab(string h = "", DbSet<BaseballPlayer>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ProperName");
            DataColumns.Add("TeamSName");
            DataColumns.Add("Born");
            DataColumns.Add("Age");
            DataColumns.Add("Bats");
        }
        new public DbSet<BaseballPlayer>? DBS { get; set; }
    }
}
