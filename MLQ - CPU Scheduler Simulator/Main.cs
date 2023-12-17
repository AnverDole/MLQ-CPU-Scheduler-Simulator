using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;
using Process = MLQ___CPU_Scheduler_Simulator.MQLScheduler.Process;
using System.Diagnostics;

namespace MLQ___CPU_Scheduler_Simulator
{
    public partial class Main : Form
    {

        // Instance of the Scheduler engine class
        private MLQScheduler mLQScheduler = new MLQScheduler();

        // Instances of forms used in the application
        private NewQueueFrm newQueueFrm = new NewQueueFrm();
        private NewProcessFrm newProcessFrm = new NewProcessFrm();

        public Main()
        {
            InitializeComponent();

            // Set default values for aging threshold and time quantum
            mLQScheduler.aginThreashhold = 8;
            mLQScheduler.timeQuantum = 3;

            // Set the starting position for the newQueueFrm form
            newQueueFrm.StartPosition= FormStartPosition.CenterParent;

            // Subscribe to events in the Scheduler engine instance
            mLQScheduler.StatusChangedEvent += ListenStatusChange;
            mLQScheduler.queueChangedEvent += QueueChanged;
            mLQScheduler.processChangedEvent += ProcessChanged;
            mLQScheduler.contextSwitchedEvent += ContextChanged;

            // Set the DataGridView columns to fill the available space
            queuesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allProcessesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }

        // Event handler for status change in the scheduler
        private void ListenStatusChange(object? sender, StatusChangeEventArgs e)
        {
            switch (e.Status) {
                case Status.PENDING:
                    runBtn.Enabled = true; 
                    break;
                case Status.RUNNING:
                    runBtn.Enabled = false; 
                    break; 
            }
        }

        // Event handler for changes in the queue
        private void QueueChanged(object? sender, QueueChangedEventArgs e)
        {
            // Order queues by priority
            List<Queue> queues = e.allQueues
                .OrderBy(x => x.priority)
                .ToList();

            // Clear and populate the queuesDataGridView
            queuesDataGridView.Rows.Clear();
            foreach (Queue queue in queues)
            {
                queuesDataGridView.Rows.Add(queue.queueName, queue.priority, queue.schedulerAlgorithem);
            }

        }

        // Event handler for changes in the process
        private void ProcessChanged(object? sender, ProcessChangedEventArgs e)
        {
            // Order processes by arrival time
            List<Process> processes = e.allProcesses
                .OrderBy(x => x.arrivelTime)
                .ToList();

            // Clear and populate the allProcessesDataGrid
            allProcessesDataGrid.Rows.Clear();
            foreach (Process process in processes)
            {
                allProcessesDataGrid.Rows.Add(process.name, process.arrivelTime, process.burstTime, process.queue.queueName);
            }

        }

        // Event handler for context switch changes
        private void ContextChanged(object? sender, ContextChangedEventArgs e)
        {
            // Add a new row to the resultsDataGridView
            resultsDataGridView.Rows.Add(
                e.arrivalTime,
                e.process.name, 
                e.process.queue.queueName, 
                e.serviceTime, 
                e.process.remainingBurstTime
            );
        }



        // Event handler for the "Exit" menu item
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // Event handler for the "Run" button click
        private void runBtn_Click(object sender, EventArgs e)
        {
            resultsDataGridView.Rows.Clear();
            mLQScheduler.Run();
        }




        // Event handler for adding a new queue
        private void addNewQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the queues for the newQueueFrm form
            newQueueFrm.Queues = mLQScheduler.queues;

            // Show the newQueueFrm form and add the new queue if OK is clicked
            if (newQueueFrm.ShowDialog(this) == DialogResult.OK)
            {
                Queue queue = new Queue();
                queue.queueName = newQueueFrm.QueueName;
                queue.priority = newQueueFrm.Priority;
                queue.schedulerAlgorithem = newQueueFrm.Algorithem;
                mLQScheduler.addQueue(queue);
            }
        }

        // Event handler for adding a new process
        private void addNewProcessToolStripMenuItem_Click(object sender, EventArgs e) {
            // Check if there is at least one queue
            if (mLQScheduler.queues.Count < 1) { 
                MessageBox.Show("Please add at least one queue.", "Error!"); 
                return;
            }

            // Set the queues for the newProcessFrm form
            newProcessFrm.SetQueues(mLQScheduler.queues);

            // Show the newProcessFrm form and add the new process if OK is clicked
            if (newProcessFrm.ShowDialog(this) == DialogResult.OK)
            {
                Process process = new Process();
                process.name = newProcessFrm.ProcessName;
                process.arrivelTime = newProcessFrm.ArrivelTime;
                process.burstTime = newProcessFrm.BurstTime;
                process.queue = newProcessFrm.SelectedQueue;

                mLQScheduler.addProcess(process);
            }
        }

        // Event handler for deleting a selected queue
        private void deleteSelectedQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a queue is selected and delete it
            if (queuesDataGridView.SelectedRows.Count < 0) return;

            int selectedRowIndex = (int)queuesDataGridView.SelectedRows[0].Index; 
            mLQScheduler.deleteQueue(selectedRowIndex);
        }
        // Event handler for deleting a selected process
        private void deleteSelectedProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if a process is selected and delete it
            if (allProcessesDataGrid.SelectedRows.Count < 0) return;

            int selectedRowIndex = (int)allProcessesDataGrid.SelectedRows[0].Index;
            mLQScheduler.deleteProcess(selectedRowIndex);
        }

        // Event handler for the selection change in queuesDataGridView
        private void queuesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Enable or disable the "Delete Selected Queue" menu item based on selection
            if (queuesDataGridView.SelectedRows.Count > 0)
            {
                deleteSelectedQueueToolStripMenuItem.Enabled = true;
            }
            else {
                deleteSelectedQueueToolStripMenuItem.Enabled = false;
            }
        }

        // Event handler for the selection change in allProcessesDataGrid
        private void allProcessesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Enable or disable the "Delete Selected Process" menu item based on selection
            if (allProcessesDataGrid.SelectedRows.Count > 0)
            {
                deleteSelectedProcessToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteSelectedProcessToolStripMenuItem.Enabled = false;
            }
        }

        // Event handler for the "Example 1" menu item
        private void example1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateExample1();
        }

        // Event handler for the "Example 2" menu item
        private void example2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateExample2();
        }

        // Event handler for the "Example 3" menu item
        private void example3AginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateExample3();
        }

        // Load the example 1 configurations
        private void PopulateExample1()
        {
            mLQScheduler.processes.Clear();
            mLQScheduler.queues.Clear();

            Queue queue1 = new Queue();
            queue1.queueName = "Q1";
            queue1.priority = 0;
            queue1.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue1);

            Queue queue2 = new Queue();
            queue2.queueName = "Q2";
            queue2.priority = 1;
            queue2.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue2);

            Queue queue3 = new Queue();
            queue3.queueName = "Q3";
            queue3.priority = 2;
            queue3.schedulerAlgorithem = SchedulerAlgorithem.RR;
            mLQScheduler.addQueue(queue3);


            Process process1 = new Process();
            process1.arrivelTime = 0;
            process1.burstTime = 5;
            process1.name = "P 1";
            process1.queue = queue1;
            mLQScheduler.addProcess(process1);

            Process process2 = new Process();
            process2.arrivelTime = 2;
            process2.burstTime = 3;
            process2.name = "P 2";
            process2.queue = queue2;
            mLQScheduler.addProcess(process2);

            Process process3 = new Process();
            process3.arrivelTime = 6;
            process3.burstTime = 8;
            process3.name = "P 3";
            process3.queue = queue2;
            mLQScheduler.addProcess(process3);

            Process process4 = new Process();
            process4.arrivelTime = 10;
            process4.burstTime = 10;
            process4.name = "P 4";
            process4.queue = queue1;
            mLQScheduler.addProcess(process4);

        }

        // Load the example 2 configurations
        private void PopulateExample2()
        {
            mLQScheduler.processes.Clear();
            mLQScheduler.queues.Clear();

            Queue queue1 = new Queue();
            queue1.queueName = "Q1";
            queue1.priority = 0;
            queue1.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue1);

            Queue queue2 = new Queue();
            queue2.queueName = "Q2";
            queue2.priority = 1;
            queue2.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue2); 


            Process process1 = new Process();
            process1.arrivelTime = 5;
            process1.burstTime = 20;
            process1.name = "P 1";
            process1.queue = queue1;
            mLQScheduler.addProcess(process1);

            Process process2 = new Process();
            process2.arrivelTime = 10;
            process2.burstTime = 3;
            process2.name = "P 2";
            process2.queue = queue2;
            mLQScheduler.addProcess(process2);

            Process process3 = new Process();
            process3.arrivelTime = 20;
            process3.burstTime = 20;
            process3.name = "P 3";
            process3.queue = queue2;
            mLQScheduler.addProcess(process3);

            Process process4 = new Process();
            process4.arrivelTime = 25;
            process4.burstTime = 6;
            process4.name = "P 4";
            process4.queue = queue1;
            mLQScheduler.addProcess(process4);

        }

        // Load the example 3 configurations
        private void PopulateExample3()
        {
            mLQScheduler.processes.Clear();
            mLQScheduler.queues.Clear();

            Queue queue1 = new Queue();
            queue1.queueName = "Q1";
            queue1.priority = 0;
            queue1.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue1);

            Queue queue2 = new Queue();
            queue2.queueName = "Q2";
            queue2.priority = 1;
            queue2.schedulerAlgorithem = SchedulerAlgorithem.FCFS;
            mLQScheduler.addQueue(queue2);


            Process process1 = new Process();
            process1.arrivelTime = 5;
            process1.burstTime = 20;
            process1.name = "P 1";
            process1.queue = queue1;
            mLQScheduler.addProcess(process1);

            Process process2 = new Process();
            process2.arrivelTime = 8;
            process2.burstTime = 20;
            process2.name = "P 2";
            process2.queue = queue1;
            mLQScheduler.addProcess(process2);

            Process process3 = new Process();
            process3.arrivelTime = 15;
            process3.burstTime = 20;
            process3.name = "P 3";
            process3.queue = queue1;
            mLQScheduler.addProcess(process3);

            Process process4 = new Process();
            process4.arrivelTime = 20;
            process4.burstTime = 20;
            process4.name = "P 4";
            process4.queue = queue1;
            mLQScheduler.addProcess(process4);

            Process process5 = new Process();
            process5.arrivelTime = 25;
            process5.burstTime = 30;
            process5.name = "P 5";
            process5.queue = queue1;
            mLQScheduler.addProcess(process5);

            Process process6 = new Process();
            process6.arrivelTime = 20;
            process6.burstTime = 10;
            process6.name = "P 6";
            process6.queue = queue2;
            mLQScheduler.addProcess(process6);

            Process process7 = new Process();
            process7.arrivelTime = 22;
            process7.burstTime = 6;
            process7.name = "P 4";
            process7.queue = queue2;
            mLQScheduler.addProcess(process7);

        }


    }
}