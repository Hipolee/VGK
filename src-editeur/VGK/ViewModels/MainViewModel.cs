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

namespace ModelView.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand InscriptionCommand { get; set; }
        public InscriptionWindow Instance;
        public ICommand ConnexionCommand { get; set; }
        public ConnexionWindow InstanceCO;
        public ICommand JeuxCommand { get; set; }
        public ICommand EditeurCommand { get; set; }
        public ICommand MainCommand { get; set; }
        public bool LastCommand { get; set; }

        private bool _visibilityEdit;
        private bool _visibilityMain;
        private bool _visibilityJeux;
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

        public bool VisibilityEdit
        {
            get
            {
                return _visibilityEdit;
            }
            set
            {
                _visibilityEdit = value;
                OnPropertyChanged("VisibilityEdit");
            }
        }

        public MainViewModel() : base()
        {
            EditeurCommand = new DelegateCommand(OnClickEdit, CanExecuteEdit);
            JeuxCommand = new DelegateCommand(OnClickJeux, CanExecuteJeux);
            MainCommand = new DelegateCommand(OnClickMain, CanExecuteMain);
            VisibilityMain = true;
            VisibilityJeux = false;
            VisibilityEdit = false;
            InscriptionCommand = new DelegateCommand(CreateConnexionWindow ,o => Instance == null);
            ConnexionCommand = new DelegateCommand(CreateConnexionWindow, o => true);
        }

        private void CreateInscriptionWindow(object o)
        {
            InscriptionWindow Instance = new InscriptionWindow();
            Instance.ShowDialog();
        }

        private void CreateConnexionWindow(object o)
        {
            ConnexionWindow Instance = new ConnexionWindow();
            Instance.ShowDialog();
        }
        private bool CanExecuteEdit(object obj)
        {

            return true;

        }

        private bool CanExecuteJeux(object obj)
        {
            
            return true;
            
        }

        private bool CanExecuteMain(object obj)
        {
            
            return true;
            
        }

        private void OnClickEdit(object o)
        {
            VisibilityJeux = false;
            VisibilityMain = false;
            VisibilityEdit = true;
        }

        private void OnClickMain(object o)
        {
            VisibilityEdit = false;
            VisibilityJeux = false;
            VisibilityMain = true;

        }
        private void OnClickJeux(object o)
        {
            VisibilityEdit = false;
            VisibilityMain = false;
            VisibilityJeux = true;
            
        }
    }
}
