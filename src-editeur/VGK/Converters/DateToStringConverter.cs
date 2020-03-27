using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModelView.Converters
{
    class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date;
            try
            {
                date = (DateTime)value;
            }
            catch (InvalidCastException e)
            {
                return "";
            }
            string dateTimeString = date.ToString("dd MMMM yyyy");
            return dateTimeString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateValue;
            DateTime date;
            string dateTimeString = (string)value;
            if (DateTime.TryParse(dateTimeString,out dateValue))
            {
                date = DateTime.Parse(dateTimeString);
                return date;
            }
            return DateTime.Now;
            

        }
    }
}
