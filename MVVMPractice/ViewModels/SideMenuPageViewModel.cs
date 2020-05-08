using System.Collections.Generic;

namespace MVVMPractice
{
    public class SideMenuPageViewModel: PageViewModel
    {
        public List<PageViewModel> Pages { get; set; }
        public PageViewModel SelectedPage { get; set; }
    }
}
