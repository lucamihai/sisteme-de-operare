using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common;

namespace Laborator8
{
    public partial class MainForm : Form
    {
        private uint threadId1;
        private uint threadId2;
        private uint threadId3;
        private uint threadId4;

        private uint threadHandle1;
        private uint threadHandle2;
        private uint threadHandle3;
        private uint threadHandle4;

        private IntPtr eventHandleRadu;
        private IntPtr eventHandleCorina;
        private IntPtr eventHandleMaria;
        private IntPtr eventHandlerMusca;

        private uint t1;
        private uint t2;

        private List<ProgressBar> progressBars;
        private int[] thresholds = new[] { Constants.thresholdRadu, Constants.thresholdCorina, Constants.thresholdMaria };
        private List<IntPtr> eventHandlers;
        private bool[] flags = new[] { false, false, false, false };

        public MainForm()
        {
            InitializeComponent();     
            
        }
        
        private void something()
        {
            InitializeProgressBarList();
            InitializeEvents();
            InitializeThreads();
        }

        private void InitializeProgressBarList()
        {
            progressBars = new List<ProgressBar>
            {
                progressBarRadu,
                progressBarCorina,
                progressBarMaria,
                progressBarMusca
            };

            progressBarRadu.Maximum = Constants.ProgressBarMaxValueRadu;
            progressBarCorina.Maximum = Constants.ProgressBarMaxValueCorina;
            progressBarMaria.Maximum = Constants.ProgressBarMaxValueMaria;
            progressBarMusca.Maximum = Constants.ProgressBarMaxValueMusca;
        }

        private void InitializeThreads()
        {
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementProgressBar),
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementProgressBar),
                (IntPtr)GCHandle.Alloc(1),
                0,
                out threadId2
            );

            threadHandle3 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementProgressBar),
                (IntPtr)GCHandle.Alloc(2),
                0,
                out threadId3
            );

            threadHandle4 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementProgressBar),
                (IntPtr)GCHandle.Alloc(3),
                0,
                out threadId3
            );
        }

        private uint IncrementProgressBar(IntPtr lpParam)
        {
            var paramHandle = (GCHandle)lpParam;
            var progressBarIndex = (int)paramHandle.Target;
            var progressBar = progressBars[progressBarIndex];
            switch (progressBarIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        var result = WinApiClass.WaitForSingleObject(eventHandleRadu, t1);
                        if(result == WinApiClass.WAIT_TIMEOUT)
                        {
                            WinApiClass.SuspendThread((IntPtr) threadHandle1);
                        }
                        break;
                    }
                case 2:
                    {
                        var result = WinApiClass.WaitForSingleObject(eventHandleRadu, t1);
                        if (result == WinApiClass.WAIT_TIMEOUT)
                        {
                            WinApiClass.SuspendThread((IntPtr)threadHandle1);
                        }
                        break;
                    }
                case 3:
                    {
                        var result = WinApiClass.WaitForMultipleObjects(2,new[] { eventHandleCorina, eventHandleMaria },true, t2);
                        if (result == WinApiClass.WAIT_TIMEOUT)
                        {
                            WinApiClass.SuspendThread((IntPtr)threadHandle1);
                            WinApiClass.SuspendThread((IntPtr)threadHandle2);
                            WinApiClass.SuspendThread((IntPtr)threadHandle3);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show($"Something went wrong");
                        return 0;
                    }
            }

            while (progressBar.Value < progressBar.Maximum)
            {
                
                if(progressBarIndex!=progressBars.Count - 1)
                {
                    if (progressBar.Value == thresholds[progressBarIndex])
                    {
                        WinApiClass.SetEvent(eventHandlers[progressBarIndex]);
                    }
                }
                var methodInvoker = new MethodInvoker(() => progressBar.Value++);
                progressBar.Invoke(methodInvoker);
            }

            return 0;
        }

        private void InitializeEvents()
        {
            eventHandleRadu = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "radu");
            eventHandleCorina = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "corina");
            eventHandleMaria = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "maria");
            eventHandlerMusca = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "musca");
            eventHandlers = new List<IntPtr>() { eventHandleRadu, eventHandleCorina, eventHandleMaria, eventHandlerMusca };
        }

        private void StartReset(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals("Start"))
            {
                if(!TryParseTs()) return;
                something();
                WinApiClass.ResumeThread((IntPtr)threadHandle1);
                WinApiClass.ResumeThread((IntPtr)threadHandle2);
                WinApiClass.ResumeThread((IntPtr)threadHandle3);
                ((Button)sender).Text = "Reset";
            }
            else
            {
                ((Button)sender).Text = "Start";
                progressBars.ForEach(x => x.Value = 0);
                TerminateThreads();
                ResetEvents();
                
            }
        }

        private void TerminateThreads()
        {
            WinApiClass.TerminateThread(threadHandle1, 0);
            WinApiClass.TerminateThread(threadHandle2, 0);
            WinApiClass.TerminateThread(threadHandle3, 0);
            WinApiClass.TerminateThread(threadHandle4, 0);
        }

        private void ResetEvents()
        {
            WinApiClass.ResetEvent(eventHandleRadu);
            WinApiClass.ResetEvent(eventHandleCorina);
            WinApiClass.ResetEvent(eventHandleMaria);
            WinApiClass.ResetEvent(eventHandlerMusca);
        }

        private bool TryParseTs()
        {
            try
            {
                t1 = Convert.ToUInt32(textBoxT1.Text);
                t2= Convert.ToUInt32(textBoxT2.Text);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return false;
           
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
