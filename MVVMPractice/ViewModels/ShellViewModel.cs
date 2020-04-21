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
    }
}
