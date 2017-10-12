/*
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Log4Net.MVVMLightViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AccountViewModel : ViewModelBase
    {
        #region fields

        /// <summary>
        /// current logon status
        /// </summary>
        public static bool IsLoggedOn = false;

        #endregion fields

        #region constructor

        /// <summary>
        /// Initializes a new instance of the AccountViewModel class.
        /// </summary>
        public AccountViewModel()
        {
        }

        #endregion constructor

        #region LogonCommand

        /// <summary>
        /// field of LogOnModel
        /// </summary>
        private Framework.LogOnModel m_LogOnModel;
        /// <summary>
        /// LogOnModel
        /// </summary>
        public Framework.LogOnModel LogOnModel
        {
            get { return m_LogOnModel; }
            set
            {
                m_LogOnModel = value;
                RaisePropertyChanged("LogOnModel");
            }
        }

        /// <summary>
        /// LogonCommand
        /// </summary>
        public RelayCommand LogonCommand { get; private set; }

        /// <summary>
        /// Logon action.
        /// </summary>
        private void Logon()
        {
            var_AuthenticationServiceAsynClient = new ??();
            _AuthenticationServiceAsynClient.LoginCompleted += new System.EventHandler<??.LoginCompletedEventArgs>(_AuthenticationServiceAsynClient_LoginCompleted);
            _AuthenticationServiceAsynClient.LoginAsync(this.m_LogOnModel.UserName, this.m_LogOnModel.Password, null, false);

        }

        void _AuthenticationServiceAsynClient_LoginCompleted(object sender, ??.LoginCompletedEventArgs e)
        {
            IsLoggedOn = e.Result;
        }

        /// <summary>
        /// Determines whether you can Logon.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        private bool CanLogon()
        {
            return this.m_LogOnModel != null;
        }

        #endregion LogonCommand

    }
}
*/

