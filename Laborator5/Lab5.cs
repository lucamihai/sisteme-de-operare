using System;
using System.Runtime.InteropServices;
using Common;

namespace Laborator5
{
    public class Lab5
    {
        private uint threadId1;
        private uint threadId2;

        private uint threadHandle1;
        private uint threadHandle2;

        private int globalCounter;

        private WinApiClass.CRITICAL_SECTION criticalSection;

        public Lab5()
        {
            WinApiClass.InitializeCriticalSection(out criticalSection);

            InitializeThreads();
        }

        public void Start()
        {
            WinApiClass.ResumeThread((IntPtr)threadHandle1);
            WinApiClass.ResumeThread((IntPtr)threadHandle2);
        }

        ~Lab5()
        {
            WinApiClass.DeleteCriticalSection(ref criticalSection);
        }

        private uint IncrementGlobalCounter(IntPtr lpParam)
        {
            var paramHandle = (GCHandle)lpParam;
            var threadNumber = (int)paramHandle.Target;

            while (true)
            {
                WinApiClass.EnterCriticalSection(ref criticalSection);

                for (int iteration = 0; iteration < 4; iteration++)
                {
                    globalCounter++;
                    if (threadNumber == 1)
                    {
                        Console.WriteLine($"{threadNumber}: Global counter: {globalCounter}");
                    }
                    else
                    {
                        Console.WriteLine($"                {threadNumber}: Global counter: {globalCounter}");
                    }
                }

                WinApiClass.LeaveCriticalSection(ref criticalSection);
            }
        }

        private void InitializeThreads()
        {
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementGlobalCounter),
                (IntPtr)GCHandle.Alloc(1),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(IncrementGlobalCounter),
                (IntPtr)GCHandle.Alloc(2),
                0,
                out threadId2
            );
        }
    }
}
