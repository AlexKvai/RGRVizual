using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.Models;
using Microsoft.EntityFrameworkCore;
using RGR.ViewModels;
using RGR.ViewModels.StaticTableCreateRowViewModels;
using RGR.Views.StaticTableCreateRowViews;
using RGR.Models.Database;
using RGR.Models;

namespace RGR.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            this.Find<DataGrid>("DataTable").AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            this.FindControl<TabControl>("DataTabs").SelectionChanged += tabControl_SelectionChanged;
            this.FindControl<Button>("CreateNew").Click += button_CreateNew_Click;
            this.FindControl<Button>("Delete").Click += button_Delete_Click;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void changeDataGridItems()
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            if (selectedTab != null)
            {
                if (selectedTab is DynamicTab)
                {
                    var selectedItems = (selectedTab as DynamicTab).BindedList;
                    if (selectedItems != null)
                        this.Find<DataGrid>("DataTable").Items = selectedItems;
                }
                else
                {
                     if (selectedTab is BaseballPlayerTab)
                    {
                        var selectedItems = (selectedTab as BaseballPlayerTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is BaseballTeamTab)
                    {
                        var selectedItems = (selectedTab as BaseballTeamTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is CityTab)
                    {
                        var selectedItems = (selectedTab as CityTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is StatisticOfCareerAllTimeTab)
                    {
                        var selectedItems = (selectedTab as StatisticOfCareerAllTimeTab).DBS;
                    } 
                    else if (selectedTab is StatisticOfMatchesTab)
                    {
                        var selectedItems = (selectedTab as StatisticOfMatchesTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else throw new System.ArgumentException();
                }
            }
        }
        private void refreshDataGridItems()
        {
            this.Find<DataGrid>("DataTable").Items = null;
            changeDataGridItems();
        }
        private void tabControl_SelectionChanged(object? sender,
           SelectionChangedEventArgs e)
        {
            changeDataGridItems();
        }
        private void dataGrid_AutoGeneratingColumn(object? sender,
        DataGridAutoGeneratingColumnEventArgs e)
        {
            var tab = (this.FindControl<TabControl>("DataTabs").SelectedItem as MyTab);
            if (!tab.DataColumns.Contains(e.Column.Header.ToString()))
                e.Column.IsVisible = false;
        }

        async private void button_CreateNew_Click(object? sender, RoutedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            Window window;
            if (selectedTab != null)
            {
                if (selectedTab is BaseballPlayerTab)
                {
                    window = new BaseballPlayerView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is BaseballTeamTab)
                {
                    window = new BaseballTeamView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is CityTab)
                {
                    window = new CityView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is StatisticOfCareerAllTimeTab)
                {
                    window = new StatisticOfCareerAllTimeView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is StatisticOfMatchesTab)
                {
                    window = new StatisticOfMatchesView((this.DataContext as FirstViewModel).MainContext);
                }

                else throw new System.ArgumentException();
                await window.ShowDialog((Window)this.VisualRoot);
                refreshDataGridItems();
            }
        }
        private void button_Delete_Click(object? sender, RoutedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            var dgItem = this.Find<DataGrid>("DataTable").SelectedItem;
            if (selectedTab != null && dgItem != null)
            {
                if (selectedTab is BaseballPlayerTab)
                {
                    (selectedTab as BaseballPlayerTab).DBS.Remove(dgItem as BaseballPlayer);
                }
                else if (selectedTab is BaseballTeamTab)
                {

                    (selectedTab as BaseballTeamTab).DBS.Remove(dgItem as BaseballTeam);
                }
                else if (selectedTab is CityTab)
                {

                    (selectedTab as CityTab).DBS.Remove(dgItem as City);
                }
                else if (selectedTab is StatisticOfCareerAllTimeTab)
                {

                    (selectedTab as StatisticOfCareerAllTimeTab).DBS.Remove(dgItem as StatisticOfCareerAllTime);
                }
                else if (selectedTab is StatisticOfMatchesTab)
                {

                    (selectedTab as StatisticOfMatchesTab).DBS.Remove(dgItem as StatisticOfMatches);
                }
                else throw new System.ArgumentException();
                (this.DataContext as FirstViewModel).MainContext.Data.SaveChanges();
                refreshDataGridItems();
            }
        }
    }
}