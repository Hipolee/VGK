using Model.Jeux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModelView.Converters
{
    class CategorieToStringConverter : IValueConverter
    {

        //Renvoie une chaine de caractères vides la catégorie  aucune est sélectionnée sinon renvoie la chaine correspondant à l'enum
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Categorie categ;
            try
            {
                categ = (Categorie)value;
            }
            catch (InvalidCastException e)
            {
                return "";
            }
            if (categ == Categorie.Aucune) return "";
            return categ.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
