using System.Collections.Generic;
using System.Diagnostics;

namespace MVVMPractice
{
    public class ProcessesViewModel: PageViewModel
    {
        public IEnumerable<Process> Processes { get; set; }
        public Process SelectedProcess { get; set; }

        public ProcessesViewModel()
        {
            Title = "Processes";
        }

        public new void Load()
        {
            Processes = Process.GetProcesses();
        }
    }
}
