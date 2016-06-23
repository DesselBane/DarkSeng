using System.Windows.Media;

// ReSharper disable once CheckNamespace
namespace System.Windows
{
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Gets the visual parent of a certain type from a DependencyObject. e.g. You have a TabViewItem and want to have the TabView
        /// </summary>
        /// <typeparam name="T">Specifies the Type of the Parent e.g. TabView</typeparam>
        /// <returns>Returns null if no Parent was of Type T otherwiese returns the Parent as T</returns>
        public static T GetParentOfType<T>(this DependencyObject element) where T : DependencyObject
        {
            Type type = typeof(T);
            if (element == null) return null;
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            if (parent == null && ((FrameworkElement)element).Parent != null) parent = ((FrameworkElement)element).Parent;
            if (parent == null) return null;
            else if (parent.GetType() == type || parent.GetType().IsSubclassOf(type)) return parent as T;
            return GetParentOfType<T>(parent);
        }
    }
}
