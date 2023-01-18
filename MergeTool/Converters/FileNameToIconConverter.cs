using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Converters
{
    public class FileNameToIconConverter : BaseValueConverter<FileNameToIconConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueString = value as string;

            if(valueString is null)
            {
                return null;
            }

            valueString = Path.GetExtension(valueString).Trim('.');
           
            switch (valueString)
            {
                case "pdf": return IconChar.FilePdf;
                case "xlsx": return IconChar.FileExcel;
                case "doc":
                case "docx": return IconChar.FileWord;

                default: return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
