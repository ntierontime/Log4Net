using System;
using System.ComponentModel;

namespace Framework
{
    /// <summary>
    /// Provides a method for Notification support.
    /// We use this class for model classes.
    /// It should be serializable.
    /// </summary>
#if SILVERLIGHT
#elif NETFX_CORE
#else
    [Serializable]
#endif
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
#if SILVERLIGHT
#elif NETFX_CORE
#else
        [field: NonSerialized]
#endif
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies that <see cref="propertyName" /> has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName)
                    );
            }
        }
    }
}