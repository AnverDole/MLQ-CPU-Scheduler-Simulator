namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    // Class representing a process in the CPU scheduler
    class Process
    {
        // Property to get or set the name of the process
        public string name { get; set; }

        // Property to get or set the arrival time of the process
        public int arrivelTime { get; set; }

        // Property to get or set the queue to which the process belongs
        public Queue queue { get; set; }

        // Private fields for burst time, remaining burst time, and age of the process
        private int burstTime_ = 0;
        private int remainingBurstTime_ = 0;
        private int age_ = 0;

        // Property to get or set the burst time of the process
        public int burstTime {
            get { return this.burstTime_; }
            set { burstTime_ = remainingBurstTime_ = value; }
        }

        // Property to get or set the remaining burst time of the process
        public int remainingBurstTime {
            get { return this.remainingBurstTime_;  }
            set { remainingBurstTime_ = value; }
        }

        // Property to get or set the age of the process
        public int age
        {
            get { return this.age_; }
            set { age_ = value; }
        }
    }
}
