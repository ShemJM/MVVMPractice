using MVVMPractice.Models;
using System.Collections.ObjectModel;

namespace MVVMPractice.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public ObservableCollection<PersonViewModel> People { get; set; }

        public HomeViewModel()
        {
            People = new ObservableCollection<PersonViewModel>() {
                new PersonViewModel() { Name = "Bob Dylan", Money = 50000},
                new PersonViewModel() { Name = "Bob Marley", Money = 120000},
                new PersonViewModel() { Name = "Bob Ross", Money = 75000 },
                new PersonViewModel() { Name = "Bob Barker", Money = 150000 }
            };
        }
    }
}
