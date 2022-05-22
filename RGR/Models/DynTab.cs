using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class DynTab : Tabs
    {
        public DynTab(string h = "", List<object>? db = null, List<string>? dc = null) : base(h)
        {
            ButtonVisible = true;
            BindedList = db;
        }
        public Query BindedQuery { get; set; }
        public List<object>? BindedList { get; set; }
    }
}