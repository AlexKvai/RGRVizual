using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RGR.Models
{
    public class CityTab : Tabs
    {
        public CityTab(string h = "", DbSet<City>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Name");
        }
        new public DbSet<City>? DBS { get; set; }
    }
}