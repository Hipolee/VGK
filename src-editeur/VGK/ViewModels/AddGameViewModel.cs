using Library;
using Microsoft.Win32;
using Model.Jeux;
using ModelView.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using VGK.Events;

namespace ModelView.ViewModels
{
    class AddGameViewModel : ViewModelBase
    {
        #region private
        private Jeu _addedJeu;
        private bool _isVisible;
        #endregion

        #region Public
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand UploadImageCommand { get; private set; }  
        public Array LesCategories { get; set; } = Enum.GetValues(typeof(Categorie));
        public Jeu AddedJeu
        {
            get
            {
                return _addedJeu;
            }

            set
            {
                _addedJeu = value;
                OnPropertyChanged("AddedJeu");
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
        public AddGameViewModel()
        {
            
            IsVisible = false;
            CloseCommand = new DelegateCommand(CloseAddVisibility);
            AddCommand = new DelegateCommand(AddGame,CanAddGame);
            UploadImageCommand = new DelegateCommand(UploadImage);
            AddViewButtonPressedEvent.GetInstance().Handler += OnEventReceived;
        }
        // Permet de rafraîchir le bouton de validation lorsque l'on modifie une proppriétée du jeu
        private void AddedJeuPropertyChanged(object obj, PropertyChangedEventArgs e)
        {
            Jeu jeu = obj as Jeu;
            if (jeu == null) return;
            AddCommand.RaiseCanExecuteChanged();
        }

        #region Commandes
        //Ferme la visibilité sans retourner le jeu à ajouter ou modifier
        private void CloseAddVisibility(object obj)
        {
            IsVisible = false;
            AddedJeu.PropertyChanged -= AddedJeuPropertyChanged;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(EventArgs.Empty as JeuEventArgs);
        }

        //ferme la visibilité en retournant le jeu à ajouter ou modifier
        private void AddGame(object obj)
        {
            IsVisible = false;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new JeuEventArgs { Jeu = AddedJeu });
        }

        
        // Vérifie que le titre et l'éditeur ne sont pas vides, que la date n'est pas future, 
        // que les catégories ne sont pas les mêmes et que le jeu comporte au moins une catégorie
        private bool CanAddGame(object obj)
        {
            if(AddedJeu!=null)
            {
                if (string.IsNullOrWhiteSpace(AddedJeu.Titre)) return false;
                if (string.IsNullOrWhiteSpace(AddedJeu.Editeur)) return false;
                if (AddedJeu.Date > DateTime.Now) return false;
                if (AddedJeu.Categorie1 == AddedJeu.Categorie2) return false;
                if (AddedJeu.Categorie1 == Categorie.Aucune) return false;
            }
            return true;
        }

        //Récupère l'URI d'une image chargée
        private void UploadImage(object obj)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Choisissez une image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                AddedJeu.ImagePath = new Uri(op.FileName);
            }
        }
        #endregion

        private void OnEventReceived(object sender, EventArgs e)
        {
            var argsJeu = e as JeuEventArgs;
            var argsVisibility = e as VisibilityEventArgs;
            if (argsJeu != null)
            {
                AddedJeu = argsJeu.Jeu;
                AddedJeu.PropertyChanged += AddedJeuPropertyChanged;
                AddCommand.RaiseCanExecuteChanged();
            }
            if (argsVisibility != null)
            {
                IsVisible = argsVisibility.Visibility;
            }   
        }

        
    }
}
