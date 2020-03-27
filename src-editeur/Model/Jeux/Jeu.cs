using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model.Jeux
{
    public class Jeu : ICloneable
    {
        #region private
        
        private string _titre;
        private string _editeur;
        private string _description;
        private Uri _imagePath = new Uri(@"..\..\Images\notDefined.png", UriKind.Relative);
        private DateTime _date;
        private float _prix = 0.00f;
        private int _id;
        private Categorie _categorie1;
        private Categorie _categorie2 = Categorie.Aucune;
        #endregion

        #region public
        public string Titre
        {
            get
            {
                return _titre;
            }

            set
            {
                _titre = value;
                OnPropertyChanged("Titre");
                


            }
        }

        public string Editeur
        {
            get
            {
                return _editeur;
            }

            set
            {
                _editeur = value;
                OnPropertyChanged("Editeur");
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public float Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                if (value >= 0)
                    _prix = value;
                OnPropertyChanged("Prix");
            }
        }

        public Uri ImagePath
        {
            get
            {
                return _imagePath;
            }

            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }


        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public Categorie Categorie1
        {
            get
            {
                return _categorie1;
            }

            set
            {
               _categorie1 = value;
               OnPropertyChanged("Categorie1");
            }
        }

        public Categorie Categorie2
        {
            get
            {
                return _categorie2;
            }

            set
            {
                _categorie2 = value;
                OnPropertyChanged("Categorie2");
            }
        }


        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        public Jeu()
        {
        }

        public override int GetHashCode()
        {
            return Id%31;
        }

        public override bool Equals(object obj)
        {
            //check null
            if (object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as Jeu);
        }

        
        public bool Equals(Jeu other)
        {
            return (Titre.Equals(other.Titre, StringComparison.InvariantCultureIgnoreCase));
                
        }

        public override string ToString()
        {
            return $"{Titre}";
        }

        public object Clone()
        {
            return new Jeu
            {
                Titre = Titre,
                Editeur = Editeur,
                Description = Description,
                ImagePath=ImagePath,
                Categorie1=Categorie1,
                Categorie2=Categorie2,
                Date = Date,
                Prix = Prix
            };
        }
    }
}
