using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive.Linq;
using RGR.Models;
using RGR.Models.Database;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateGrid();
            CreateRequests();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
        }

        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        ObservableCollection<Tabs> tab;
        public ObservableCollection<Tabs> Tab
        {
            get { return tab; }
            set { this.RaiseAndSetIfChanged(ref tab, value); }
        }



        ObservableCollection<Tabs> request;
        public ObservableCollection<Tabs> Request
        {
            get { return request; }
            set { this.RaiseAndSetIfChanged(ref request, value); }
        }

        private void CreateRequests()
        {
            Request = new ObservableCollection<Tabs>();
            Request.Add(new Tabs("Çàïðîñ 1", true));
            Request.Add(new Tabs("Çàïðîñ 2", true));
        }

        ObservableCollection<Grids> grid;
        public ObservableCollection<Grids> Grid
        {
            get { return grid; }
            set { this.RaiseAndSetIfChanged(ref grid, value); }
        }
        private void CreateGrid()
        {
            Grid = new ObservableCollection<Grids>();
            Grid.Add(new Grids("Alex Ovechkin", "LW", "36", "1274", "780", "630" ));
            Grid.Add(new Grids("Joe Thornton", "C", "42", "1714", "430", "1109"));
            Grid.Add(new Grids("Evgeni Malkin", "C", "35", "981", "444", "702"));
            Grid.Add(new Grids("Sidney Crosby", "C", "34", "1108", "517", "892"));
            Grid.Add(new Grids("Marc-Andre Fleury", "G", "37", "939", "520", "299"));
            Grid.Add(new Grids("Patrick Marleau", "C", "42", "1779", "566", "631"));
        }

        DatabaseContext data;

        public DatabaseContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new DatabaseContext();
        }

        private void CreateTabs()
        {
            Tab = new ObservableCollection<Tabs>();
            Tab.Add(new BaseballPlayerTab("Arena", Data.Players));
            Tab.Add(new BaseballTeamTab("Coach", Data.Teams));
            Tab.Add(new CityTab("Game", Data.Cities));
            Tab.Add(new StatisticOfCareerAllTimeTab("Player", Data.StatisticOfCareerAllTime));
            Tab.Add(new StatisticOfMatchesTab("PlayerResult", Data.StatisticOfMatches));
        }
    }
}
