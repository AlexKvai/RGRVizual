using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.ViewModels.StaticTableCreateRowViewModels
{
    public class StatisticOfMatchesViewModel : ViewModelBase
    {
        public StatisticOfMatchesViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            StatisticOfMatches = new RGR.Models.Database.StatisticOfMatches();
        }
        public RGR.Models.Database.StatisticOfMatches StatisticOfMatches { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}