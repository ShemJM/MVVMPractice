using MVVMPractice.Commands;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{
    public class HomeViewModel: ViewModel
    {
        public ICommand OpenTaskManager => new DelegateCommand((object param) => App.context.ChangePage(new TaskManagerViewModel(), ViewType.SideMenuPage));
    }
}
