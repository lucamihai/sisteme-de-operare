using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common;

namespace Laborator4
{
    public partial class MainForm : Form
    {
        private bool Thread1Running
        {
            get => buttonSuspend1.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)threadHandle1);
                    buttonSuspend1.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)threadHandle1);
                    buttonSuspend1.Text = "Resume";
                }
            }
        }

        private bool Thread2Running
        {
            get => buttonSuspend2.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)threadHandle2);
                    buttonSuspend2.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)threadHandle2);
                    buttonSuspend2.Text = "Resume";
                }
            }
        }

        private bool Thread3Running
        {
            get => buttonSuspend3.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)threadHandle3);
                    buttonSuspend3.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)threadHandle3);
                    buttonSuspend3.Text = "Resume";
                }
            }
        }

        private bool Thread4Running
        {
            get => buttonSuspend4.Text == "Suspend";
            set
            {
                if (value)
                {
                    WinApiClass.ResumeThread((IntPtr)threadHandle4);
                    buttonSuspend4.Text = "Suspend";
                }
                else
                {
                    WinApiClass.SuspendThread((IntPtr)threadHandle4);
                    buttonSuspend4.Text = "Resume";
                }
            }
        }

        private uint threadId1;
        private uint threadId2;
        private uint threadId3;
        private uint threadId4;

        private uint threadHandle1;
        private uint threadHandle2;
        private uint threadHandle3;
        private uint threadHandle4;

        private List<ProgressBar> progressBars;

        public MainForm()
        {
            InitializeComponent();
            InitializeProgressBarLimits();
            InitializeProgressBarList();

            buttonSuspend1.Enabled = false;
            buttonSuspend2.Enabled = false;
            buttonSuspend3.Enabled = false;
            buttonSuspend4.Enabled = false;
            buttonKillThreads.Enabled = false;
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
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)IncrementProgressBar,
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)IncrementProgressBar,
                (IntPtr)GCHandle.Alloc(1),
                0,
                out threadId2
            );

            threadHandle3 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)IncrementProgressBar,
                (IntPtr)GCHandle.Alloc(2),
                0,
                out threadId3
            );

            threadHandle4 = WinApiClass.CreateThread(
                IntPtr.Zero,
                32000,
                (WinApiClass.LPTHREAD_START_ROUTINE)IncrementProgressBar,
                (IntPtr)GCHandle.Alloc(3),
                0,
                out threadId4
            );
        }

        private void InitializeProgressBarList()
        {
            progressBars = new List<ProgressBar>
            {
                progressBar1,
                progressBar2,
                progressBar3,
                progressBar4
            };
        }

        private uint IncrementProgressBar(IntPtr lpParam)
        {
            var paramHandle = (GCHandle)lpParam;
            var progressBarIndex = (int)paramHandle.Target;
            var progressBar = progressBars[progressBarIndex];

            while (progressBar.Value < Constants.ProgressBarMaximumValue)
            {
                var methodInvoker = new MethodInvoker(() => progressBar.Value++);
                progressBar.Invoke(methodInvoker);
            }

            return 0;
        }

        private void SuspendThread1(object sender, EventArgs e)
        {
            Thread1Running = !Thread1Running;
        }

        private void SuspendThread2(object sender, EventArgs e)
        {
            Thread2Running = !Thread2Running;
        }

        private void SuspendThread3(object sender, EventArgs e)
        {
            Thread3Running = !Thread3Running;
        }

        private void SuspendThread4(object sender, EventArgs e)
        {
            Thread4Running = !Thread4Running;
        }

        private void StartThreads(object sender, EventArgs e)
        {
            InitializeThreads();

            Thread1Running = true;
            Thread2Running = true;
            Thread3Running = true;
            Thread4Running = true;

            buttonSuspend1.Enabled = true;
            buttonSuspend2.Enabled = true;
            buttonSuspend3.Enabled = true;
            buttonSuspend4.Enabled = true;
            buttonKillThreads.Enabled = true;

            WinApiClass.SetThreadPriority((IntPtr)threadId1, WinApiClass.ThreadPriority.THREAD_PRIORITY_IDLE);
            WinApiClass.SetThreadPriority((IntPtr)threadId2, WinApiClass.ThreadPriority.THREAD_PRIORITY_BELOW_NORMAL);
            WinApiClass.SetThreadPriority((IntPtr)threadId3, WinApiClass.ThreadPriority.THREAD_PRIORITY_NORMAL);
            WinApiClass.SetThreadPriority((IntPtr)threadId4, WinApiClass.ThreadPriority.THREAD_PRIORITY_ABOVE_NORMAL);

            buttonStartThreads.Enabled = false;
        }

        private void KillThreads(object sender, EventArgs e)
        {
            WinApiClass.TerminateThread(threadHandle1, 0);
            WinApiClass.TerminateThread(threadHandle2, 0);
            WinApiClass.TerminateThread(threadHandle3, 0);
            WinApiClass.TerminateThread(threadHandle4, 0);

            buttonSuspend1.Enabled = false;
            buttonSuspend2.Enabled = false;
            buttonSuspend3.Enabled = false;
            buttonSuspend4.Enabled = false;
        }

        private void TimeThread1(object senders, EventArgs e)
        {
            GetAndDisplayValuesForThread(threadHandle1);
        }

        private void TimeThread2(object sender, EventArgs e)
        {
            GetAndDisplayValuesForThread(threadHandle2);
        }

        private void TimeThread3(object sender, EventArgs e)
        {
            GetAndDisplayValuesForThread(threadHandle3);
        }

        private void TimeThread4(object sender, EventArgs e)
        {
            GetAndDisplayValuesForThread(threadHandle4);
        }

        private void GetAndDisplayValuesForThread(uint threadHandle)
        {
            var lpCreationTime = new WinApiClass.FILETIME();
            var lpExitTime = new WinApiClass.FILETIME();
            var lpKernelTime = new WinApiClass.FILETIME();
            var lpUserTime = new WinApiClass.FILETIME();

            WinApiClass.GetThreadTimes(
                (IntPtr) threadHandle,
                out lpCreationTime,
                out lpExitTime, 
                out lpKernelTime,
                out lpUserTime
            );

            var lpSystemTimeCreationTime = new WinApiClass.SYSTEMTIME();
            var lpSystemTimeExitTime = new WinApiClass.SYSTEMTIME();
            var lpSystemTimeKernelTime = new WinApiClass.SYSTEMTIME();
            var lpSystemTimeUserTime = new WinApiClass.SYSTEMTIME();

            WinApiClass.FileTimeToSystemTime(ref lpCreationTime, out lpSystemTimeCreationTime);
            WinApiClass.FileTimeToSystemTime(ref lpExitTime, out lpSystemTimeExitTime);
            WinApiClass.FileTimeToSystemTime(ref lpKernelTime, out lpSystemTimeKernelTime);
            WinApiClass.FileTimeToSystemTime(ref lpUserTime, out lpSystemTimeUserTime);

            var systemCreationTimeString = GetStringRepresentationForSystemTime(lpSystemTimeCreationTime);
            var systemExitTimeString = GetStringRepresentationForSystemTime(lpSystemTimeExitTime);

            textBoxTimeData.Text = $"Creation time: {systemCreationTimeString}\r\nExit time: {systemExitTimeString}\r\n";
            textBoxTimeData.Text += $"Kernel time: {lpSystemTimeKernelTime.Milliseconds} ms\r\n";
            textBoxTimeData.Text += $"User time: {lpSystemTimeUserTime.Milliseconds} ms";
        }

        private string GetStringRepresentationForSystemTime(WinApiClass.SYSTEMTIME systemTime)
        {
            return
                $"{systemTime.Day}.{systemTime.Month}.{systemTime.Year} {systemTime.Hour}:{systemTime.Minute}:{systemTime.Milliseconds}";
        }
    }
}
