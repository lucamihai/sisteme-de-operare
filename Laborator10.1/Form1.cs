using System;
using System.Threading;
using System.Windows.Forms;
using Common;

namespace Laborator10._1
{
    public partial class Form1 : Form
    {
        private IntPtr handleSemaphore;
        private IntPtr handleTimer;

        public Form1()
        {
            InitializeComponent();
            //InitializeSemaphore();
            InitializeTimer();
            //new Thread(SetTimer).Start();
            SetTimer();

        }

        private void InitializeSemaphore()
        {
            var securityAttributes = new WinApiClass.SECURITY_ATTRIBUTES();
            handleSemaphore = WinApiClass.CreateSemaphore(
                ref securityAttributes,
                5,
                5,
                "SemaphoreForms"
            );
        }

        private void InitializeTimer()
        {
            var securityAttributes = new WinApiClass.SECURITY_ATTRIBUTES();
            handleTimer = WinApiClass.CreateWaitableTimer(
                ref securityAttributes,
                false,
                "TimerMessageBoxes"
            );
        }

        private void SetTimer()
        {
            var dueTime = -10L * 10000000;
            WinApiClass.SetWaitableTimer(
                handleTimer,
                ref dueTime,
                2 * 1000,
                null,
                IntPtr.Zero, 
                false
            );
            var i = 0;
            while (i<5)
            {
                i++;
                CreateAndShowFormIfSemaphoreIsFree();
            }
        }

        private void CreateAndShowFormIfSemaphoreIsFree()
        {
            var dwWaitResult = WinApiClass.WaitForSingleObject(handleTimer, WinApiClass.INFINITE);

            if (dwWaitResult == WinApiClass.WAIT_TIMEOUT)
            {
                //labelNotification.Invoke((MethodInvoker)delegate { labelNotification.Text = "Tzeapa"; });
                return;
            }

            //var ceva = new Thread(() =>
            //{
                var form = new Form();
                var textBox = new TextBox();
                textBox.Text = DateTime.Now.ToLongTimeString();
                form.Controls.Add(textBox);
                form.FormClosed += (sender1, args1) =>
                {
                    WinApiClass.ReleaseSemaphore(handleSemaphore, 1, IntPtr.Zero);
                };
            form.Show();
            //Application.Run(form);
        //});
        //    ceva.Start();
        //    GC.KeepAlive(ceva);
        }
    }
}
