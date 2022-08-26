using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class Form1 : Form
    {

        private int ThreadCount;
        public Form1()
        {
            InitializeComponent();
            ThreadCount = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ConfigurationManager.ConnectionStrings["ZKTECOEntities"].ConnectionString;
        }

        private void buttonStartThread_Click(object sender, EventArgs e)
        {
            StartThreat();
        }

        private void StartThreat()
        {
            new Thread(() =>
            {
                int i = DemoThreadStart();
                if (i < 10)
                {
                    Thread.Sleep(1000);
                    StartThreat();
                }
            }).Start();
        }

        private int DemoThreadStart()
        {
            ThreadCount++;
            label2.Invoke(new Action(() => label2.Text = "Demo thread started in count of " + ThreadCount));
            Thread.Sleep(1000);
            return ThreadCount;
        }

    }
}
