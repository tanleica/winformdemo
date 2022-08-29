using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class Form1 : Form
    {

        private int thread1Counter;
        private int thread2Counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ConfigurationManager.ConnectionStrings["ZKTECOEntities"].ConnectionString;
        }

        private void buttonStartThread_Click(object sender, EventArgs e)
        {
            Loop1();
            Loop2();
        }

        private void Loop1()
        {
            new Thread(() =>
            {
                bool response = Threat1Proc();
                if (response) Loop1();
            }).Start();
        }

        private void Loop2()
        {
            new Thread(() =>
            {
                bool response = Threat2Proc();
                if (response) Loop2();
            }).Start();
        }

        private bool Threat1Proc()
        {
            try
            {
                thread1Counter = 0;
                while (thread1Counter < 10)
                {
                    thread1Counter++;
                    label2.Invoke(new Action(() => label2.Text = "Thread 1 is running in count of " + thread1Counter));
                    Thread.Sleep(1000);
                }
                return true;
            } catch
            {
                return false;
            }
        }

        private bool Threat2Proc()
        {
            try
            {
                thread2Counter = 0;
                while (thread1Counter < 10)
                {
                    thread2Counter++;
                    label3.Invoke(new Action(() => label3.Text = "Thread 2 is running in count of " + thread2Counter));
                    Thread.Sleep(2000);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
