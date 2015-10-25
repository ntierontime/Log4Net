using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.ViewModels
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
        public string Welcome
        {
            get
            {
                return Framework.Resources.UIStringResource.Common_WelcomeToNTIERONTIME;
            }
        }

        public Framework.Xaml.MenuTreeItem MainMenuTree { get; set; }

        public Framework.MenuTreeItem m_SelectedMenuTreeItem;
        public Framework.MenuTreeItem SelectedMenuTreeItem { 
            get
            {
                return this.m_SelectedMenuTreeItem;
            }
            set 
            {
                this.m_SelectedMenuTreeItem = value;
                RaisePropertyChanged("SelectedMenuTreeItem");
            }
        }

        public RelayCommand MenuItemSelectedCommand { get; private set; }

        public void MenuItemSelected()
        {
            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(this.SelectedMenuTreeItem.SourceTypeFullName, this.SelectedMenuTreeItem.SenderView, this.SelectedMenuTreeItem.UIAction, this.SelectedMenuTreeItem.UIActionStatus));
        }

        public Framework.NavigationSettingCollection NavigationSettingCollection { get; set; }

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

			//#region 1. Initialize Menu

			this.MainMenuTree = new Framework.Xaml.MenuTreeItem();

			//#endregion 1. Initialize Menu

            //#region 2. Initialize NavigationSettingCollection

            this.NavigationSettingCollection = new Framework.NavigationSettingCollection();

            //#endregion 2. Initialize NavigationSettingCollection

            //#region 3. Initialize MenuItemSelectedCommand

            this.MenuItemSelectedCommand = new RelayCommand(MenuItemSelected);

            //#endregion 3. Initialize MenuItemSelectedCommand
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}

