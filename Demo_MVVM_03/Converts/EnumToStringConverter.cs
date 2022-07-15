using Demo_MVVM_03.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.MVVM.Converters;

namespace Demo_MVVM_03.Converts
{
    internal class ConditionCarToStringConverter : ConverterBase<ConditionCar, string>
    {
        public override string Convert(ConditionCar value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ConditionCar.NEW:
                    return "Neuve";
                case ConditionCar.OCCASION:
                    return "Occasion";
                case ConditionCar.DAMAGED:
                    return "Endommagée";
                default:
                    return "Inconnue";
            }
        }

        public override ConditionCar ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
