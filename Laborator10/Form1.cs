using System;
using System.Windows.Forms;
using Common;

namespace Laborator10
{
    public partial class Form1 : Form
    {
        private IntPtr handleSemaphore;

        public Form1()
        {
            InitializeComponent();
            InitializeSemaphore();

            buttonOpenForm.Click += (sender, args) => { CreateAndShowFormIfSemaphoreIsFree(); };
        }

        private void InitializeSemaphore()
        {
            var securityAttributes = new WinApiClass.SECURITY_ATTRIBUTES();
            handleSemaphore = WinApiClass.CreateSemaphore(
                ref securityAttributes,
                10,
                10,
                "SemaphoreForms"
            );
        }

        private void CreateAndShowFormIfSemaphoreIsFree()
        {
            var dwWaitResult = WinApiClass.WaitForSingleObject(handleSemaphore, 0);

            if (dwWaitResult == WinApiClass.WAIT_TIMEOUT)
            {
                MessageBox.Show("CAN NOT OPEN ANY MORE FORMS.");
                return;
            }

            var form = new Form();
            form.FormClosed += (sender1, args1) =>
            {
                WinApiClass.ReleaseSemaphore(handleSemaphore, 1, IntPtr.Zero);
            };
            form.Show();
        }
    }
}
