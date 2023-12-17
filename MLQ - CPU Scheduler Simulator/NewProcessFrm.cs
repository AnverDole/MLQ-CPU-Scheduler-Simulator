using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using System.Collections.Generic;

namespace MLQ___CPU_Scheduler_Simulator
{

    // Class for the form to create or edit a new process
    public partial class NewProcessFrm : Form
    {
        // Enumeration for different form types (NEW, EDIT)
        public enum FormType { NEW, EDIT }

        // List to store available queues for the process
        private List<Queue> queues = new List<Queue>();


        public NewProcessFrm()
        {
            InitializeComponent(); 
        }

        // Property to get or set the process name
        public string ProcessName {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        // Property to get or set the arrival time of the process
        public int ArrivelTime
        {
            get { return (int)arrivelTimeNumBox.Value; }
            set { arrivelTimeNumBox.Value = value; }
        }


        // Property to get or set the burst time of the process
        public int BurstTime
        {
            get { return (int)burstTimeNumBox.Value; }
            set { burstTimeNumBox.Value = value; }
        }

        // Method to set the available queues for the process
        public void SetQueues(List<Queue> queues) {
            this.queues = queues;

            // Clear existing items in the queueDropDown and populate it with queue names
            queueDropDown.Items.Clear();
            foreach (Queue queue in queues) {
                queueDropDown.Items.Add(queue.queueName);
            }

            // Set the default selection to the first queue
            queueDropDown.SelectedIndex = 0;
        }

        // Property to get the selected queue for the process
        public Queue SelectedQueue {
            get{
                // Get the index of the selected item in the queueDropDown and return the corresponding queue
                int selectedIndex = queueDropDown.SelectedIndex;
                return (Queue)queues.ElementAt(selectedIndex);
            }
        }

        // Event handler for the "Add" button click
        private void addButton_Click(object sender, EventArgs e)
        {
           // Set the DialogResult to OK to indicate that the user clicked the "Add" button
           DialogResult = DialogResult.OK;
        }

        // Event handler for the "Cancel" button click
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Set the DialogResult to Cancel to indicate that the user clicked the "Cancel" button
            DialogResult = DialogResult.Cancel;
        }

       
    }
}
