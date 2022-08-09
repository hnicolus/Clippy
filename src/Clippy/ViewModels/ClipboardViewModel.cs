using System;
using Clippy.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Clippy.ViewModels;

public partial class ClipboardViewModel : ObservableObject
{

    private static int COUNT = 0;

    [ObservableProperty]
    private int count = 0;

    [ObservableProperty]
    private ClipboardItem clip;

    public ClipboardViewModel(ClipboardItem clipboardItem)
    {
        Clip = clipboardItem;
        Count = COUNT++;
    }

    [RelayCommand]
    public void CopyToClipBoard(ClipboardItem clipboardItem)
    {
        SystemClipboardChecker.ClipboardItemClickedEventHandler?
        .Invoke(this, new ClipboardItemClickedEventArgs { Text = clipboardItem.Text });
        
        App.Current.Clipboard.SetTextAsync(clipboardItem.Text);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as ClipboardViewModel;
        return other != null && other.Clip.Text == other.Clip.Text;
    }
}