using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clippy.Models
{
    public class ClipboardItemClickedEventArgs
    {
        public string Text { get; set; }
    }
    
    public class SystemClipboardChecker
    {

        public static EventHandler<NewClipboardItemAddedEventArg> ClipboardChangedEventHandler;
        public static EventHandler<ClipboardItemClickedEventArgs> ClipboardItemClickedEventHandler;
        public SystemClipboardChecker()
        {
            Task.Run(CheckSystemClipboardInBackgroundAsync);
        }

        public async Task CheckSystemClipboardInBackgroundAsync()
        {
            var currentText = "";
            while (true)
            {
                var text = (await App.Current?.Clipboard.GetTextAsync()).Trim();

                if (text != currentText)
                {
                    currentText = text;
                    ClipboardChangedEventHandler?
                    .Invoke(this, new NewClipboardItemAddedEventArg { Text = text, CanChange = true });
                }
                Thread.Sleep(1000);
            }
        }


    }
}