using MVVMPractice.Views;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVMPractice.ValueConverters
{
    public class ApplicationViewConverter : MarkupExtension, IValueConverter
    {
        private static ApplicationViewConverter converter = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var view = (ViewType)value;

            switch (view)
            {
                case ViewType.Home:
                    return new HomeView();
                case ViewType.Garage:
                    return new GarageView();
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new ApplicationViewConverter());
        }
    }
}
