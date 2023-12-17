using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using MLQ___CPU_Scheduler_Simulator.MQLScheduler.Enums;

namespace MLQ___CPU_Scheduler_Simulator
{
    public partial class NewQueueFrm : Form
    {

        public List<Queue> Queues;

        public enum FormType { NEW, EDIT} 

        public NewQueueFrm()
        {
            InitializeComponent();

            algorithemDropDown.DataSource = Enum.GetValues(typeof(SchedulerAlgorithem));    
        }
        public string QueueName {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }
 
        public int Priority
        {
            get { return (int)priorityNumBox.Value; }
            set { priorityNumBox.Value = value; }
        }

      
         
        public SchedulerAlgorithem? Algorithem
        {
            get {
                int index = algorithemDropDown.SelectedIndex;

                if (index == -1) return null;

                return (SchedulerAlgorithem)index;
            }
            set {
                if (value < 0 || value == null)
                {
                    algorithemDropDown.SelectedIndex = -1;
                }
                else {
                    algorithemDropDown.SelectedIndex = (int)value;
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            this.DialogResult = DialogResult.OK;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         