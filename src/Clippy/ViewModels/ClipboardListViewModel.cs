using System.Collections.Generic;
using System.Linq;
using Clippy.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clippy.ViewModels
{
    public partial class ClipboardListViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<ClipboardViewModel> items = new();
        private readonly SystemClipboardChecker systemClipboardChecker;
        public ClipboardListViewModel()
        {
            systemClipboardChecker = new SystemClipboardChecker();
            SystemClipboardChecker.ClipboardChangedEventHandler += OnNewClipboardItemUpdateList;
            SystemClipboardChecker.ClipboardItemClickedEventHandler += OnClipboardItemClicked;
        }

        private void OnClipboardItemClicked(object? sender, ClipboardItemClickedEventArgs e)
        {
            ClipboardViewModel? item = items.FirstOrDefault(x => x.Clip.Text == e.Text);

            if (item != null)
            {
                Items = new List<ClipboardViewModel>(items.Where(x => x != item));
            }
        }

        private void OnNewClipboardItemUpdateList(object? sender, NewClipboardItemAddedEventArg e)
        {
            if (e.CanChange)
            {
                Items.Add(new ClipboardViewModel(new ClipboardItem(e.Text)));
                Items = new List<ClipboardViewModel>(Items.OrderByDescending(x => x.Count));
            }
        }


    }
}