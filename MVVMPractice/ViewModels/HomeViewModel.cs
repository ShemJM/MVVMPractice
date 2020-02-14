using MVVMPractice.Models;
using System.Collections.ObjectModel;

namespace MVVMPractice.ViewModels
{
    class HomeViewModel: ViewModelBase
    {
        public ObservableCollection<PersonModel> People { get; set; }

        public HomeViewModel()
        {
            People = new ObservableCollection<PersonModel>() {
                new PersonModel() { Name = "Bob Dylan", Money = 50000},
                new PersonModel() { Name = "Bob Marley", Money = 120000},
                new PersonModel() { Name = "Bob Ross", Money = 75000 },
                new PersonModel() { Name = "Bob Barker", Money = 150000 }
            };
        }
    }
}
