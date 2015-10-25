using System.Windows;
using System.Collections.Generic;
using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.WPF4App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => Log4Net.ViewModels.ViewModelLocator.Cleanup();

            // The MVVM Light Messenger In-Depth: http://msdn.microsoft.com/en-us/magazine/dn745866.aspx

			InitializeMainMenuTree();

            InitializeNavigationSettingCollectionInMainViewModel();

            Messenger.Default.Register<Framework.UIActionStatusMessage>(
                this,
                message =>
                {
                    if (Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Exists(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus))
                    {
                        var navigationSetting = Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.FirstOrDefault(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus);
                        if (navigationSetting != null)
                        {
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


        private static void InitializeMainMenuTree()
        {
// 1.1 Log4Net.Log
            Log4Net.ViewModels.ViewModelLocator.MainStatic.MainMenuTree.AddSubMenuTreeItem("Common of Log4Net.Log", Log4Net.Resources.UIStringResourcePerApp.Common_of_Log4Net_Log, Log4Net.Resources.UIStringResourcePerApp.Common_of_Log4Net_Log, Log4Net.Resources.UIStringResourcePerApp.Description_Of_Common_of_Log4Net_Log, null, null, Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Search, Framework.UIActionStatus.Launch);

        }

        private static void InitializeNavigationSettingCollectionInMainViewModel()
        {
			#region Workspaces with MasterTypeFullName

Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Search,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.WPCommonOfLog));


			#endregion Workspaces with MasterTypeFullName

#region Create, Update and Delete, Details of Log4Net.Log

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.ViewDetails, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Create, Framework.UIAction.Create, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Create, Framework.UIAction.Create,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.WPCommonOfLog));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.WPCommonOfLog));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WPF4App.Pages.WPCommonOfLog));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.SelectionChanged,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/Details.xaml", typeof(Log4Net.WPF4App.Pages.Log.Details));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.Copy,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.WPF4App.Pages.Log.Create));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Create,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.WPF4App.Pages.Log.Create));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.Update,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Edit.xaml", typeof(Log4Net.WPF4App.Pages.Log.Edit));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.Delete,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Delete.xaml", typeof(Log4Net.WPF4App.Pages.Log.Delete));

            #endregion Create, Update and Delete, Details of Log4Net.Log

        }
    }
}