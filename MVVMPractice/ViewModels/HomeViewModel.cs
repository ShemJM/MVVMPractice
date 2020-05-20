using System.Windows.Input;

namespace MVVMPractice
{
    public class HomeViewModel: PageViewModel
    {
        public HomeViewModel()
        {
            ViewType = ViewType.Home;
        }

        public ICommand OpenTaskManager => NewCommand((object param) => App.context.ChangePage(new TaskManagerViewModel()));
        public ICommand OpenMedia => NewCommand((object param) => App.context.ChangePage(new MediaViewModel()));
    }
}
