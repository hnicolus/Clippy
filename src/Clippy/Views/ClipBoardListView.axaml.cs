using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Clippy.Models;
using Clippy.ViewModels;

namespace Clippy.Views
{
    public partial class ClipBoardListView : UserControl
    {
        
        public ClipBoardListView()
        {
            InitializeComponent();
            DataContext = new  ClipboardListViewModel();
        }

 
    }
}