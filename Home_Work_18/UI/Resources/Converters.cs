using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using HomeWork.ViewModel;
using Color = System.Drawing.Color;

namespace HomeWork.Resources
{
    public class ConverterForeground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrEmpty((string)value)) return Brushes.Black;
            long result = System.Convert.ToInt64(value);
            switch (result)
            {
                case < 100: return new SolidColorBrush(Colors.Red);
                case < 500: return new SolidColorBrush(Colors.OrangeRed);
                case < 1000: return new SolidColorBrush(Colors.IndianRed);
                case < 2000: return new SolidColorBrush(Colors.MediumVioletRed);
                case < 5000: return new SolidColorBrush(Colors.DarkOliveGreen);
                case < 7000: return new SolidColorBrush(Colors.Green);
                default: return new SolidColorBrush(Colors.Black);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}