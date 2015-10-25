using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Log4Net.WP71App.UserControls
{
    /// <summary>
	/// Interaction logic for UCCommonOfLog
    /// The other solution of ListBox is ListPicker, although it is the dropdownlist
	///		: http://michaelhubele.com/post/2014/01/14/mvvm-light-windows-phone-toolkit-list-picker
    ///		http://www.dotnetspeaks.com/DisplayArticle.aspx?ID=230
    ///		http://samidipbasu.com/2011/05/19/fun-with-toolkit-listpicker-selections/
    ///		http://www.geekchamp.com/articles/listpicker-for-wp7-in-depth
    ///		http://blogs.msdn.com/b/delay/archive/2010/11/03/listpicker-i-hardly-even-know-er-a-detailed-overview-of-the-windows-phone-toolkit-s-listpicker-control.aspx
    ///		http://www.hows.info/questions/9235812/how-to-read-the-selected-item-from-a-listpicker-in-wp7
    ///		http://www.geekchamp.com/marketplace/components/listpicker-learning-pack
    ///		http://social.msdn.microsoft.com/Forums/wpapps/en-us/39a3c1c9-47f6-484f-8153-791319e5049a/listpicker-problems-setting-selecteditem-in-xaml-with-twoway-binding?forum=wpdevelop
	///		http://www.codeproject.com/Articles/456589/Bindable-Converter-Parameter
    /// </summary>
    public partial class UCCommonOfLog : UserControl
    {
        public UCCommonOfLog()
        {
            InitializeComponent();
        }
    }
}