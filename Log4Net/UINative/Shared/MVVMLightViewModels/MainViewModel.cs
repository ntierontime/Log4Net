using System;
using System.Collections.Concurrent;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.MVVMLightViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the page instance singleton.
        /// For Xamarin.Forms
        /// Not for WPF
        /// </summary>
        /// <value>
        /// The page instance singleton.
        /// </value>
        ConcurrentDictionary<Type, object> PageInstanceSingleton { get; set; }

        public bool QuitConfirmationEnabled { get; set; }
        public bool IsBusy { get; set; }

        public string Welcome
        {
            get
            {
                return Framework.Resx.UIStringResource.Common_WelcomeToNTIERONTIME;
            }
        }

        public RelayCommand GoHomeCommand { get; private set; }
        public void GoHome()
        {
            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(null, null, Framework.UIAction.Home, Framework.UIActionStatus.Launch));
        }

        public RelayCommand GoBackCommand { get; private set; }
        public void GoBack()
        {
            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(null, null, Framework.UIAction.GoBack, Framework.UIActionStatus.Launch));
        }

        public Framework.NavigationSettingCollection NavigationSettingCollection { get; set; }
        public Framework.NameValueCollection PreDefinedDateTimeRangeList { get; }
        public Framework.NameValueCollection PredefinedBooleanSelectedValueList { get; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }

            // 1. Initialize NavigationSettingCollection

            this.NavigationSettingCollection = new Framework.NavigationSettingCollection();

            PageInstanceSingleton = new ConcurrentDictionary<Type, object>();

            // 2. Command
            this.GoHomeCommand = new RelayCommand(GoHome);
            this.GoBackCommand = new RelayCommand(GoBack);

            // 3. PreDefinedDateTimeRangeList and PredefinedBooleanSelectedValueList

            this.PreDefinedDateTimeRangeList = Framework.EntityContracts.QuerySystemDateTimeRangeCriteria.GetList(null);
            this.PredefinedBooleanSelectedValueList = Framework.EntityContracts.QuerySystemBooleanEqualsCriteria.GetList(null);

            this.IsBusy = false;
        }

        public object GetPageInstanceSingleton(Type pageType)
        {
            if (PageInstanceSingleton.ContainsKey(pageType))
                return PageInstanceSingleton[pageType];

            try
            {
                var instance = Activator.CreateInstance(pageType);
                PageInstanceSingleton.TryAdd(pageType, instance);
                return instance;
            }
            catch
            {
                return null;
            }
        }

        //public override void Cleanup()
        //{
        //    // Clean up if needed
        //
        //    base.Cleanup();
        //}
    }
}

