using System;

namespace DarkSeng.Custom
{
    /// <summary>
    /// EventArgs with generic parameter
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class EventArgs<T> : EventArgs
    {
        private T _parameter;

        public T Parameter
        {
            get { return _parameter; }
        }

        public EventArgs(T parameter)
        {
            _parameter = parameter;
        }
    }
}