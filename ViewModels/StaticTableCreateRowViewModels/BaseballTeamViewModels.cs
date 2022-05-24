using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.ViewModels.StaticTableCreateRowViewModels
{
    public class BaseballTeamViewModel : ViewModelBase
    {
        public BaseballTeamViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            BaseballTeam = new RGR.Models.Database.BaseballTeam();
        }
        public RGR.Models.Database.BaseballTeam BaseballTeam { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}