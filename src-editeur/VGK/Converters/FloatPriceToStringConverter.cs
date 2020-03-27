using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModelView.Converters
{
    class FloatPriceToStringConverter : IValueConverter
    {
        //Permet d'afficher le prix avec 2 chiffres après la virgule et le sigle €, affiche Gratuit si le prix est de 0
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float prix = (float)value;
            if (prix == 0f)
                return "Gratuit";
            return $"{prix.ToString("F2")} €";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string prix = (string)value;
            
            return float.Parse(prix);
        }
    }
}
