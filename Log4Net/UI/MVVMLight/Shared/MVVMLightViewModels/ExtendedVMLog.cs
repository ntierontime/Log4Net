using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.MVVMLightViewModels
{
    public class ExtendedVMLog: GalaSoft.MvvmLight.ViewModelBase
    {
        public const string EntityName_Static = "Log4Net.Log";

        public string EntityName { get { return EntityName_Static; } }

        public ExtendedVMLog()
            : base()
        {

        }

        public override void Cleanup()
        {
        }
    }
}

