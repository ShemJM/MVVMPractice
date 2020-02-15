using MVVMPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.Models
{
    public class CarViewModel: ViewModelBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Condition { get; set; }
        public double Value { get; set; }
    }
}
