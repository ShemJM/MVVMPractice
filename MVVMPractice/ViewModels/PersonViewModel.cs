﻿using MVVMPractice.Commands;
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
    public class PersonViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public ObservableCollection<CarViewModel> Cars { get; set; }

        public PersonViewModel()
        {
            Cars = new ObservableCollection<CarViewModel>();
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
            App.context.ChangePage(new GarageViewModel(this), ViewType.Garage);
        }

        private readonly DelegateCommand _buycar;
        public ICommand BuyCar => _buycar;

        public bool CanBuyCar(object commandparameter)
        {
            CarViewModel car = (CarViewModel)commandparameter;

            return Money > car.Value;
        }

        private void buycar(object commandparameter)
        {
            CarViewModel car = (CarViewModel)commandparameter;
            Money -= car.Value;
            Cars.Add(car);
        }

        private readonly DelegateCommand _sellcar;
        public ICommand SellCar => _sellcar;

        public bool CanSellCar(object commandparameter)
        {
            CarViewModel car = (CarViewModel)commandparameter;

            return car.Condition > 50;
        }

        private void sellcar(object commandparameter)
        {
            CarViewModel car = (CarViewModel)commandparameter;
            Money += car.Value;
            Cars.Remove(car);
        }
    }
}