using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MergeTool.Converters
{
    public class ColorHexToColorConverter : BaseValueConverter<ColorHexToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] color = value as byte[];

            return new SolidColorBrush(System.Windows.Media.Color.FromRgb(color[0], color[1], color[2]));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
