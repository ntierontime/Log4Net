using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.WPF4App
{
    public class DispatcherHelperWrapper : Framework.Xaml.IDispatcherHelperWrapper
    {
        public void CheckBeginInvokeOnUI(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }

        public void Initialize()
        {
            DispatcherHelper.Initialize();
        }

        public void Reset()
        {
            DispatcherHelper.Reset();

        }
    }
}

