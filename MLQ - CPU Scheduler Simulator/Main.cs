using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.EventArgs;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;
using Process = MLQ___CPU_Scheduler_Simulator.MQLScheduler.Process;
using System.Diagnostics;

namespace MLQ___CPU_Scheduler_Simulator
{
    public partial class Main : Form
    {

        private MLQScheduler mLQScheduler = new MLQScheduler();
        private NewQueueFrm newQueueFrm = new NewQueueFrm();
        private NewProcessFrm newProcessFrm = new NewProcessFrm();

        public Main()
        {
            InitializeComponent();

            mLQScheduler.aginThreashhold = 30;
            mLQScheduler.timeQuantum = 3;

            newQueueFrm.StartPosition= FormStartPosition.CenterParent;
            mLQScheduler.StatusChangedEvent += ListenStatusChange;
            mLQScheduler.queueChangedEvent += QueueChanged;
            mLQScheduler.processChangedEvent += ProcessChanged;
            mLQScheduler.contextSwitchedEvent += ContextChanged;

            queuesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allProcessesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //PopulateExample();
        }

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
        private void QueueChanged(object? sender, QueueChangedEventArgs e)
        { 
            queuesDataGridView.DataSource = e.allQueues.Select(x => new
            {
                Name = x.queueName,
                Priority = x.priority,
                Algorithem = x.schedulerAlgorithem
            })
                .OrderBy(x => x.Priority)
                .ToList();

        }
        private void ProcessChanged(object? sender, ProcessChangedEventArgs e)
        {
            allProcessesDataGrid.DataSource = e.allProcesses.Select(x => new
            {
                name = x.name,
                arrivelTime = x.arrivelTime,
                burstTime = x.burstTime
            })
                .OrderBy(x => x.arrivelTime)
                .ToList();

        }
        private void ContextChanged(object? sender, ContextChangedEventArgs e)
        {
            resultsDataGridView.Rows.Add(
                e.arrivalTime,
                e.process.name, 
                e.process.queue.queueName, 
                e.serviceTime, 
                e.process.remainingBurstTime
            );
        }



        /**
         * Exit from the application
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        

        private void runBtn_Click(object sender, EventArgs e)
        {
            resultsDataGridView.Rows.Clear();
            mLQScheduler.Run();
        }



     


        private void addNewQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newQueueFrm.Queues = mLQScheduler.queues;

            if (newQueueFrm.ShowDialog(this) == DialogResult.OK)
            {
                Queue queue = new Queue();
                queue.queueName = newQueueFrm.QueueName;
                queue.priority = newQueueFrm.Priority;
                queue.schedulerAlgorithem = newQueueFrm.Algorithem;
                mLQScheduler.addQueue(queue);
            }
        }
        private void addNewProcessToolStripMenuItem_Click(object sender, EventArgs e) {

            if (mLQScheduler.queues.Count < 1) { 
                MessageBox.Show("Please add at least one queue.", "Error!"); 
                return;
            }

            newProcessFrm.SetQueues(mLQScheduler.queues);
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


        private void deleteSelectedQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (queuesDataGridView.SelectedRows.Count < 0) return;

            int selectedRowIndex = (int)queuesDataGridView.SelectedRows[0].Index; 
            mLQScheduler.deleteQueue(selectedRowIndex);
        }
        private void deleteSelectedProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allProcessesDataGrid.SelectedRows.Count < 0) return;

            int selectedRowIndex = (int)allProcessesDataGrid.SelectedRows[0].Index;
            mLQScheduler.deleteProcess(selectedRowIndex);
        }

        private void queuesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (queuesDataGridView.SelectedRows.Count > 0)
            {
                deleteSelectedQueueToolStripMenuItem.Enabled = true;
            }
            else {
                deleteSelectedQueueToolStripMenuItem.Enabled = false;
            }
        }

        private void allProcessesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (allProcessesDataGrid.SelectedRows.Count > 0)
            {
                deleteSelectedProcessToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteSelectedProcessToolStripMenuItem.Enabled = false;
            }
        }

        private void example1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateExample1();
        }

        private void example2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateExample2();
        }
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
            queue3.queueName = "Q4";
            queue3.priority = 2;
            queue3.schedulerAlgorithem = SchedulerAlgorithem.RR;
            mLQScheduler.addQueue(queue3);


            Process process1 = new Process();
            process1.arrivelTime = 5;
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
            process4.burstTime = 6;
            process4.name = "P 4";
            process4.queue = queue1;
            mLQScheduler.addProcess(process4);

        }
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
            process2.arrivelTime = 2;
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
            process4.arrivelTime = 10;
            process4.burstTime = 6;
            process4.name = "P 4";
            process4.queue = queue1;
            mLQScheduler.addProcess(process4);

        }
    }
}