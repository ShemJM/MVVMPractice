using System.Windows.Controls;
using MVVMPractice.Models;

namespace MVVMPractice.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ViewModelBase SelectedViewModel { get; set; } = new HomeViewModel();

        public ViewType SelectedView { get; set; } = ViewType.Home;

        public ShellViewModel()
        {

        }

        public void ChangePage(ViewModelBase viewModel, ViewType view)
        {
            SelectedViewModel = viewModel;
            SelectedView = view;
        }
    }
}
