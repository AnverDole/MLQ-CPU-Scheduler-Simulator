namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs
{
    class ContextChangedEventArgs
    {
        public Process process { get; set; }

        public int serviceTime { get; set; }

        public int arrivalTime { get; set; }
    }
}