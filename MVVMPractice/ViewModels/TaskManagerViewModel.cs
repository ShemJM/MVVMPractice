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
                new ProcessesViewModel(),
                new ServicesViewModel()
            };
            SelectedPage = Pages[0];
        }
    }
}
