using MVVMPractice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.ViewModels
{
    public class GarageViewModel: ViewModelBase
    {
        public PersonViewModel SelectedPerson { get; set; }
        public ObservableCollection<CarViewModel> CarsForSale { get; set; }

        public GarageViewModel(PersonViewModel person)
        {
            SelectedPerson = person;

            CarsForSale = new ObservableCollection<CarViewModel>()
            {
                new CarViewModel(){ Brand = "Toyota", Model = "SomeModel", Condition = 67, Value = 6295},
                new CarViewModel(){ Brand = "Honda", Model = "Civic", Condition = 87, Value = 5000},
                new CarViewModel(){ Brand = "Ford", Model = "Mustang", Condition = 23, Value = 12995},
                new CarViewModel(){ Brand = "Ferrari", Model = "Enzo", Condition = 23, Value = 212995}
            };
        }
    }
}
