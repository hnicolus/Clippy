namespace Clippy.Models
{
    public class NewClipboardItemAddedEventArg
    {
        public bool CanChange { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}