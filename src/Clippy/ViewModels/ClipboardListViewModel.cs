using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Clippy.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clippy.ViewModels;

public partial class ClipboardListViewModel : ObservableObject
{
    [ObservableProperty] private ObservableClipboardList<ClipboardViewModel> items;

    private EventHandler<ClipboardChangedEventArgs> clipboardChangedEventHandler;

    public ClipboardListViewModel()
    {
        Items = new ObservableClipboardList<ClipboardViewModel>();
        Task.Run(UpdateClipBoardAsync);

        clipboardChangedEventHandler += OnNewClipboardItemUpdateList;
    }

    private void OnNewClipboardItemUpdateList(object? sender, ClipboardChangedEventArgs e)
    {
        if (e.CanChange)
        {
            Items.Add(new ClipboardViewModel(new ClipboardItem(e.Text)));
            items.OrderBy((x) => x,
            Comparer<ClipboardViewModel>.Create((x, y) => x.Clip.CreatedAt.CompareTo(y.Clip.CreatedAt)));
        }
    }

    private async Task UpdateClipBoardAsync()
    {
        while (true)
        {
            var text = (await App.Current?.Clipboard?.GetTextAsync()).Trim();
            var isNew = items.FirstOrDefault(x => x.Clip.Text == text) == null;
            if (isNew)
            {
                clipboardChangedEventHandler.Invoke(this, new ClipboardChangedEventArgs
                {
                    CanChange = true,
                    Text = text
                });
            }
            Thread.Sleep(1000);
        }
    }
}