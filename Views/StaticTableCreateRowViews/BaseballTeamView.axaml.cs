using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.ViewModels;
using RGR.ViewModels.StaticTableCreateRowViewModels;

namespace RGR.Views.StaticTableCreateRowViews
{
    public partial class BaseballTeamView : Window
    {
        public BaseballTeamView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Confirm").Click += button_Confirm_Click;
            this.FindControl<Button>("Cancel").Click += button_Cancel_Click;
        }
        public BaseballTeamView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new BaseballTeamViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void button_Confirm_Click(object? sender, RoutedEventArgs e)
        {
            var dc = (this.DataContext as BaseballTeamViewModel);
            dc.MainContext.Data.BaseballTeams.Add(dc.BaseballTeam);
            dc.MainContext.Data.SaveChanges();
            this.Close();
        }
        private void button_Cancel_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}