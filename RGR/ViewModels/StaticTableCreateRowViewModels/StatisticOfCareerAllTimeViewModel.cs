using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.ViewModels.StaticTableCreateRowViewModels
{
    public class StatisticOfCareerAllTimeViewModel : ViewModelBase
    {
        public StatisticOfCareerAllTimeViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            StatisticOfCareerAllTime = new RGR.Models.Database.StatisticOfCareerAllTime();
        }
        public RGR.Models.Database.StatisticOfCareerAllTime StatisticOfCareerAllTime { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}