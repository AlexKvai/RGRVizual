using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RGR.ViewModels;

namespace RGR.Views
{
    public partial class GroupDBView : Window
    {
        public GroupDBView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        public GroupDBView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new GroupDBViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}