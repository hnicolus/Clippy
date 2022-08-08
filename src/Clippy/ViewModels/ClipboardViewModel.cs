using System;
using Clippy.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Clippy.ViewModels;

public partial class ClipboardViewModel: ObservableObject
{
    
    [ObservableProperty]
    private ClipboardItem clip;

    public ClipboardViewModel(ClipboardItem clipboardItem)
    {
        Clip = clipboardItem;
    }
       
    [RelayCommand]
    public void CopyToClipBoard(ClipboardItem clipboardItem)
    {
        Console.WriteLine(clipboardItem.Text);
        Console.WriteLine("Coping to clip board");
    }
    
    public override bool Equals(object? obj)
    {
        var other = obj as ClipboardViewModel;
        return other != null && other.Clip.Text == other.Clip.Text;
    }
}