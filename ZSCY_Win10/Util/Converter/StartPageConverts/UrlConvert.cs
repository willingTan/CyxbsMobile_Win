﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ZSCY_Win10.Util.Converter.StartPageConverts
{
    class UrlConvert:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return $@"ms-appx:///{value.ToString()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
