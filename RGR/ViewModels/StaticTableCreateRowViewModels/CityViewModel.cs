using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.ViewModels.StaticTableCreateRowViewModels
{
    public class CityViewModel : ViewModelBase
    {
        public CityViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            City = new RGR.Models.Database.City();
        }
        public RGR.Models.Database.City City { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}