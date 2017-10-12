using System;

namespace Framework.Xaml
{
    public interface IDispatcherHelperWrapper
    {
        // Summary:
        //     Executes an action on the UI thread. If this method is called from the UI thread,
        //     the action is executed immendiately. If the method is called from another thread,
        //     the action will be enqueued on the UI thread's dispatcher and executed asynchronously.
        //     For additional operations on the UI thread, you can get a reference to the UI
        //     thread's dispatcher thanks to the property GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        //     .
        //
        // Parameters:
        //   action:
        //     The action that will be executed on the UI thread.
        void CheckBeginInvokeOnUI(Action action);
        //
        // Summary:
        //     This method should be called once on the UI thread to ensure that the GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        //     property is initialized.
        //     In a Silverlight application, call this method in the Application_Startup event
        //     handler, after the MainPage is constructed.
        //     In WPF, call this method on the static App() constructor.
        void Initialize();
        //
        // Summary:
        //     Resets the class by deleting the GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher
        void Reset();
    }

    public class IDispatcherHelperWrapperService
    {
        public static IDispatcherHelperWrapper GetDispatcherHelper()
        {
            var instance = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Framework.Xaml.IDispatcherHelperWrapper>();
            return instance;
        }
    }
}

