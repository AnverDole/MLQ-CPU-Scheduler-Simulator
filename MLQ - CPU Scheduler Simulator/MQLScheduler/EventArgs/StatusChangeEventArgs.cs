namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs
{
    class QueueChangedEventArgs
    {
        public List<Queue> allQueues { get; set; }
        public Queue queue { get; set; }
    }
}
