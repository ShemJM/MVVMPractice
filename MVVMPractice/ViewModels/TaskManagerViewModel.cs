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
            Pages = new List<ViewModel>()
            {
                new ProcessesViewModel()
            };
            SelectedPage = Pages[0];
        }

        public ICommand GoHome => new DelegateCommand((object param) =>
            {
                App.context.ChangePage(new HomeViewModel(), ViewType.Home);
            }
        );
    }
}
