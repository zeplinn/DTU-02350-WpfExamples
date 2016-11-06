using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfExamples.ToolBox
{
    /// <summary>
    /// Base class that implements notifications when altering properties.
    /// </summary>
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /////////////////////////////////////////////////////////////////////////////////////////////
        #region // Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////
        #region // Protected Methods

        /// <summary>
        /// Notifies that a property has been changed.
        /// </summary>
        /// <param name="propertyName">Name of the property which has been modified. 
        /// Please note that it is utilizing the [CallerMemberName] which allows for
        /// anonymously detecting which property is changed when calling from inside a 
        /// property.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Sets the value of a property using a reference to the underlying private field it is representing.
        /// Furthermore, it notifies any eventhandlers that are hooked onto the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="member">Reference to the private field representing the property</param>
        /// <param name="value">Value to set the field</param>
        /// <param name="propertyName">Name of the property which has been modified. 
        /// Please note that it is utilizing the [CallerMemberName] which allows for
        /// anonymously detecting which property is changed when calling from inside a 
        /// property.
        /// </param>
        
        public void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (member != null && member.Equals(value)) return;
            member = value;
            this.OnPropertyChanged(propertyName);
        }
        #endregion
    }
}
