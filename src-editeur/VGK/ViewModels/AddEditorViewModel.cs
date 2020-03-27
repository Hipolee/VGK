using Library;
using Microsoft.Win32;
using Model.Jeux;
using ModelView.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGK.Events;

namespace VGK.ViewModels
{
    class AddEditorViewModel : ViewModelBase
    {
        #region private
        private Editeur _addedEdit;
        private bool _isVisible;
        #endregion

        #region Public
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand UploadImageCommand { get; private set; }

        public Editeur AddedEdit
        {
            get
            {
                return _addedEdit;
            }

            set
            {
                _addedEdit = value;
                OnPropertyChanged("AddedEdit");
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        #endregion

        public AddEditorViewModel()
        {

            IsVisible = false;
            CloseCommand = new DelegateCommand(CloseAddVisibility);
            AddCommand = new DelegateCommand(AddEdit, CanAddEdit);
            UploadImageCommand = new DelegateCommand(UploadImage);
            AddViewButtonPressedEvent.GetInstance().Handler += OnEventReceived;
        }

        private void AddedEditPropertyChanged(object obj, PropertyChangedEventArgs e)
        {
            Editeur editeur = obj as Editeur;
            if (editeur == null) return;
            AddCommand.RaiseCanExecuteChanged();
        }

        #region Commandes

        private void CloseAddVisibility(object obj)
        {
            IsVisible = false;
            AddedEdit.PropertyChanged -= AddedEditPropertyChanged;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty as EditeurEventArgs);
        }

        private void AddEdit(object obj)
        {
            IsVisible = false;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new EditeurEventArgs { Editeur = AddedEdit });
        }

        private bool CanAddEdit(object obj)
        {
            if (AddedEdit != null)
            {
                if (string.IsNullOrWhiteSpace(AddedEdit.Nom)) return false;
                if (AddedEdit.DateCreation > DateTime.Now) return false;
            }
            return true;
        }

        private void UploadImage(object obj)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Choisissez une image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                AddedEdit.ImagePath = new Uri(op.FileName);
            }
        }
        #endregion

        private void OnEventReceived(object sender, EventArgs e)
        {
            var argsEdit = e as EditeurEventArgs;
            var argsVisibility = e as VisibilityEventArgs;
            if (argsEdit != null)
            {
                AddedEdit = argsEdit.Editeur;
                AddedEdit.PropertyChanged += AddedEditPropertyChanged;
                AddCommand.RaiseCanExecuteChanged();
            }
            if (argsVisibility != null)
            {
                IsVisible = argsVisibility.Visibility;
            }
        }
    }
}
