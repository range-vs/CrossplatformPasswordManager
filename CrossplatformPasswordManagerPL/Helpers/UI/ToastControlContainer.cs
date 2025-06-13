using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Helpers.UI
{
    public class ToastControlContainer : IToastControlContainer
    {
        public Popup Toast { get; set; }
        public TextBlock Text { get; set; }

        public ToastControlContainer(Popup toast, TextBlock text) 
        {
            Toast = toast;
            Text = text;
        }
        public void Show(TimeSpan sec, string text)
        {
            Text.Text = text;
            Toast.IsOpen = true;
            var timer = new DispatcherTimer
            {
                Interval = sec
            };
            timer.Tick += (_, _) =>
            {
                Toast.IsOpen = false;
                timer.Stop();
            };
            timer.Start();
        }

    }
}
