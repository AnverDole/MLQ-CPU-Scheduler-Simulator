using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs;

namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    class MLQScheduler
    {
        private Status schedulerStatus = Status.PENDING;

        public EventHandler<StatusChangeEventArgs> StatusChangedEvent = delegate { };
        public EventHandler<QueueChangedEventArgs> queueChangedEvent = delegate { };
        public EventHandler<ProcessChangedEventArgs> processChangedEvent = delegate { };
        public EventHandler<ContextChangedEventArgs> contextSwitchedEvent = delegate { };

        public List<Queue> queues = new List<Queue>();
        public List<Process> processes = new List<Process>();

        public int aginThreashhold { get; set; }
        public int timeQuantum { get; set; }
        private int currentTime { get; set; }
        public Status GetStatus() { return schedulerStatus; }

        public void Run()
        {
            foreach (Process process in processes) {
                process.remainingBurstTime = process.burstTime;
            }

            if (processes.OrderBy(p => p.arrivelTime).Count() <= 0) return;

            StatusChangedEvent(this, new StatusChangeEventArgs { Status = Status.RUNNING });
                
            currentTime = processes.OrderBy(p => p.arrivelTime).First().arrivelTime;

            while (true) { 
                List<Queue> queues_ = queues
                    .Where(q => GetProcessesInQueue(q).Where(p => p.remainingBurstTime > 0).Where(p => p.arrivelTime <= currentTime).Count() > 0)
                    .OrderBy(q => q.priority)
                    .ToList();

                if (queues_.Count <= 0) break;

                foreach (Queue queue_ in queues_) {  
                    int pendingProcessesCount = GetProcessesInQueue(queue_).Where(p => p.remainingBurstTime > 0).Where(p => p.arrivelTime <= currentTime).Count();
                    if (pendingProcessesCount <= 0) break;

                    switch (queue_.schedulerAlgorithem) {
                        case SchedulerAlgorithem.FCFS:
                            ProcessFCFSQueue(queue_);
                            break;
                        case SchedulerAlgorithem.RR:
                            ProcessRRQueue(queue_);
                            break;
                    } 
                } 
            }


            StatusChangedEvent(this, new StatusChangeEventArgs { Status = Status.PENDING });
        }


        public void addQueue(Queue queue) { 
            queues.Add(queue);
            queueChangedEvent(this, new QueueChangedEventArgs { allQueues = this.queues, queue = queue });
        }
        public void deleteQueue(int index)
        {
            queues.RemoveAt(index);
            queueChangedEvent(this, new QueueChangedEventArgs { allQueues = this.queues });
        }


        public void addProcess(Process process)
        {
            processes.Add(process);
            processChangedEvent(this, new ProcessChangedEventArgs { allProcesses = this.processes, changedProcess = process });
        }
        public void deleteProcess(int index)
        {
            processes.RemoveAt(index);
            processChangedEvent(this, new ProcessChangedEventArgs { allProcesses = this.processes });
        }


        public List<Process> GetProcessesInQueue(Queue queue) {
            return processes.Where(p => p.queue == queue).ToList();
       
        }
        public void ProcessFCFSQueue(Queue queue) {
            while (true)
            {
                List<Process> processes = GetProcessesInQueue(queue)
                        .Where(p => p.remainingBurstTime > 0)
                        .Where(p => p.arrivelTime <= currentTime)
                        .OrderBy(p => p.arrivelTime)
                        .ToList();
                if (processes.Count() <= 0) break;

                foreach (Process process in processes)
                {
                    int timeSlice = process.remainingBurstTime - timeQuantum > 0
                                        ? timeQuantum
                                        : process.remainingBurstTime;


                    if (currentTime < process.arrivelTime)
                        currentTime += process.arrivelTime - currentTime;

                    int arraivalTime = currentTime;

                    for (int currentTimeSlice = 0; currentTimeSlice < timeSlice; currentTimeSlice++)
                    {
                        process.remainingBurstTime--;
                        currentTime++;

                        if (queues.Where(q => q.priority < queue.priority).Where(q => GetProcessesInQueue(q).Where(p => p.remainingBurstTime > 0).Where(p => p.arrivelTime <= currentTime).Count() > 0).Count() > 0)
                        {
                            contextSwitchedEvent(this, new ContextChangedEventArgs
                            {
                                process = process,
                                serviceTime = currentTimeSlice + 1,
                                arrivalTime = arraivalTime
                            });
                            return;
                        }
                    }

                    contextSwitchedEvent(this, new ContextChangedEventArgs
                    {
                        process = process,
                        serviceTime = timeSlice,
                        arrivalTime = arraivalTime
                    });
                }
            }
        }
        public void ProcessRRQueue(Queue queue) {
            ProcessFCFSQueue(queue);
        }


    }
}
