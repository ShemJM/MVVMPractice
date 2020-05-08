using System.Collections.Generic;
using System.ServiceProcess;

namespace MVVMPractice
{
    class ServicesViewModel: PageViewModel
    {
        public IEnumerable<ServiceController> Services { get; set; }
        public ServiceController SelectedService { get; set; }

        public ServicesViewModel()
        {
            Title = "Services";
        }

        public new void Load()
        {
            Services = ServiceController.GetServices();
        }
    }
}
