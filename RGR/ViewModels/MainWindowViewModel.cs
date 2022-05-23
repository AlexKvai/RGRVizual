using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Linq;
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
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        DataBaseContext data;

        public DataBaseContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new DataBaseContext();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new BaseballPlayerTab("Horse", Data.BaseballPlayers));
            Tabs.Add(new BaseballTeamTab("Horse Relatives", Data.BaseballTeams));
            Tabs.Add(new CityTab("Jokey", Data.Cities));
            Tabs.Add(new StatisticOfCareerAllTimeTab("Race", Data.StatisticOfCareerAllTimes));
            Tabs.Add(new StatisticOfMatchesTab("Result", Data.StatisticOfMatches));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
            Queries.Add(new Query("1234"));
            Queries.Add(new Query("12534"));
            Queries.Add(new Query("123"));
            Queries.Add(new Query("126734"));
        }
    }
}