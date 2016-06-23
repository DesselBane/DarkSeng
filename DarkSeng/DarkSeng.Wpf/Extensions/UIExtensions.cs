using System.Windows.Threading;

// ReSharper disable once CheckNamespace
namespace System.Windows
{
    public static class UIExtensions
    {
        private static readonly Action EmptyDelegate = delegate () { };

        /// <summary>
        /// Redraws the UI
        /// </summary>
        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

    }
}
