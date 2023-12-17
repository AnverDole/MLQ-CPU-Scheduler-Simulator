using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;

namespace MLQ___CPU_Scheduler_Simulator
{
    // Class for the form to create or edit a new queue
    public partial class NewQueueFrm : Form
    {

        // List to store existing queues
        public List<Queue> Queues;

        // Enumeration for different form types (NEW, EDIT)
        public enum FormType { NEW, EDIT} 

        public NewQueueFrm()
        {
            InitializeComponent();

            // Set the data source for the algorithm drop-down from the SchedulerAlgorithem enum
            algorithemDropDown.DataSource = Enum.GetValues(typeof(SchedulerAlgorithem));    
        }

        // Property to get or set the queue name
        public string QueueName {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        // Property to get or set the priority of the queue
        public int Priority
        {
            get { return (int)priorityNumBox.Value; }
            set { priorityNumBox.Value = value; }
        }


        // Property to get or set the algorithm for the queue
        public SchedulerAlgorithem? Algorithem
        {
            get {
                // Get the index of the selected item in the algorithemDropDown
                // and return the corresponding SchedulerAlgorithem
                int index = algorithemDropDown.SelectedIndex;

                // Return null if no algorithm is selected
                if (index == -1) return null;

                return (SchedulerAlgorithem)index;
            }
            set {
                // Set the selected index based on the provided SchedulerAlgorithem value
                if (value < 0 || value == null)
                {
                    algorithemDropDown.SelectedIndex = -1;
                }
                else {
                    algorithemDropDown.SelectedIndex = (int)value;
                }
            }
        }


        // Event handler for the "Cancel" button click
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Set the DialogResult to Cancel to indicate that the
            // user clicked the "Cancel" button
            this.DialogResult = DialogResult.Cancel;
        }

        // Event handler for the "Add" button click
        private void addButton_Click(object sender, EventArgs e)
        {
            // Set the DialogResult to OK to indicate that the user clicked the "Add" button
            this.DialogResult = DialogResult.OK;
        } 
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         