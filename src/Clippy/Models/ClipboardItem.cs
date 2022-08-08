using System;
using System.Linq;
using Clippy.Utils;

namespace Clippy.Models;

public class ClipboardItem
{
    public string Title => Text.Truncate(38);
    public string Text { get; set; }
    public  DateTime CreatedAt { get; set; }

    public ClipboardItem(string text)
    {
        Text = text;
        CreatedAt = new DateTime();
    }
    public override bool Equals(object? obj)
    {
        var other = obj as ClipboardItem;
        return other != null && Text == other.Text;
    }
}