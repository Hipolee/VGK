using Library;
using Model.Jeux;
using System;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using ModelView.Views;
using ModelView.Events;
using VGK.Events;
using System.Windows;

namespace ModelView.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        IDataManager DataManager { get; set; }

        #region private
        private ObservableCollection<Jeu> lesJeux = new ObservableCollection<Jeu>();
        private Jeu _selectedJeu;

        #endregion

        #region public
        
        public Categorie SelectedCategorie { get; set; }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand AddCategorieCommand { get; set; }
        public DelegateCommand AddVisibilityCommand { get; private set; }
        public DelegateCommand UpdateVisibilityCommand { get; private set; }
        public DelegateCommand DetailVisibilityCommand { get; private set; }

        public ObservableCollection<Jeu> LesJeux
        {
            get
            {
                return lesJeux;
            }
            set
            {
                lesJeux = value;
                
                AddCommand.RaiseCanExecuteChanged();
            }

        }

        public Jeu SelectedJeu
        {
            get
            {
                return _selectedJeu;
            }

            set
            {
                _selectedJeu = value;
                OnPropertyChanged("SelectedJeu");
                
                if (SelectedJeu != null)
                {
                    if (IsAdding&&lesJeux.Contains(value))
                    {
                        AddViewButtonPressedEvent.GetInstance().Handler -= CloseAddVisibility;
                        AddViewButtonPressedEvent.GetInstance().Handler -= CloseUpdateVisibility;
                        AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new JeuEventArgs { Jeu = SelectedJeu.Clone() as Jeu });
                        AddViewButtonPressedEvent.GetInstance().Handler += CloseUpdateVisibility;
                    }

                }
            }
        }

        #endregion
       
        #region Visibility

        
        private bool _visibilityGameDetails;
        private bool _isAdding = false; //permet de savoir si des modifications ou de l'ajout sont en cours

        public bool VisibilityGameDetails
        {
            get
            {
                return _visibilityGameDetails;
            }

            set
            {
                _visibilityGameDetails = value;
                OnPropertyChanged("VisibilityGameDetails");
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

        public GameViewModel(IDataManager dataManager):base()
        {
            UpdateVisibilityCommand = new DelegateCommand(UpdateVisibility, CanUpdateVisibility);
            AddVisibilityCommand = new DelegateCommand(AddVisibility, CanAddVisibility);
            RemoveCommand = new DelegateCommand(RemoveGame, CanRemoveGame);
            DataManager = dataManager;
            foreach(var j in dataManager.LesJeux)
            {
                lesJeux.Add(j);
            }

            //Le premier jeu est sélectionné si il y a des éléments dans le master detail, sinon l'ajout est déclenché
            if (lesJeux.Count > 0)
            {
                VisibilityGameDetails = true;
                SelectedJeu = lesJeux[0];
            }
            else
            {
                VisibilityGameDetails = false;
                AddVisibilityCommand.Execute(new object());
            } 
        }

        #region Commandes

        #region AddVisibility

        //une base de jeu à ajouter est envoyée au ViewModel d'ajout, un changement de vue est envoyé
        public void AddVisibility(object o)
        {
            IsAdding = true;
            VisibilityGameDetails = false;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new JeuEventArgs { Jeu = new Jeu() { Titre="",Date = DateTime.Now }});
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new VisibilityEventArgs { Visibility = true });
            AddViewButtonPressedEvent.GetInstance().Handler += CloseAddVisibility;
            SelectedJeu = null;
        }

        //lorsque l'ajout est terminé, si il a été validé le jeu est ajouté à la liste des jeux
        //sauf si il est déja présent dans la liste auquel cas cela est notifié par un message d'erreur,
        //si l'ajout n'est pas validé alors la liste des jeux n'est pas modifiée
        private void CloseAddVisibility(object sender, EventArgs e)
        {
            VisibilityGameDetails = true;
            IsAdding = false;
            var args = e as JeuEventArgs;
            if(args != null)
            {
                if (!lesJeux.Contains(args.Jeu)) 
                    lesJeux.Add(args.Jeu);
                else
                    MessageBox.Show($"Le jeu {args.Jeu.Titre} a déja été ajouté !");
            }
            AddViewButtonPressedEvent.GetInstance().Handler -= CloseAddVisibility;
            SelectedJeu = lesJeux[lesJeux.Count - 1];//le dernier jeu est sélectionné, soit celui qui vient d'être ajouté si l'ajout a eu lieu
            UpdateVisibilityCommand.RaiseCanExecuteChanged();

        }

        public bool CanAddVisibility(object o)
        {
            if (!IsAdding) return true;
            return false;
        }
        #endregion

        #region UpdateVisibility
        //une copie du jeu sélectionné est envoyé au ViewModel de modification, un changement de vue est envoyé
        public void UpdateVisibility(object o)
        {
            VisibilityGameDetails = false;
            IsAdding = true;
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new JeuEventArgs { Jeu =  SelectedJeu.Clone()as Jeu});
            AddViewButtonPressedEvent.GetInstance().OnButtonPressedHandler(new VisibilityEventArgs { Visibility = true });
            AddViewButtonPressedEvent.GetInstance().Handler += CloseUpdateVisibility;
        }

        //lorsque la modification est terminée, si elle a été validé les modifications sont appliquées au jeu sélectionné sinon aucune modification n'a lieu
        private void CloseUpdateVisibility(object sender, EventArgs e)
        {
            VisibilityGameDetails = true;
            IsAdding = false;
            var args = e as JeuEventArgs;
            if (args != null)
            {
                LesJeux[LesJeux.IndexOf(SelectedJeu)] = args.Jeu;
                SelectedJeu = args.Jeu;
            }
            AddViewButtonPressedEvent.GetInstance().Handler -= CloseUpdateVisibility;
        }

        public bool CanUpdateVisibility(object o)
        {
            if (SelectedJeu == null) return false;
            if(!IsAdding)
                return true;
            return false;
        }
        #endregion

        #region RemoveGame
        //supprime le jeu sélectionné et sélectionne le précédent dans la liste. Si il ne reste plus de jeu après la suppression l'ajout est déclenché
        public void RemoveGame(object o)
        {
            int indexJeu = lesJeux.IndexOf(SelectedJeu);
            lesJeux.Remove(SelectedJeu);
            if(lesJeux.Count>0)
                if(lesJeux.Count==indexJeu)
                    SelectedJeu = lesJeux[indexJeu-1];
                else
                    SelectedJeu = lesJeux[indexJeu];
            else
            {
                AddVisibilityCommand.Execute(o);
                RemoveCommand.RaiseCanExecuteChanged();
            }
            
        }

        public bool CanRemoveGame(object o)
        {
            if (IsAdding) return false;
            if (SelectedJeu != null)
                if(!lesJeux.Contains(SelectedJeu))
                    return false;
            return true;
        }
        #endregion

        #endregion
    }
}