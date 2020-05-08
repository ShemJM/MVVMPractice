using System.Windows.Input;

namespace MVVMPractice
{
    public class HomeViewModel: ViewModel
    {
        public ICommand OpenTaskManager => NewCommand((object param) => App.context.ChangePage(new TaskManagerViewModel(), ViewType.SideMenuPage));
    }
}
