using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DarkSeng.Extensions
{
    public static class MouseButtonEventArgsExtention
    {
        /// <summary>
        /// Detects the Visual item that is under the mouse when it was clicked
        /// </summary>
        /// <param name="sender">The sender of this Event</param>
        public static DependencyObject UnderlyingObject(this MouseButtonEventArgs e, UIElement sender)
        {
            return VisualTreeHelper.HitTest(sender, e.GetPosition(sender)).VisualHit;
        }

        /// <summary>
        /// Detects the Visual item that is under the mouse when it was clicked and searches for its Visual Parent of Type T
        /// </summary>
        /// <typeparam name="T">The Type of the Parent</typeparam>
        /// <param name="sender">The sender of this Event</param>
        public static T UnderlyingObject<T>(this MouseButtonEventArgs e, UIElement sender) where T : UIElement
        {
            return e.UnderlyingObject(sender).GetParentOfType<T>();
        }
    }
}
