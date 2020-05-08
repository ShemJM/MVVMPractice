using System.Collections.Generic;

namespace MVVMPractice
{
    public class TaskManagerViewModel: SideMenuPageViewModel
    {
        public TaskManagerViewModel()
        {
            Title = "Task Manager";
            Pages = new List<PageViewModel>()
            {
                new ProcessesViewModel(),
                new ServicesViewModel()
            };
            SelectedPage = Pages[0];
        }
    }
}
