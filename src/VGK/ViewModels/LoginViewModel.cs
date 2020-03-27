using Content.Utilisateurs;
using Library;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGK.Events;

namespace ModelView.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        #region private
        private string _username;
        private string _password;

        #endregion

        #region public
        public DelegateCommand LoginCommand { get; private set; }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private void OnLogin(object obj)
        {
            if (UserManager.CheckUser(new UtilisateurCommun(Username, Password)))
            {
                CurrentUser = new UtilisateurCommun(Username, Password);
                ConnexionButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty);
            }
            

        }

        private bool CanLogin(object o)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)) return false;
            return true;
        }
    }
}
