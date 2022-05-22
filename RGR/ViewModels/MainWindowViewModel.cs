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
            Request.Add(new Tabs("Request 1", true));
            Request.Add(new Tabs("Request 2", true));
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
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
            Grid.Add(new Grids("Randy Johnson", "Arizona Diamondbacks", "36", "36", "36", "36"));
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
            Tab.Add(new BaseballPlayerTab("Player", Data.Players));
            Tab.Add(new BaseballTeamTab("Team", Data.Teams));
            Tab.Add(new CityTab("City", Data.Cities));
            Tab.Add(new StatisticOfCareerAllTimeTab("StatisticOfCareer", Data.StatisticOfCareerAllTime));
            Tab.Add(new StatisticOfMatchesTab("StatisticOfMatches", Data.StatisticOfMatches));
        }
    }
}
