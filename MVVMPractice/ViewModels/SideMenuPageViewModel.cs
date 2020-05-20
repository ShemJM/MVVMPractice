using System.Collections.Generic;
using System.Configuration;

namespace MVVMPractice
{
    public class SideMenuPageViewModel: PageViewModel
    {
        public List<PageViewModel> Pages { get; set; }
        private PageViewModel _selectedPage;
        public PageViewModel SelectedPage { get => _selectedPage; set { SetProperty(ref _selectedPage, value); value.Load(); } }

        public SideMenuPageViewModel()
        {
            ViewType = ViewType.SideMenuPage;
        }
    }
}
