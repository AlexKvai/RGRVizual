using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.Models;
using Microsoft.EntityFrameworkCore;
using RGR.ViewModels;
using RGR.Models.Database;

namespace RGR.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
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
                if (selectedTab is DynTab)
                {
                    var selectedItems = (selectedTab as DynTab).BindedList;
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
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
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


    }
}