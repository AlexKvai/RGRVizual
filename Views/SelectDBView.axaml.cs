using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.ViewModels;

namespace RGR.Views
{
    public partial class SelectDBView : Window
    {
        public SelectDBView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        public SelectDBView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new SelectDBViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}