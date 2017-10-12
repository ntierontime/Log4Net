using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Log4Net.UWPApp
{
    public class DispatcherHelperWrapper : Framework.Xaml.IDispatcherHelperWrapper
    {
        public void CheckBeginInvokeOnUI(Action action)
        {
            Device.BeginInvokeOnMainThread(action);
            //DispatcherHelper.CheckBeginInvokeOnUI(action);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
            //DispatcherHelper.Initialize();
        }

        public void Reset()
        {
            throw new NotImplementedException();
            //DispatcherHelper.Reset();
        }
    }
}

