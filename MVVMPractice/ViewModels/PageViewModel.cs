using System.Windows.Input;

namespace MVVMPractice
{
    public class PageViewModel: ViewModel
    {
        public string Title { get; set; }
        public ViewType ViewType { get; set; }

        public ICommand GoHome => NewCommand((object param) => { App.context.ChangePage(new HomeViewModel()); });

        public virtual void Load()
        {

        }
    }
}
