using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// for MVVMLight messaging
    /// </summary>
    public class UISelectedItemChangedMessage
    {
        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public UISelectedItemChangedMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UISelectedItemChangedMessage"/> class.
        /// </summary>

        public UISelectedItemChangedMessage(
            System.String sourceTypeFullName,
            System.String sourcePropertyName,
            object selectedItem)
        {
            this.SourceTypeFullName = sourceTypeFullName;
            this.SourcePropertyName = sourcePropertyName;
            this.SelectedItem = selectedItem;
        }

        #endregion constructors

        /// <summary>
        /// Gets or sets the full name of the source type.
        /// </summary>
        /// <value>
        /// The full name of the source type.
        /// </value>
        public string SourceTypeFullName { get; set; }

        /// <summary>
        /// Gets or sets the name of the source property.
        /// </summary>
        /// <value>
        /// The name of the source property.
        /// </value>
        public string SourcePropertyName { get; set; }

        /// <summary>
        /// Gets or sets the selected item of Xamarin Picker.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public object SelectedItem { get; set; }

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("SourceTypeFullName:{0};SourcePropertyName:{1};SelectedItem:{2}", this.SourceTypeFullName, this.SourcePropertyName, this.SelectedItem != null ? this.SelectedItem.ToString() : null);
        }

        #endregion override string ToString()
    }
}

