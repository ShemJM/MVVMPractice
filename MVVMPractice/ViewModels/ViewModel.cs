using MVVMPractice.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MVVMPractice { 

    public abstract class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public string Error
        {
            get => MError;
            protected set
            {
                if (MError == value)
                    return;
                MError = value;
                OnPropertyChanged(nameof(Error));
                OnPropertyChanged("HasErrors");
                OnPropertyChanged("AllErrors");
            }
        }

        public string AllErrors => string.Join("\r\n", MErrorList.Select(s => s.Value).ToArray());

        public virtual bool HasErrors => MErrorList.Count > 0;

        protected Dictionary<string, string> MErrorList { get; set; } = new Dictionary<string, string>();
        protected string MError { get; set; } = string.Empty;
        public List<DelegateCommand> Commands { get; set; } = new List<DelegateCommand>();

        public virtual string this[string columnName]
        {
            get
            {
                Error = Validate(columnName);
                UpdateErrorList(columnName, Error);
                return Error;
            }
        }

        protected void UpdateErrorList(string columnName, string error)
        {
            if (MErrorList.ContainsKey(columnName))
            {
                if (string.IsNullOrEmpty(error))
                    _ = MErrorList.Remove(columnName);
                else
                    MErrorList[columnName] = error;
            }
            else if (!string.IsNullOrEmpty(error))
                MErrorList.Add(columnName, error);
            OnPropertyChanged("HasErrors");
            OnPropertyChanged("AllErrors");
        }

        protected virtual string Validate(string propertyName)
        {
            var str = ValidateByAnnotations(propertyName);
            return !string.IsNullOrEmpty(str) ? str : OnValidate(propertyName);
        }

        public string ValidateModel(object T)
        {
            var props = T.GetType().GetProperties();
            var error = string.Empty;

            foreach (var prop in props)
            {
                error += Validate(prop.Name);
            }

            return error;
        }

        protected virtual string OnValidate(string propertyName)
        {
            return string.Empty;
        }

        private string ValidateByAnnotations(string propertyName)
        {
            var validationContext = new ValidationContext(this, null, null)
            {
                MemberName = propertyName
            };
            var source = new Collection<ValidationResult>();
            if (Validator.TryValidateObject(this, validationContext, source, true))
                return string.Empty;
            var validationResult = source.SingleOrDefault(r => r.MemberNames.Any(m => string.Equals(m, propertyName)));
            return validationResult != null ? validationResult.ErrorMessage : string.Empty;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            foreach (var command in Commands)
            {
                command.InvokeCanExecuteChanged();
            }
        }

        public class PropertyName
        {
            private const string hasErrors = "HasErrors";
            private const string error = "Error";
            private const string allErrors = "AllErrors";

            public static string HasErrors => hasErrors;

            public static string Error => error;

            public static string AllErrors => allErrors;
        }
    }
}
