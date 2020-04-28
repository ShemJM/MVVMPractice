using MVVMPractice.Views;
using System;
using System.Globalization;
using System.Windows.Controls;
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
                case ViewType.TaskManager:
                    return new TaskManagerView();
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

    public class ApplicationViewModelConverter : MarkupExtension, IValueConverter
    {
        private static ApplicationViewModelConverter converter = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vm = (ViewModel)value;
            var name = vm.GetType().Name;
            var viewname = name.Replace("Model", "");
            var view = Type.GetType($"MVVMPractice.Views.{viewname}");
            return Activator.CreateInstance(view);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new ApplicationViewModelConverter());
        }
    }
}
