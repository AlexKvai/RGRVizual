using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.ViewModels;
using RGR.ViewModels.StaticTableCreateRowViewModels;

namespace RGR.Views.StaticTableCreateRowViews
{
    public partial class BaseballPlayerView : Window
    {
        public BaseballPlayerView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Confirm").Click += button_Confirm_Click;
            this.FindControl<Button>("Cancel").Click += button_Cancel_Click;
        }
        public BaseballPlayerView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new BaseballPlayerViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void button_Confirm_Click(object? sender, RoutedEventArgs e)
        {
            var dc = (this.DataContext as BaseballPlayerViewModel);
            dc.MainContext.Data.BaseballPlayers.Add(dc.BaseballPlayer);
            dc.MainContext.Data.SaveChanges();
            this.Close();
        }
        private void button_Cancel_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}