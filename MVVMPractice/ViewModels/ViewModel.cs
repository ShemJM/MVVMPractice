using MVVMPractice.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMPractice
{

    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<DelegateCommand> Commands { get; set; } = new List<DelegateCommand>();

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
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

        public DelegateCommand NewCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            var c = new DelegateCommand(executeAction, canExecuteAction);
            Commands.Add(c);
            return c;
        }

        public DelegateCommand NewCommand(Action<object> executeAction)
        {
            var c = new DelegateCommand(executeAction);
            return c;
        }
    }
}
