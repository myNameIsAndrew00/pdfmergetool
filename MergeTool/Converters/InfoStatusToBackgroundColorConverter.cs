using MergeTool.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MergeTool.Converters
{
    public class InfoStatusToBackgroundColorConverter : BaseValueConverter<InfoStatusToBackgroundColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((InfoStatus)value) switch
        {
            InfoStatus.Info => System.Windows.Media.Brushes.Green,
            InfoStatus.Warning => System.Windows.Media.Brushes.DarkOrange,
            InfoStatus.Error => System.Windows.Media.Brushes.Red,
            InfoStatus.None => System.Windows.Media.Brushes.Transparent,
            _ => System.Windows.Media.Brushes.Transparent
        };

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
