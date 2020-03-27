using Library;
using Model;
using Model.Jeux;
using ModelView.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VGK.Events;

namespace VGK.ViewModels
{
    class EditorViewModel : ViewModelBase
    {
        IDataManager DataManager { get; set; }

        #region private

        private ObservableCollection<Editeur> lesEdit = new ObservableCollection<Editeur>();
        private Editeur _selectedEdit;

        #endregion

        #region public

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand AddCategorieCommand { get; set; }
        public DelegateCommand AddVisibilityCommand { get; private set; }
        public DelegateCommand UpdateVisibilityCommand { get; private set; }
        public DelegateCommand DetailVisibilityCommand { get; private set; }

        public ObservableCollection<Editeur> LesEdit
        {
            get
            {
                return lesEdit;
            }
            set
            {
                lesEdit = value;

                AddCommand.RaiseCanExecuteChanged();
            }

        }

        public Editeur SelectedEdit
        {
            get
            {
                return _selectedEdit;
            }

            set
            {
                _selectedEdit = value;
                OnPropertyChanged("SelectedEdit");

                if (_selectedEdit != null)
                {
                    if (IsAdding && lesEdit.Contains(value))
                    {
                        AddViewButtonPressedEvent.GetInstance().Handler -= CloseAddVisibility;
                        AddViewButtonPressedEvent.GetInstance().Handler -= CloseUpdateVisibility;
                        AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new EditeurEventArgs { Editeur = SelectedEdit.Clone() as Editeur });
                        AddViewButtonPressedEvent.GetInstance().Handler += CloseUpdateVisibility;
                    }

                }
            }
        }

        #endregion

        #region Visibility


        private bool _visibilityEditDetails;
        private bool _isAdding = false; //permet de savoir si des modifications ou de l'ajout sont en cours

        public bool VisibilityEditDetails
        {
            get
            {
                return _visibilityEditDetails;
            }

            set
            {
                _visibilityEditDetails = value;
                OnPropertyChanged("VisibilityEditDetails");
            }
        }

        public bool IsAdding
        {
            get
            {
                return _isAdding;
            }

            set
            {
                _isAdding = value;
                AddVisibilityCommand.RaiseCanExecuteChanged();
                UpdateVisibilityCommand.RaiseCanExecuteChanged();
                RemoveCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        public EditorViewModel(IDataManager dataManager):base()
        {
            UpdateVisibilityCommand = new DelegateCommand(UpdateVisibility, CanUpdateVisibility);
            AddVisibilityCommand = new DelegateCommand(AddVisibility, CanAddVisibility);
            RemoveCommand = new DelegateCommand(RemoveGame, CanRemoveGame);
            DataManager = dataManager;
            foreach (var j in dataManager.LesEdit)
            {
                LesEdit.Add(j);
            }
            if (LesEdit.Count > 0)
            {
                VisibilityEditDetails = true;
                SelectedEdit = LesEdit[0];
            }
            else
            {
                VisibilityEditDetails = false;
                AddVisibilityCommand.Execute(new object());
            }
        }

        #region Commandes

        #region AddVisibility

        public void AddVisibility(object o)
        {
            IsAdding = true;
            VisibilityEditDetails = false;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new EditeurEventArgs { Editeur = new Editeur() { Nom = "", DateCreation = DateTime.Now } });
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new VisibilityEventArgs { Visibility = true });
            AddViewButtonPressedEvent.GetInstance().Handler += CloseAddVisibility;
            SelectedEdit = null;
        }

        private void CloseAddVisibility(object sender, EventArgs e)
        {
            VisibilityEditDetails = true;
            IsAdding = false;
            var args = e as EditeurEventArgs;
            if (args != null)
            {
                if (!lesEdit.Contains(args.Editeur))
                    lesEdit.Add(args.Editeur);
                else
                    MessageBox.Show($"Le jeu {args.Editeur.Nom} a déja été ajouté !");
            }
            AddViewButtonPressedEvent.GetInstance().Handler -= CloseAddVisibility;
            SelectedEdit = lesEdit[lesEdit.Count - 1];
            UpdateVisibilityCommand.RaiseCanExecuteChanged();

        }

        public bool CanAddVisibility(object o)
        {
            if (!IsAdding) return true;
            return false;
        }
        #endregion

        #region UpdateVisibility

        public void UpdateVisibility(object o)
        {
            VisibilityEditDetails = false;
            IsAdding = true;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new EditeurEventArgs { Editeur = SelectedEdit.Clone() as Editeur });
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new VisibilityEventArgs { Visibility = true });
            AddViewButtonPressedEvent.GetInstance().Handler += CloseUpdateVisibility;
        }

        private void CloseUpdateVisibility(object sender, EventArgs e)
        {
            VisibilityEditDetails = true;
            IsAdding = false;
            var args = e as EditeurEventArgs;
            if (args != null)
            {
                LesEdit[LesEdit.IndexOf(SelectedEdit)] = args.Editeur;
                SelectedEdit = args.Editeur;
            }
            AddViewButtonPressedEvent.GetInstance().Handler -= CloseUpdateVisibility;
        }

        public bool CanUpdateVisibility(object o)
        {
            if (SelectedEdit == null) return false;
            if (!IsAdding)
                return true;
            return false;
        }
        #endregion

        #region Remove
        public void RemoveGame(object o)
        {
            int indexEditeur = lesEdit.IndexOf(SelectedEdit);
            lesEdit.Remove(SelectedEdit);
            if (lesEdit.Count > 0)
                if (lesEdit.Count == indexEditeur)
                    SelectedEdit = lesEdit[indexEditeur - 1];
                else
                    SelectedEdit = lesEdit[indexEditeur];
            else
            {
                AddVisibilityCommand.Execute(o);
                RemoveCommand.RaiseCanExecuteChanged();
            }

        }

        public bool CanRemoveGame(object o)
        {
            if (IsAdding) return false;
            if (SelectedEdit != null)
                if (!lesEdit.Contains(SelectedEdit))
                    return false;
            return true;
        }
        #endregion

        #endregion
    }
}
