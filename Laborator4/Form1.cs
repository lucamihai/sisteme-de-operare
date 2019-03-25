using System;
using System.Windows.Forms;
using Common;

namespace Laborator4
{
    public partial class Form1 : Form
    {
        private bool Thread1Running
        {
            get => button1.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)handle1);
                    button1.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)handle1);
                    button1.Text = "Resume";
                }
            }
        }

        private bool Thread2Running
        {
            get => button2.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)handle2);
                    button2.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)handle2);
                    button2.Text = "Resume";
                }
            }
        }

        private bool Thread3Running
        {
            get => button3.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)handle3);
                    button3.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)handle3);
                    button3.Text = "Resume";
                }
            }
        }

        private bool Thread4Running
        {
            get => button4.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)handle4);
                    button4.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)handle4);
                    button4.Text = "Resume";
                }
            }
        }

        private uint thread1Id;
        private uint thread2Id;
        private uint thread3Id;
        private uint thread4Id;

        private uint handle1;
        private uint handle2;
        private uint handle3;
        private uint handle4;

        public Form1()
        {
            InitializeComponent();
            InitializeProgressBarLimits();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void InitializeProgressBarLimits()
        {
            progressBar1.Minimum = Constants.ProgressBarMinimumValue;
            progressBar1.Maximum = Constants.ProgressBarMaximumValue;

            progressBar2.Minimum = Constants.ProgressBarMinimumValue;
            progressBar2.Maximum = Constants.ProgressBarMaximumValue;

            progressBar3.Minimum = Constants.ProgressBarMinimumValue;
            progressBar3.Maximum = Constants.ProgressBarMaximumValue;

            progressBar4.Minimum = Constants.ProgressBarMinimumValue;
            progressBar4.Maximum = Constants.ProgressBarMaximumValue;
        }

        private void InitializeThreads()
        {
            handle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)DoStuff1,
                IntPtr.Zero,
                0,
                out thread1Id
            );

            handle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)DoStuff2,
                IntPtr.Zero,
                0,
                out thread2Id
            );

            handle3 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)DoStuff3,
                IntPtr.Zero,
                0,
                out thread3Id
            );

            handle4 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)DoStuff4,
                IntPtr.Zero,
                0,
                out thread4Id
            );
        }

        private uint DoStuff1(IntPtr intPtr)
        {
            while (progressBar1.Value < Constants.ProgressBarMaximumValue)
            {
                
                var methodInvoker = new MethodInvoker(() => progressBar1.Value++);
                progressBar1.Invoke(methodInvoker);
            }

            return 0;
        }

        private uint DoStuff2(IntPtr intPtr)
        {
            while (progressBar2.Value < Constants.ProgressBarMaximumValue)
            {
                var methodInvoker = new MethodInvoker(() => progressBar2.Value++);
                progressBar2.Invoke(methodInvoker);
            }

            return 0;
        }

        private uint DoStuff3(IntPtr intPtr)
        {
            while (progressBar3.Value < Constants.ProgressBarMaximumValue)
            {
                var methodInvoker = new MethodInvoker(() => progressBar3.Value++);
                progressBar3.Invoke(methodInvoker);
            }

            return 0;
        }

        private uint DoStuff4(IntPtr intPtr)
        {
            while (progressBar4.Value < Constants.ProgressBarMaximumValue)
            {
                var methodInvoker = new MethodInvoker(() => progressBar4.Value++);
                progressBar4.Invoke(methodInvoker);
            }

            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread1Running = !Thread1Running;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread2Running = !Thread2Running;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread3Running = !Thread3Running;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread4Running = !Thread4Running;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitializeThreads();

            Thread1Running = true;
            Thread2Running = true;
            Thread3Running = true;
            Thread4Running = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;

            WinApiClass.SetThreadPriority((IntPtr)thread1Id, WinApiClass.ThreadPriority.THREAD_PRIORITY_IDLE);
            WinApiClass.SetThreadPriority((IntPtr)thread2Id, WinApiClass.ThreadPriority.THREAD_PRIORITY_BELOW_NORMAL);
            WinApiClass.SetThreadPriority((IntPtr)thread3Id, WinApiClass.ThreadPriority.THREAD_PRIORITY_NORMAL);
            WinApiClass.SetThreadPriority((IntPtr)thread4Id, WinApiClass.ThreadPriority.THREAD_PRIORITY_ABOVE_NORMAL);

            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WinApiClass.TerminateThread(handle1, 0);
            WinApiClass.TerminateThread(handle2, 0);
            WinApiClass.TerminateThread(handle3, 0);
            WinApiClass.TerminateThread(handle4, 0);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
