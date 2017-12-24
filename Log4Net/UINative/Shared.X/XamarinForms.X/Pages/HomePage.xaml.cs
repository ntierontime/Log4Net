using System;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace Log4Net.XamarinForms.Pages {
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();

            // The MVVM Light Messenger In-Depth: http://msdn.microsoft.com/en-us/magazine/dn745866.aspx

            InitializeNavigationSettingCollectionInMainViewModel();

            Messenger.Default.Register<Framework.UIActionStatusMessage>(
                this,
                message =>
                {
                    var dispatcherHelper = Framework.Xaml.IDispatcherHelperWrapperService.GetDispatcherHelper();

                    dispatcherHelper.CheckBeginInvokeOnUI((Action)delegate ()
                    {
                        if (message.UIAction == Framework.UIAction.Home)
                        {
                            App.NavigationPage.Navigation.PopToRootAsync();
                        }
                        else if (message.UIAction == Framework.UIAction.GoBack)
                        {
                            App.NavigationPage.Navigation.PopAsync();
                        }
                        else if (Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Exists(t => t.SourceTypeFullName == message.SourceTypeFullName && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus))
                        {
                            var navigationSetting = Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.FirstOrDefault(t => t.SourceTypeFullName == message.SourceTypeFullName && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus);
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

                                if (navigationSetting.NextUIAction == Framework.UIAction.Navigate)
                                {
                                    var page = Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.GetPageInstanceSingleton(navigationSetting.TargetPageType);

                                    App.NavigationPage.Navigation.PushAsync((Page)page);
                                }
                                else if (navigationSetting.NextUIAction == Framework.UIAction.GoBack)
                                {
                                    App.NavigationPage.Navigation.PopAsync();
                                }
                            }
                        }
                    });
                });
        }

        private static void InitializeNavigationSettingCollectionInMainViewModel()
        {
            // 1. Common Workspace

            // Log4Net.Log.TabbedSearch
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.MVVMLightViewModels.WPCommonOfLogVM.ViewName_Static, Framework.UIAction.Search,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/WPTabbedCommonOfLog.xaml", typeof(Log4Net.XamarinForms.Pages.Log.WPTabbedCommonOfLog));

            #region Create, Update and Delete, Details of Log4Net.Log

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Create, Framework.UIAction.Create, Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/WPTabbedCommonOfLog.xaml", typeof(Log4Net.XamarinForms.Pages.Log.WPTabbedCommonOfLog));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Success, Framework.UIAction.GoBack, null, null);
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/WPTabbedCommonOfLog.xaml", typeof(Log4Net.XamarinForms.Pages.Log.WPTabbedCommonOfLog));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Copy,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.XamarinForms.Pages.Log.Create));

            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Create, Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.XamarinForms.Pages.Log.Create));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.ViewDetails, Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Details.xaml", typeof(Log4Net.XamarinForms.Pages.Log.Details));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Update,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Edit.xaml", typeof(Log4Net.XamarinForms.Pages.Log.Edit));
            Log4Net.MVVMLightViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.MVVMLightViewModels.ItemVMLog.EntityName_Static, Log4Net.MVVMLightViewModels.ItemVMLog.ViewName_Details, Framework.UIAction.Delete,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Delete.xaml", typeof(Log4Net.XamarinForms.Pages.Log.Delete));

            #endregion Create, Update and Delete, Details of Log4Net.Log

        }
    }
}

