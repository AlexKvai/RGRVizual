using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive.Linq;
using RGR.Models;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
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
        private void CreateTabs()
        {
            Tab = new ObservableCollection<Tabs>();
            Tab.Add(new Tabs("Players",false));
            Tab.Add(new Tabs("Teams", false));
            Tab.Add(new Tabs("Statistic of matches", false));
            Tab.Add(new Tabs("Statistic of career all time", false));
            Tab.Add(new Tabs("City", false));
            Tab.Add(new Tabs("Request 1", false));
            Tab.Add(new Tabs("Request 2", false));
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
            Grid.Add(new Grids("Paul Goldschmidt", "San Diego Padres", "36" , "80", "78", "63"));
            Grid.Add(new Grids("Randy Johnson", "San Diego Padres", "42", "110", "43", "11"));
            Grid.Add(new Grids("Tyler Naquin", "San Diego Padres", "35", "120", "44", "28"));
            Grid.Add(new Grids("Tommy Pham", "Cincinnati Reds", "34", "130", "51", "98"));
            Grid.Add(new Grids("Luis Cessa", "Cincinnati Reds", "37", "81", "52", "33"));
            Grid.Add(new Grids("Justin Wilson", "Atlanta Braves", "42", "89", "56", "62"));
        }
    }
}
