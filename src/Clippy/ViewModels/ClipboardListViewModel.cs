using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Clippy.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TextCopy;

namespace Clippy.ViewModels;

public partial class ClipboardListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableClipboardList<ClipboardViewModel> items;

    public ClipboardListViewModel()
    {
        Items = new ObservableClipboardList<ClipboardViewModel>();
        Task.Run(UpdateClipBoardAsync);
    }
    
    private async Task UpdateClipBoardAsync()
    {
        while (true)
        {
            var text =(await App.Current.Clipboard.GetTextAsync()).Trim();
            Console.WriteLine($"{text}");
            var isNew = items.FirstOrDefault(x => x.Clip.Text == text) == null;
            Console.WriteLine(isNew);
            if (isNew)
            {
                Items.Add(new ClipboardViewModel(new ClipboardItem(text)));
            }
            items.Sort((x, y) => y.Clip.CreatedAt.CompareTo(x.Clip.CreatedAt));
            Thread.Sleep(1000);
        }
    }
}