using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if NETFX_CORE
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Markup;
#endif

namespace Framework.Xaml
{
    /// <summary>
    /// Menu Tree Item Entity in WPF/Silverlight/WindowsMobile
    /// added [ContentProperty("MenuTreeItems")]
#if NETFX_CORE
    [ContentProperty(Name = "MenuTreeItems")]
#else
    [ContentProperty("MenuTreeItems")]
#endif
    public class MenuTreeItem: Framework.MenuTreeItem
    {
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuTreeItem"/> class.
        /// </summary>
        public MenuTreeItem()
            : base()
        {
        }
        #endregion constructor
    }
}