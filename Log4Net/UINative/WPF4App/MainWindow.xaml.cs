using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.WPF4App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool _shutdown;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => Log4Net.MVVMLightViewModels.ViewModelLocator.Cleanup();

            InitializeNavigationSettingCollectionInMainViewModel();

            Messenger.Default.Register<Framework.UIActionStatusMessage>(
                this,
                message =>
                {
                    if (Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Exists(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus))
                    {
                        var navigationSetting = Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.FirstOrDefault(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus);
                        if (navigationSetting != null)
                        {
                            if (navigationSetting.UIAction == Framework.UIAction.Search && navigationSetting.UIActionStatus == Framework.UIActionStatus.Starting)
                            {
                                Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.IsBusy = true;
                            }
                            else
                            {
                                Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.IsBusy = false;
                            }

                            if (navigationSetting.NextUIAction == Framework.UIAction.GoBack)
                            {
                                _mainFrame.GoBack();
                            }
                            else if (navigationSetting.NextUIAction == Framework.UIAction.Navigate)
                            {
                                _mainFrame.Navigate(new Uri(navigationSetting.TargetUrl, UriKind.Relative));
                            }
                        }
                    }
                });
        }

        private static void InitializeNavigationSettingCollectionInMainViewModel()
        {
            #region Workspaces with MasterTypeFullName

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.MVVMLightViewModels.WPCommonOfLogVM.ViewName_Static, Framework.UIAction.Search,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.Log.WPCommonOfLog));

            #endregion Workspaces with MasterTypeFullName

            #region Create, Update and Delete, Details of Log4Net.Log

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.ViewDetails, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Create, Framework.UIAction.Create, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Create, Framework.UIAction.Create,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.Log.WPCommonOfLog));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.Log.WPCommonOfLog));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.Log.WPCommonOfLog));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.MVVMLightViewModels.WPCommonOfLogVM.ViewName_Static, Framework.UIAction.SelectionChanged,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/Details.xaml", typeof(Log4Net.WPF4App.Pages.Log.Details));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Copy,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.WPF4App.Pages.Log.Create));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Create, Framework.UIAction.Create,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.WPF4App.Pages.Log.Create));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.ViewDetails,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Details.xaml", typeof(Log4Net.WPF4App.Pages.Log.Details));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Update,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Edit.xaml", typeof(Log4Net.WPF4App.Pages.Log.Edit));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Delete,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Delete.xaml", typeof(Log4Net.WPF4App.Pages.Log.Delete));

            #endregion Create, Update and Delete, Details of Log4Net.Log

        }

        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel) return;
            e.Cancel = !_shutdown && Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.QuitConfirmationEnabled;
            if (_shutdown) return;

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = Framework.Resx.UIStringResource.Quit,
                NegativeButtonText = Framework.Resx.UIStringResource.Cancel,
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.ShowMessageAsync(Framework.Resx.UIStringResource.QuitApplication,
                Framework.Resx.UIStringResource.QuitApplicationMessage,
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;

            if (_shutdown)
            {
                Log4Net.MVVMLightViewModels.ViewModelLocator.Cleanup();
                Application.Current.Shutdown();
            }
        }
    }
}

