using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs;
using System.Diagnostics;

namespace MLQ___CPU_Scheduler_Simulator.MQLScheduler
{
    class MLQScheduler
    {

        // Enumeration to represent the status of the scheduler
        private Status schedulerStatus = Status.PENDING;

        // Events for notifying changes in status, queue, process, and context switch
        public EventHandler<StatusChangeEventArgs> StatusChangedEvent = delegate { };
        public EventHandler<QueueChangedEventArgs> queueChangedEvent = delegate { };
        public EventHandler<ProcessChangedEventArgs> processChangedEvent = delegate { };
        public EventHandler<ContextChangedEventArgs> contextSwitchedEvent = delegate { };

        // Lists to store queues and processes
        public List<Queue> queues = new List<Queue>();
        public List<Process> processes = new List<Process>();

        // Properties for aging threshold and time quantum
        public int aginThreashhold { get; set; }
        public int timeQuantum { get; set; }

        // Private property to track current time
        private int currentTime { get; set; }


        // Method to get the current status of the scheduler
        public Status GetStatus() { return schedulerStatus; }

        // Main method to run the scheduler
        public void Run()
        {

            // Initialize remaining burst time for each process
            foreach (Process process in processes) {
                process.remainingBurstTime = process.burstTime;
            }

            // If there are no processes, return
            if (processes.OrderBy(p => p.arrivelTime).Count() <= 0) return;

            // Notify that the scheduler is running
            StatusChangedEvent(this, new StatusChangeEventArgs { Status = Status.RUNNING });

            // Set current time to the arrival time of the first process
            currentTime = processes.OrderBy(p => p.arrivelTime).First().arrivelTime;


            
            while (true) {

                // Get queues with pending processes, ordered by priority for FCFS
                List<Queue> queues_ = queues
                    .Where(q => GetProcessesInQueue(q).Where(p => p.remainingBurstTime > 0).Where(p => p.arrivelTime <= currentTime).Count() > 0)
                    .OrderBy(q => q.priority)
                    .ToList();

                // If there are no eligible queues, exit the loop
                if (queues_.Count <= 0) break;

                // Process each queue
                foreach (Queue queue_ in queues_) {

                    // Get the count of pending processes in the queue
                    int pendingProcessesCount = GetProcessesInQueue(queue_).Where(p => p.remainingBurstTime > 0).Where(p => p.arrivelTime <= currentTime).Count();
                    if (pendingProcessesCount <= 0) break;

                    // Choose scheduling algorithm based on the queue's algorithm type
                    switch (queue_.schedulerAlgorithem) {
                        case SchedulerAlgorithem.FCFS:
                            ProcessFCFSQueue(queue_);
                            break;
                        case SchedulerAlgorithem.RR:
                            ProcessRRQueue(queue_);
                            break;
                    } 

                }

                // Increment the age of processes
                IncreementAgeOfTheProcesses();

            }

            // Notify that the scheduler is pending
            StatusChangedEvent(this, new StatusChangeEventArgs { Status = Status.PENDING });
        }


        // Method to add a queue to the scheduler
        public void addQueue(Queue queue) { 
            queues.Add(queue);
            queueChangedEvent(this, new QueueChangedEventArgs { allQueues = this.queues, queue = queue });
        }

        // Method to delete a queue from the scheduler based on its index
        public void deleteQueue(int index)
        {
            if (this.queues.Count - 1 < index) return;

            List<Process> processesForRemovel = processes.Where(p => p.queue.Equals(this.queues.ElementAt(index))).ToList();
            foreach (Process processForRemovel in processesForRemovel) { 
                processes.Remove(processForRemovel);
            }

            queues.RemoveAt(index);
            queueChangedEvent(this, new QueueChangedEventArgs { allQueues = this.queues });
            processChangedEvent(this, new ProcessChangedEventArgs { allProcesses = this.processes });
        }

        // Method to add a process to the scheduler
        public void addProcess(Process process)
        {
            processes.Add(process);
            processChangedEvent(this, new ProcessChangedEventArgs { allProcesses = this.processes, changedProcess = process });
        }

        // Method to delete a process from the scheduler based on its index
        public void deleteProcess(int index)
        {
            if (this.processes.Count - 1 < index) return;

            processes.RemoveAt(index);
            processChangedEvent(this, new ProcessChangedEventArgs { allProcesses = this.processes });
        }


        // Method to get processes in a specific queue
        public List<Process> GetProcessesInQueue(Queue queue) {
            return processes.Where(p => p.queue == queue).ToList();
       
        }

        // Method to process the FCFS queue
        private void ProcessFCFSQueue(Queue queue) {
            while (true)
            {
                // Get processes in the queue with remaining burst time, ordered by arrival time
                List<Process> processes = GetProcessesInQueue(queue)
                        .Where(p => p.remainingBurstTime > 0)
                        .Where(p => p.arrivelTime <= currentTime)
                        .OrderBy(p => p.arrivelTime)
                        .ToList();
                if (processes.Count() <= 0) break;

                foreach (Process process in processes)
                {
                    // Process aged processes using FCFS
                    ProcessAgedProcessesFCFS();

                    // Determine time slice based on remaining burst time and time quantum
                    int timeSlice = process.remainingBurstTime - timeQuantum > 0
                                        ? timeQuantum
                                        : process.remainingBurstTime;

                    // Adjust current time if it is less than the arrival time of the process
                    if (currentTime < process.arrivelTime)
                        currentTime += process.arrivelTime - currentTime;

                    int arraivalTime = currentTime;

                    // Execute the process for the calculated time slice
                    for (int currentTimeSlice = 0; currentTimeSlice < timeSlice; currentTimeSlice++)
                    {
                        process.remainingBurstTime--;
                        currentTime++;

                        // Check for context switch conditions
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

                    // Notify context switch event after processing the time slice
                    contextSwitchedEvent(this, new ContextChangedEventArgs
                    {
                        process = process,
                        serviceTime = timeSlice,
                        arrivalTime = arraivalTime
                    });
                }
            }
        }

        // Method to process the RR queue 
        private void ProcessRRQueue(Queue queue) {
            // Iterate through processes until all have completed their burst time
            while (true)
            {
                // Get processes in the queue with remaining burst time, ordered by arrival time
                List<Process> processes = GetProcessesInQueue(queue)
                    .Where(p => p.remainingBurstTime > 0)
                    .Where(p => p.arrivelTime <= currentTime) 
                    .ToList();

                if (processes.Count() <= 0) break;

                foreach (Process process in processes)
                {
                    // Process aged processes using FCFS
                    ProcessAgedProcessesFCFS();

                    // Determine time slice based on remaining burst time and time quantum
                    int timeSlice = Math.Min(timeQuantum, process.remainingBurstTime);

                    // Adjust current time if it is less than the arrival time of the process
                    if (currentTime < process.arrivelTime)
                        currentTime += process.arrivelTime - currentTime;

                    int arrivalTime = currentTime;

                    // Execute the process for the calculated time slice
                    process.remainingBurstTime -= timeSlice;
                    currentTime += timeSlice;

                    // Check if the process has completed
                    if (process.remainingBurstTime <= 0)
                    {
                        // Notify context switch event for the completed process
                        contextSwitchedEvent(this, new ContextChangedEventArgs
                        {
                            process = process,
                            serviceTime = timeSlice,
                            arrivalTime = arrivalTime
                        }); 
                    }
                    else
                    {
                        // Notify context switch event for the time-sliced process
                        contextSwitchedEvent(this, new ContextChangedEventArgs
                        {
                            process = process,
                            serviceTime = timeSlice,
                            arrivalTime = arrivalTime
                        });

                        // Rotate the process to the end of the queue
                        processes.Remove(process);
                        processes.Add(process);
                    }
                }
            }

        }

        // Method to process aged processes using FCFS
        private bool ProcessAgedProcessesFCFS()
        {
            bool hasProcessed = false;

            // Get aged processes with remaining burst time, ordered by arrival time for FCFS
            List<Process> processes = this.processes
                    .Where(p => p.remainingBurstTime > 0)
                    .Where(p => p.arrivelTime <= currentTime)
                    .Where(p => p.age > aginThreashhold)
                    .OrderBy(p => p.arrivelTime)
                    .ToList();
            if (processes.Count() <= 0) return hasProcessed;

            foreach (Process process in processes)
            {
                int timeSlice = process.remainingBurstTime - timeQuantum > 0
                                    ? timeQuantum
                                    : process.remainingBurstTime;


                if (currentTime < process.arrivelTime)
                    currentTime += process.arrivelTime - currentTime;

                int arraivalTime = currentTime;
                     
                process.remainingBurstTime -= timeSlice;
                currentTime += timeSlice; 
                    

                contextSwitchedEvent(this, new ContextChangedEventArgs
                {
                    process = process,
                    serviceTime = timeSlice,
                    arrivalTime = arraivalTime
                });
            }

            return hasProcessed;
        }

        // Method to increase the age of all processes.
        private void IncreementAgeOfTheProcesses()
        {
            List<Process> processes = this.processes
                         .Where(p => p.remainingBurstTime > 0)
                         .Where(p => p.arrivelTime <= currentTime)
                         .OrderByDescending(p => p.queue.priority)
                         .ToList();
            if (processes.Count() <= 0) return;

            processes.First().age++;
        }

    }
}
