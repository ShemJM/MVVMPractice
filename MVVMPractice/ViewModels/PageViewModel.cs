using System.Windows.Input;

namespace MVVMPractice
{
    public class PageViewModel: ViewModel
    {
        public string Title { get; set; }

        public ICommand GoHome => NewCommand((object param) => { App.context.ChangePage(new HomeViewModel(), ViewType.Home); });

        public void Load()
        {

        }
    }
}
