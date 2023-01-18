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
    public class InfoStatusToTextColorConverter : BaseValueConverter<InfoStatusToTextColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((InfoStatus)value) switch
        {
            InfoStatus.Info => System.Windows.Media.Brushes.White,
            InfoStatus.Warning => System.Windows.Media.Brushes.White,
            InfoStatus.Error => System.Windows.Media.Brushes.White,
            InfoStatus.None => System.Windows.Media.Brushes.Black,
            _ => System.Windows.Media.Brushes.Black
        };

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
