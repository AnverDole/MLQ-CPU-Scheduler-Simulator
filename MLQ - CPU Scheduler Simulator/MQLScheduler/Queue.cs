using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;

namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    public class Queue
    {
        public string queueName { get; set; }
        public int priority { get; set; }
        public SchedulerAlgorithem? schedulerAlgorithem { get; set; }


    }
}
