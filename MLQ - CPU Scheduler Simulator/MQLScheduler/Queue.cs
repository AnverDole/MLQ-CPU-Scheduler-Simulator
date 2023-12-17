using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;

namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    // Class representing a queue in the CPU scheduler
    public class Queue
    {
        // Property to get or set the name of the queue
        public string queueName { get; set; }

        // Property to get or set the priority of the queue
        public int priority { get; set; }

        // Property to get or set the scheduling algorithm associated with the queue
        public SchedulerAlgorithem? schedulerAlgorithem { get; set; }


    }
}
