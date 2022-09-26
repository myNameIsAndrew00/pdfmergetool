﻿using MergeTool.ViewModel;
using MergeTool.Views.Pages;
using MergeTool.Views.Pages.Chose;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTool.Converters
{
    public class PageValueConverter : BaseValueConverter<PageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BasePage page;

            //return a page inherited from BasePage
            switch ((ApplicationPages)value)
            {
                case ApplicationPages.Upload:
                    page = new Upload();
                    break;
                case ApplicationPages.Chose:
                    page = new Chose();
                    break;
                case ApplicationPages.Success:
                    page = new Success();
                    break;
                default:
                    return null;
            }


            Application.Instance.CurrentPageContext = (page.DataContext as BaseViewModel);

            return page;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
