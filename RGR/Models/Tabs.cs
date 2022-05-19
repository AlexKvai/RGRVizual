using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Tabs
    {
        public Tabs(string head = "", bool butvis = false)
        {
            Header = head;
            ButtonVisible = butvis;
        }
        public string Header { get; set; }
        public bool ButtonVisible { get; set; }
    }
}
