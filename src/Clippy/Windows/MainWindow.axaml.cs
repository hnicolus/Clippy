using Avalonia.Controls;
using Clippy.ViewModels;

namespace Clippy
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModal();
        }
    }
}