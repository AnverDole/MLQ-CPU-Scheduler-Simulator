namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs
{
    class ProcessChangedEventArgs
    {
        public List<Process> allProcesses = new List<Process>();
        public Process changedProcess { get; set; }
    }
}
