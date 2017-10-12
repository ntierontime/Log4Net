/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Log4Net.MVVMLightViewModels"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  OR (WPF only):

  xmlns:vm="clr-namespace:Log4Net.MVVMLightViewModels"
  DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
*/

namespace Log4Net.MVVMLightViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the ViewModelLocatorTemplate in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Log4Net.MVVMLightViewModels"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// <para>
    /// In <strong>*WPF only*</strong> (and if databinding in Blend is not relevant), you can delete
    /// the Main property and bind to the ViewModelNameStatic property instead:
    /// </para>
    /// <code>
    /// xmlns:vm="clr-namespace:Log4Net.MVVMLightViewModels"
    /// DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
    /// </code>
    /// </summary>
    public class ViewModelLocator
    {
        public static string WebApiRootUrl { get; set; }

        #region constructors

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}

            CreateMain();
        }

        #endregion constructors

        #region Log4Net.MVVMLightViewModels.MainViewModel

        private static Log4Net.MVVMLightViewModels.MainViewModel _main;

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static Log4Net.MVVMLightViewModels.MainViewModel MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public Log4Net.MVVMLightViewModels.MainViewModel Main
        {
            get
            {
                return MainStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Main property.
        /// </summary>
        public static void ClearMain()
        {
            _main.Cleanup();
            _main = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new Log4Net.MVVMLightViewModels.MainViewModel();
            }
        }

        #endregion Log4Net.MVVMLightViewModels.MainViewModel

        #region MVVMViewModel #1.1: Log4Net.MVVMLightViewModels.WPCommonOfLogVM

        private static Log4Net.MVVMLightViewModels.WPCommonOfLogVM m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM;
        public static Log4Net.MVVMLightViewModels.WPCommonOfLogVM Log4Net_MVVMLightViewModels_WPCommonOfLogVM_Static
        {
            get
            {
                if (m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM == null)
                {
                    CreateLog4Net_MVVMLightViewModels_WPCommonOfLogVM();
                }

                return m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM;
            }
        }

        public Log4Net.MVVMLightViewModels.WPCommonOfLogVM Log4Net_MVVMLightViewModels_WPCommonOfLogVM
        {
            get
            {
                return Log4Net_MVVMLightViewModels_WPCommonOfLogVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_MVVMLightViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void Clear_Log4Net_MVVMLightViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM != null)
            {
                m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM.Cleanup();
                m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_MVVMLightViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void CreateLog4Net_MVVMLightViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM == null)
            {
                m_Log4Net_MVVMLightViewModels_WPCommonOfLogVM = new Log4Net.MVVMLightViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.MVVMLightViewModels.WPCommonOfLogVM

        #region MVVMViewModel #2.1: Log4Net.MVVMLightViewModels.ItemVMLog

        private static Log4Net.MVVMLightViewModels.ItemVMLog m_Log4Net_MVVMLightViewModels_ItemVMLog;
        public static Log4Net.MVVMLightViewModels.ItemVMLog Log4Net_MVVMLightViewModels_ItemVMLog_Static
        {
            get
            {
                if (m_Log4Net_MVVMLightViewModels_ItemVMLog == null)
                {
                    CreateLog4Net_MVVMLightViewModels_ItemVMLog();
                }

                return m_Log4Net_MVVMLightViewModels_ItemVMLog;
            }
        }

        public Log4Net.MVVMLightViewModels.ItemVMLog Log4Net_MVVMLightViewModels_ItemVMLog
        {
            get
            {
                return Log4Net_MVVMLightViewModels_ItemVMLog_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_MVVMLightViewModels_ItemVMLog property.
        /// </summary>
        public static void Clear_Log4Net_MVVMLightViewModels_ItemVMLog()
        {
            if (m_Log4Net_MVVMLightViewModels_ItemVMLog != null)
            {
                m_Log4Net_MVVMLightViewModels_ItemVMLog.Cleanup();
                m_Log4Net_MVVMLightViewModels_ItemVMLog = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_MVVMLightViewModels_ItemVMLog property.
        /// </summary>
        public static void CreateLog4Net_MVVMLightViewModels_ItemVMLog()
        {
            if (m_Log4Net_MVVMLightViewModels_ItemVMLog == null)
            {
                m_Log4Net_MVVMLightViewModels_ItemVMLog = new Log4Net.MVVMLightViewModels.ItemVMLog();
            }
        }

        #endregion MVVMViewModel: Log4Net.MVVMLightViewModels.ItemVMLog

        #region MVVMViewModel #3.1: Log4Net.MVVMLightViewModels.ExtendedVMLog

        private static Log4Net.MVVMLightViewModels.ExtendedVMLog m_Log4Net_MVVMLightViewModels_ExtendedVMLog;
        public static Log4Net.MVVMLightViewModels.ExtendedVMLog Log4Net_MVVMLightViewModels_ExtendedVMLog_Static
        {
            get
            {
                if (m_Log4Net_MVVMLightViewModels_ExtendedVMLog == null)
                {
                    CreateLog4Net_MVVMLightViewModels_ExtendedVMLog();
                }

                return m_Log4Net_MVVMLightViewModels_ExtendedVMLog;
            }
        }

        public Log4Net.MVVMLightViewModels.ExtendedVMLog Log4Net_MVVMLightViewModels_ExtendedVMLog
        {
            get
            {
                return Log4Net_MVVMLightViewModels_ExtendedVMLog_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_MVVMLightViewModels_ExtendedVMLog property.
        /// </summary>
        public static void Clear_Log4Net_MVVMLightViewModels_ExtendedVMLog()
        {
            if (m_Log4Net_MVVMLightViewModels_ExtendedVMLog != null)
            {
                m_Log4Net_MVVMLightViewModels_ExtendedVMLog.Cleanup();
                m_Log4Net_MVVMLightViewModels_ExtendedVMLog = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_MVVMLightViewModels_ExtendedVMLog property.
        /// </summary>
        public static void CreateLog4Net_MVVMLightViewModels_ExtendedVMLog()
        {
            if (m_Log4Net_MVVMLightViewModels_ExtendedVMLog == null)
            {
                m_Log4Net_MVVMLightViewModels_ExtendedVMLog = new Log4Net.MVVMLightViewModels.ExtendedVMLog();
            }
        }

        #endregion MVVMViewModel: Log4Net.MVVMLightViewModels.ExtendedVMLog

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {

            // #1.1: Log4Net.MVVMLightViewModels.WPCommonOfLogVM
            Clear_Log4Net_MVVMLightViewModels_WPCommonOfLogVM();

            // #2.1: Log4Net.MVVMLightViewModels.ItemVMLog
            Clear_Log4Net_MVVMLightViewModels_ItemVMLog();

            // #3.1: Log4Net.MVVMLightViewModels.ExtendedVMLog
            Clear_Log4Net_MVVMLightViewModels_ExtendedVMLog();

            // #4. ClearMain -- CleanUp
            ClearMain();
        }
    }
}

