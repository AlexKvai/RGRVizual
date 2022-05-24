using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.ViewModels.StaticTableCreateRowViewModels
{
    public class BaseballPlayerViewModel : ViewModelBase
    {
        public BaseballPlayerViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            BaseballPlayer = new RGR.Models.Database.BaseballPlayer();
        }
        public RGR.Models.Database.BaseballPlayer BaseballPlayer { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}