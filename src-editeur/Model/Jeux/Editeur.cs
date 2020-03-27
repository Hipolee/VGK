using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Jeux
{
    public class Editeur : ICloneable
    {
        #region private
        private string _nom;
        private DateTime _dateCreation;
        private string _description;
        private List<Jeu> ListJeuEdit = new List<Jeu>(); 
        private Uri _imagePath = new Uri(@"..\..\Images\notDefined.png", UriKind.Relative);
        private int _id;
        #endregion

        #region public
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return _dateCreation;
            }

            set
            {
                _dateCreation = value;
                OnPropertyChanged("Date");
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
        #endregion

        public Editeur()
        {
        }

        public override int GetHashCode()
        {
            return Id % 31;
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

            return this.Equals(obj as Editeur);
        }


        public bool Equals(Editeur other)
        {
            return (Nom.Equals(other.Nom, StringComparison.InvariantCultureIgnoreCase));

        }

        public override string ToString()
        {
            return $"{Nom}";
        }

        public object Clone()
        {
            return new Editeur
            {
                Nom = Nom,
                DateCreation = DateCreation,
                Description = Description,
                ImagePath = ImagePath,
                Id = Id
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
