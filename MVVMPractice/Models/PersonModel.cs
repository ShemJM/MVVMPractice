using MVVMPractice.Commands;
using MVVMPractice.ViewModels;
using MVVMPractice.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPractice.Models
{
    class PersonModel : ViewModelBase
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }

        public PersonModel()
        {
            Cars = new ObservableCollection<CarModel>();
            _gotogarage = new DelegateCommand(OpenGarage, CanOpenGarage);
            _buycar = new DelegateCommand(buycar, CanBuyCar);
            _sellcar = new DelegateCommand(sellcar, CanSellCar);
        }

        private readonly DelegateCommand _gotogarage;
        public ICommand GoToGarage => _gotogarage;

        private bool CanOpenGarage(object commandparameter)
        {
            return true;
        }
        private void OpenGarage(object commandparameter)
        {
            App.context.ChangePage(new GarageViewModel(this), new GarageView());
        }

        private readonly DelegateCommand _buycar;
        public ICommand BuyCar => _buycar;

        public bool CanBuyCar(object commandparameter)
        {
            CarModel car = (CarModel)commandparameter;

            return Money > car.Value;
        }

        private void buycar(object commandparameter)
        {
            CarModel car = (CarModel)commandparameter;
            Money -= car.Value;
            Cars.Add(car);
        }

        private readonly DelegateCommand _sellcar;
        public ICommand SellCar => _sellcar;

        public bool CanSellCar(object commandparameter)
        {
            CarModel car = (CarModel)commandparameter;

            return car.Condition > 50;
        }

        private void sellcar(object commandparameter)
        {
            CarModel car = (CarModel)commandparameter;
            Money += car.Value;
            Cars.Remove(car);
        }
    }
}
