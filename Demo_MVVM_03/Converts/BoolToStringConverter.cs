using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.MVVM.Converters;

namespace Demo_MVVM_03.Converts
{
    public class BoolToStringConverter : ConverterBase<bool, string>
    {
        public override string Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? "Oui" : "Non";
        }

        public override bool ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToLower() == "oui";
        }
    }
}
