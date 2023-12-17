namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    class Process
    {
        public string name { get; set; }
        public int arrivelTime { get; set; } 

        public Queue queue { get; set; }

        private int burstTime_ = 0;
        private int remainingBurstTime_ = 0;
        private int age_ = 0;

        public int burstTime {
            get { return this.burstTime_; }
            set { burstTime_ = remainingBurstTime_ = value; }
        }
        public int remainingBurstTime {
            get { return this.remainingBurstTime_;  }
            set { remainingBurstTime_ = value; }
        }

        public int age
        {
            get { return this.age_; }
            set { age_ = value; }
        }
    }
}
