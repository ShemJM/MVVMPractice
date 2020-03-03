namespace MVVMPractice.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ViewModelBase SelectedViewModel { get; set; } = new HomeViewModel();

        public ViewType SelectedView { get; set; } = ViewType.Home;

        public void ChangePage(ViewModelBase viewModel, ViewType view)
        {
            SelectedViewModel = viewModel;
            SelectedView = view;
        }
    }
}
