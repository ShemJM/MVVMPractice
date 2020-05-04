using System.Collections.Generic;
using System.ServiceProcess;

namespace MVVMPractice.ViewModels
{
    class ServicesViewModel: ViewModel
    {
        public string Title { get; set; } = "Services";
        public IEnumerable<ServiceController> Services { get; set; }
        public ServiceController SelectedService { get; set; }

        public ServicesViewModel()
        {
            Services = ServiceController.GetServices();
        }
    }
}
