using MVVMPractice.Commands;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{ 
    public class ShellViewModel : ViewModel
    {
        public ViewModel SelectedViewModel { get; set; } = new HomeViewModel();

        public ViewType SelectedView { get; set; } = ViewType.Home;

        public void ChangePage(ViewModel viewModel, ViewType view)
        {
            SelectedViewModel = viewModel;
            SelectedView = view;
        }

        public ICommand GoHome => new DelegateCommand((object param) => { ChangePage(new HomeViewModel(), ViewType.Home); });
    }
}
