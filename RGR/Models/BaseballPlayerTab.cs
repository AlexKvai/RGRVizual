using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;

namespace RGR.Models
{
    public class BaseballPlayerTab : Tabs
    {
        public BaseballPlayerTab(string h = "", DbSet<BaseballPlayer>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Name");
            DataColumns.Add("Age");
            DataColumns.Add("Born");
            DataColumns.Add("Bats");
        }
        new public DbSet<BaseballPlayer>? DBS { get; set; }
    }
}
