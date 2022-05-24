using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RGR.Models.Database;


namespace RGR.Models
{
    public class CityTab : StaticTab
    {
        public CityTab(string h = "", DbSet<City>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("TeamSName");
            DataColumns.Add("NameOfTheCity");
        }
        new public DbSet<City>? DBS { get; set; }
    }
}