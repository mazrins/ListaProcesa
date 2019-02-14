using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ListaProcesa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listAllProcesses();
            timer1.Start();
            

        }
        public string processMethod(string processName)
        {
            PerformanceCounter myAppCpu = new PerformanceCounter("Process","% Processor Time", processName, true);
            double ptc = myAppCpu.NextValue();
            Thread.Sleep(50);
            ptc = myAppCpu.NextValue();
            return ptc.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public void listAllProcesses()
        {
          
            Process[] AllProcess = Process.GetProcesses();
            foreach (Process proc in AllProcess)
            {
                var a = processMethod(proc.ProcessName.ToString());
                try
                {
                    dataGridView1.Rows.Add(proc.ProcessName, proc.Id,proc.BasePriority,proc.PrivateMemorySize64,a);

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            dataGridView1.Update();
            dataGridView1.Refresh();
            

        }
    }
}
