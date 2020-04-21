using MVVMPractice.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{
    class TaskManagerViewModel: ViewModel
    {
        public string Title { get; set; } = "Task Manager";
        public List<ViewModel> Pages { get; set; }
        public ViewModel SelectedPage { get; set; } 

        public TaskManagerViewModel()
        {
            _gohome = new DelegateCommand(gohome, CanGoHome);
            Pages = new List<ViewModel>()
            {
                new ProcessesViewModel()
            };
            SelectedPage = Pages[0];
        }

        private DelegateCommand _gohome;
        public ICommand GoHome => _gohome;

        private bool CanGoHome(object commandparameter)
        {
            return true;
        }

        private void gohome(object commandparameter)
        {
            App.context.ChangePage(new HomeViewModel(), ViewType.Home);
        }
    }
}
