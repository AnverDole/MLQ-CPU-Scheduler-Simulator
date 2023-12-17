using MLQ___CPU_Scheduler_Simulator.MQLScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLQ___CPU_Scheduler_Simulator
{
    public partial class NewProcessFrm : Form
    {

        public enum FormType { NEW, EDIT }
        private List<Queue> queues = new List<Queue>();
        public NewProcessFrm()
        {
            InitializeComponent(); 
        }

        public string ProcessName {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }
        public int ArrivelTime
        {
            get { return (int)arrivelTimeNumBox.Value; }
            set { arrivelTimeNumBox.Value = value; }
        }
        public int BurstTime
        {
            get { return (int)burstTimeNumBox.Value; }
            set { burstTimeNumBox.Value = value; }
        }
        public void SetQueues(List<Queue> queues) {
            this.queues = queues;

            queueDropDown.Items.Clear();
            foreach (Queue queue in queues) {
                queueDropDown.Items.Add(queue.queueName);
            }
            queueDropDown.SelectedItem = 0;
        }
        public Queue SelectedQueue {
            get{
                int selectedIndex = queueDropDown.SelectedIndex;
                return (Queue)queues.ElementAt(selectedIndex);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

       
    }
}
