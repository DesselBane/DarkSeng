using System;
using System.Windows;
using System.Windows.Threading;

namespace DarkSeng.Extensions
{
    public static class UIExtensions
    {
        private static Action emptyDelegate = delegate () { };

        /// <summary>
        /// Redraws the UI
        /// </summary>
        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(DispatcherPriority.Render, emptyDelegate);
        }

    }
}
