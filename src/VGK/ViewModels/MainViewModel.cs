using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library;
using Model;
using ModelView.Views;
using VGK.Events;

namespace ModelView.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand InscriptionCommand { get; set; }
        public InscriptionWindow Instance;
        public ICommand ConnexionCommand { get; set; }
        public ConnexionWindow InstanceCO;
        public ICommand JeuxCommand { get; set; }
        public ICommand MainCommand { get; set; }
        public bool LastCommand { get; set; }

        private bool _visibilityMain;
        private bool _visibilityJeux;
        private ConnexionWindow _viewLogin;

        public bool VisibilityJeux
        {
            get
            {
                return _visibilityJeux;
            }

            set
            {
                _visibilityJeux = value;
                OnPropertyChanged("VisibilityJeux");
            }
        }

        public bool VisibilityMain
        {
            get
            {
                return _visibilityMain;
            }

            set
            {
                _visibilityMain = value;
                OnPropertyChanged("VisibilityMain");
            }
        }

        public MainViewModel() : base()
        {

            JeuxCommand = new DelegateCommand(OnClickJeux, CanExecuteJeux);
            MainCommand = new DelegateCommand(OnClickMain, CanExecuteMain);
            VisibilityMain = true;
            VisibilityJeux = false;
            InscriptionCommand = new DelegateCommand(CreateConnexionWindow ,o => Instance == null);
            ConnexionCommand = new DelegateCommand(CreateConnexionWindow);
            _viewLogin = new ConnexionWindow();
        }

        private void CreateInscriptionWindow(object o)
        {
            InscriptionWindow Instance = new InscriptionWindow();
            Instance.ShowDialog();
        }

        private void CreateConnexionWindow(object o)
        {
            ConnexionButtonPressedEvent.GetInstance().Handler += CloseConnexion;
            _viewLogin.ShowDialog();
        }

        private void CloseConnexion(object sender, EventArgs e)
        {
            _viewLogin.Close();
            ConnexionButtonPressedEvent.GetInstance().Handler -= CloseConnexion;
        }
        private bool CanExecuteJeux(object obj)
        {
            
            return true;
            
        }

        private bool CanExecuteMain(object obj)
        {
            
            return true;
            
        }

        private void OnClickMain(object o)
        {
            VisibilityJeux = false;
            VisibilityMain = true;
            
        }
        private void OnClickJeux(object o)
        {
            VisibilityMain = false;
            VisibilityJeux = true;
            
        }
    }
}
