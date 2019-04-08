using System;
using System.Threading;
using Common;

namespace Laborator2
{
    public class Lab2
    {
        public void LaunchProgram(string programName, string fileName)
        {
            WinApiClass.SECURITY_ATTRIBUTES processAttributes = new WinApiClass.SECURITY_ATTRIBUTES();
            WinApiClass.SECURITY_ATTRIBUTES threadAttributes = new WinApiClass.SECURITY_ATTRIBUTES();
            WinApiClass.STARTUPINFO startupinfo = new WinApiClass.STARTUPINFO();
            WinApiClass.PROCESS_INFORMATION processInformation = new WinApiClass.PROCESS_INFORMATION();

            WinApiClass.CreateProcess(
                programName,
                fileName,
                ref processAttributes,
                ref threadAttributes,
                false,
                0,
                IntPtr.Zero,
                Environment.CurrentDirectory,
                ref startupinfo,
                out processInformation
            );

            Thread.Sleep(2000);
            WinApiClass.TerminateProcess(processInformation.hProcess, 1);
            Console.WriteLine($"Last error: {WinApiClass.GetLastError()}");
        }
    }
}
