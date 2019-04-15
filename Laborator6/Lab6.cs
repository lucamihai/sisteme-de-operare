using System;
using System.Linq;
using System.Runtime.InteropServices;
using Common;

namespace Laborator6
{
    public class Lab6
    {
        private uint threadId1;
        private uint threadId2;

        private uint threadHandle1;
        private uint threadHandle2;

        private IntPtr intPtrFile;
        private string filePath = @"C:\Users\mihai.luca\Desktop\fisier.txt";

        private WinApiClass.CRITICAL_SECTION criticalSection;

        public Lab6()
        {
            WinApiClass.InitializeCriticalSection(out criticalSection);

            InitializeThreads();
        }

        public void Start()
        {
            WinApiClass.ResumeThread((IntPtr)threadHandle1);
            WinApiClass.ResumeThread((IntPtr)threadHandle2);
        }

        ~Lab6()
        {
            WinApiClass.DeleteCriticalSection(ref criticalSection);
        }

        private uint ReadFile(IntPtr lpParam)
        {
            WinApiClass.EnterCriticalSection(ref criticalSection);

            InitializeIntPtrFileRead();

            var hasToRead = true;
            while (hasToRead)
            {
                var buffer = new byte[Constants.NumberOfBytesToRead];
                hasToRead = WinApiClass.ReadFile(
                    intPtrFile,
                    buffer,
                    Constants.NumberOfBytesToRead,
                    out var bytesRead,
                    IntPtr.Zero
                );
                intPtrFile += (int)Constants.NumberOfBytesToRead;

                foreach (var asciiCode in buffer)
                {
                    var character = (char) asciiCode;
                    Console.Write(character);
                }
            }

            

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            return 0;
        }

        private void InitializeIntPtrFileRead()
        {
            intPtrFile = WinApiClass.CreateFile(
                filePath,
                WinApiClass.FileAccess.GenericRead,
                WinApiClass.FileShare.Write | WinApiClass.FileShare.Read,
                IntPtr.Zero,
                WinApiClass.FileMode.OPEN_EXISTING,
                0,
                IntPtr.Zero
            );
        }

        private void InitializeIntPtrFileWriteAppend()
        {
            intPtrFile = WinApiClass.CreateFile(
                filePath,
                WinApiClass.FileAccess.FILE_APPEND_DATA,
                WinApiClass.FileShare.Write,
                IntPtr.Zero,
                WinApiClass.FileMode.OPEN_EXISTING,
                0,
                IntPtr.Zero
            );
        }

        private uint WriteToFile(IntPtr lpParam)
        {
            WinApiClass.EnterCriticalSection(ref criticalSection);
            var intPtrFile2 = WinApiClass.CreateFile(
                filePath,
                WinApiClass.FileAccess.FILE_APPEND_DATA,
                WinApiClass.FileShare.Write | WinApiClass.FileShare.Read,
                IntPtr.Zero,
                WinApiClass.FileMode.OPEN_EXISTING,
                0,
                IntPtr.Zero
            );

            var stringToWrite = Constants.StringToWrite;
            var buffer = stringToWrite.ToCharArray().Select(c => (byte)c).ToArray();

            var result = WinApiClass.WriteFile(
                intPtrFile2,
                buffer,
                (uint)buffer.Length,
                out uint lpNumberOfBytesWritten,
                IntPtr.Zero
            );
            Console.WriteLine(result);

            

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            return 0;
        }

        private void InitializeThreads()
        {
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(ReadFile),
                (IntPtr)GCHandle.Alloc(1),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(WriteToFile),
                (IntPtr)GCHandle.Alloc(2),
                0,
                out threadId2
            );
        }
    }
}
