namespace MVVMPractice
{
    public class ShellViewModel : ViewModel
    {
        public ViewModel SelectedViewModel { get; set; } = new HomeViewModel();

        public ViewType SelectedView { get; set; } = ViewType.Home;

        public void ChangePage(PageViewModel viewModel)
        {
            SelectedViewModel = viewModel;
            SelectedView = viewModel.ViewType;
        }
    }
}