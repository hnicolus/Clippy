namespace Clippy.ViewModels
{
    internal class ClipboardChangedEventArgs
    {
        public bool CanChange { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}