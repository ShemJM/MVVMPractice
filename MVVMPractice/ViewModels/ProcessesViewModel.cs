using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.ViewModels
{
    public class ProcessesViewModel: ViewModel
    {
        public string Title { get; set; } = "Processes";
        public IEnumerable<Process> Processes { get; set; }

        public ProcessesViewModel()
        {
            Processes = Process.GetProcesses();    
        }
    }
}
