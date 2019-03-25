using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;

namespace Laborator3
{
    public partial class Form1 : Form
    {
        private ListBox processListBox = new ListBox
        {
            Width = 200,
            Height = 300
        };

        public Form1()
        {
            InitializeComponent();

            Controls.Add(processListBox);

            var processes = GetProcesses();
            UpdateList(processes);
        }

        private List<Proces> GetProcesses()
        {
            var list = new List<Proces>();

            var handle = WinApiClass.CreateToolhelp32Snapshot(2, 0);
            var processEntry = new WinApiClass.PROCESSENTRY32
            {
                dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(WinApiClass.PROCESSENTRY32))
            };

            WinApiClass.Process32First(handle, ref processEntry);
            do
            {
                var process = new Proces
                {
                    ID = processEntry.th32ProcessID,
                    Nume = processEntry.szExeFile
                };
                list.Add(process);
            }
            while (WinApiClass.Process32Next(handle, ref processEntry));

            return list;
        }

        private void UpdateList(List<Proces> processes)
        {
            processListBox.Items.Clear();
            foreach (var process in processes)
            {
                processListBox.Items.Add(process.ToString());
            }
        }

        private void buttonEndTask_Click(object sender, System.EventArgs e)
        {
            var selectedProcess = processListBox.SelectedItem as string;
            var processID = Convert.ToInt32(selectedProcess.Split('#')[0]);

            var ptr = WinApiClass.OpenProcess(1, true, processID);
            WinApiClass.TerminateProcess(ptr, 0);

            MessageBox.Show(WinApiClass.GetLastError().ToString());

            var processes = GetProcesses();
            UpdateList(processes);
        }
    }
}
