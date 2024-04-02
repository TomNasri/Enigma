using Enigme.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Enigma.View.Converters
{
    public class GearValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as GearValue;
            switch ((v.Input - 'A') % 3)
            {
                case 0: return Brushes.LightBlue;
                case 1: return Brushes.LightGreen;
                case 2: return Brushes.LightSalmon;
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
