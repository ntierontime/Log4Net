/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Log4Net.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
  
  OR (WPF only):
  
  xmlns:vm="clr-namespace:Log4Net.ViewModels"
  DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
*/

namespace Log4Net.ViewModels
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
    ///     &lt;vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Log4Net.ViewModels"
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
    /// xmlns:vm="clr-namespace:Log4Net.ViewModels"
    /// DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
    /// </code>
    /// </summary>
    public class ViewModelLocator
    {
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

        #region Log4Net.ViewModels.MainViewModel

        private static Log4Net.ViewModels.MainViewModel _main;

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static Log4Net.ViewModels.MainViewModel MainStatic
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
        public Log4Net.ViewModels.MainViewModel Main
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
                _main = new Log4Net.ViewModels.MainViewModel();
            }
        }

        #endregion Log4Net.ViewModels.MainViewModel


#if SILVERLIGHT && !WINDOWS_PHONE
        #region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

		#region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM
#endif


#if NETFX_CORE
        #region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

		#region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM
#endif


#if WINDOWS_PHONE && WINDOWS_PHONE
        #region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

		#region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM
#endif


#if !WINDOWS_PHONE && !SILVERLIGHT && !NETFX_CORE
        #region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

		#region MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM

        private static Log4Net.ViewModels.WPCommonOfLogVM m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
        public static Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static
        {
            get
            {
                if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
                {
                    CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM();
                }

                return m_Log4Net_ViewModels_WPCommonOfLogCollectionVM;
            }
        }

        public Log4Net.ViewModels.WPCommonOfLogVM Log4Net_ViewModels_WPCommonOfLogCollectionVM
        {
            get
            {
                return Log4Net_ViewModels_WPCommonOfLogCollectionVM_Static;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM != null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM.Cleanup();
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Log4Net_ViewModels_WPCommonOfLogCollectionVM property.
        /// </summary>
        public static void CreateLog4Net_ViewModels_WPCommonOfLogCollectionVM()
        {
            if (m_Log4Net_ViewModels_WPCommonOfLogCollectionVM == null)
            {
                m_Log4Net_ViewModels_WPCommonOfLogCollectionVM = new Log4Net.ViewModels.WPCommonOfLogVM();
            }
        }

        #endregion MVVMViewModel: Log4Net.ViewModels.WPCommonOfLogVM
#endif



        #region Cleanup()

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {


#if SILVERLIGHT && !WINDOWS_PHONE
            Clear_Log4Net_ViewModels_WPCommonOfLogVM();
            Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM();
#endif


#if NETFX_CORE
            Clear_Log4Net_ViewModels_WPCommonOfLogVM();
            Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM();
#endif


#if WINDOWS_PHONE && WINDOWS_PHONE
            Clear_Log4Net_ViewModels_WPCommonOfLogVM();
            Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM();
#endif


#if !WINDOWS_PHONE && !SILVERLIGHT && !NETFX_CORE
            Clear_Log4Net_ViewModels_WPCommonOfLogVM();
            Clear_Log4Net_ViewModels_WPCommonOfLogCollectionVM();
#endif



            ClearMain();
        }

        #endregion Cleanup()

    }
}

