using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace Log4Net.WinStoreApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
			
            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer, Framework.CommonBLLEntities.BusinessLogicLayerContextContainerCommon>();

            Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Register<Log4Net.WcfContracts.IBusinessLogicLayerFactoryAsyn, Log4Net.WcfClientBLL.WcfClientFactoryAsyn>();

            Framework.CommonBLLEntities.BusinessLogicLayerMemberShip _BusinessLogicLayerMemberShip = new Framework.CommonBLLEntities.BusinessLogicLayerMemberShip();
            Framework.CommonBLLEntities.SessionVariablesCommon.BusinessLogicLayerContext = new Framework.CommonBLLEntities.BusinessLogicLayerContext(_BusinessLogicLayerMemberShip);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a Framework.Xaml.SuspensionManager key                                
                Framework.Xaml.SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await Framework.Xaml.SuspensionManager.RestoreAsync();
                    }
                    catch (Framework.Xaml.SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(Log4Net.WinStoreApp.GroupedItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            // The MVVM Light Messenger In-Depth: http://msdn.microsoft.com/en-us/magazine/dn745866.aspx

			InitializeMainMenuTree();

            InitializeNavigationSettingCollectionInMainViewModel();

            Messenger.Default.Register<Framework.UIActionStatusMessage>(
                this,
                message =>
                {
                    if (Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Count(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus) > 0)
                    {
                        var navigationSetting = Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.FirstOrDefault(t => t.SourceTypeFullName == message.SourceTypeFullName && t.SenderView == message.SenderView && t.UIAction == message.UIAction && t.UIActionStatus == message.UIActionStatus);
                        if (navigationSetting != null)
                        {
                            if (navigationSetting.NextUIAction == Framework.UIAction.GoBack)
                            {
                                rootFrame.GoBack();
                            }
                            else if (navigationSetting.NextUIAction == Framework.UIAction.Navigate)
                            {
                                rootFrame.Navigate(navigationSetting.TargetPageType);
                            }
                        }
                    }
                });
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await Framework.Xaml.SuspensionManager.SaveAsync();
            deferral.Complete();
        }


        private static void InitializeMainMenuTree()
        {
// 1.1 Log4Net.Log
            Log4Net.ViewModels.ViewModelLocator.MainStatic.MainMenuTree.AddSubMenuTreeItem("Common of Log4Net.Log", Log4Net.Resources.UIStringResourcePerApp.Title_Of_Common_of_Log4Net_Log, Log4Net.Resources.UIStringResourcePerApp.Title_Of_Common_of_Log4Net_Log, Log4Net.Resources.UIStringResourcePerApp.Description_Of_Common_of_Log4Net_Log, null, null, Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Search, Framework.UIActionStatus.Launch);

        }

        #region InitializeNavigationSettingCollectionInMainViewModel()

        private static void InitializeNavigationSettingCollectionInMainViewModel()
        {
            #region Workspaces with MasterTypeFullName
Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Search,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WinStoreApp.Pages.WPCommonOfLog));

            #endregion Workspaces with MasterTypeFullName
#region Create, Update and Delete, Details of Log4Net.Log

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.ViewDetails, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Create, Framework.UIAction.Create, Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Close, Framework.UIAction.GoBack, null, null);

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Create, Framework.UIAction.Create,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WinStoreApp.Pages.WPCommonOfLog));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Edit, Framework.UIAction.Update,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WinStoreApp.Pages.WPCommonOfLog));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Delete, Framework.UIAction.Delete,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/WPCommonOfLog.xaml", typeof(Log4Net.WinStoreApp.Pages.WPCommonOfLog));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.SelectionChanged,  Framework.UIActionStatus.Success, Framework.UIAction.Navigate, "/Pages/Log/Details.xaml", typeof(Log4Net.WinStoreApp.Pages.Log.Details));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_SearchResult, Framework.UIAction.Create,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Create.xaml", typeof(Log4Net.WinStoreApp.Pages.Log.Create));

            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.Update,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Edit.xaml", typeof(Log4Net.WinStoreApp.Pages.Log.Edit));
            Log4Net.ViewModels.ViewModelLocator.MainStatic.NavigationSettingCollection.Add(Log4Net.ViewModels.WPCommonOfLogVM.EntityName_Static, Log4Net.ViewModels.WPCommonOfLogVM.ViewName_Details, Framework.UIAction.Delete,  Framework.UIActionStatus.Launch, Framework.UIAction.Navigate, "/Pages/Log/Delete.xaml", typeof(Log4Net.WinStoreApp.Pages.Log.Delete));

            #endregion Create, Update and Delete, Details of Log4Net.Log

        }

        #endregion InitializeNavigationSettingCollectionInMainViewModel()
    }
}