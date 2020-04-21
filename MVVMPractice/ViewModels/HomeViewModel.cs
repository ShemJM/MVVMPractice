using MVVMPractice.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{
    public class HomeViewModel: ViewModel
    {
        public HomeViewModel()
        {
            _openTaskManager = new DelegateCommand(openTaskManager, CanOpenTaskManager);
        }

        private DelegateCommand _openTaskManager;
        
        public ICommand OpenTaskManager => _openTaskManager;

        private bool CanOpenTaskManager(object commandparameter)
        {
            return true;
        }

        private void openTaskManager(object commandparameter)
        {
            App.context.ChangePage(new TaskManagerViewModel(), ViewType.TaskManager);
        }
    }
}
