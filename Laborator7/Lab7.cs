using System;
using System.Data;
using System.Runtime.InteropServices;
using Common;

namespace Laborator7
{
    public class Lab7
    {
        private uint threadId1;
        private uint threadId2;
        private uint threadId3;

        private uint threadHandle1;
        private uint threadHandle2;
        private uint threadHandle3;

        private IntPtr eventHandleInput;
        private IntPtr eventHandleComputeDelta;
        private IntPtr eventHandleComputeFirstSolution;
        private IntPtr eventHandleComputeSecondSolution;

        private double a, b, c;
        private double delta;
        private double firstSolution, secondSolution;

        public void Start()
        {
            InitializeThreads();
            InitializeEvents();

            WinApiClass.ResumeThread((IntPtr)threadHandle1);
            WinApiClass.ResumeThread((IntPtr)threadHandle2);
            WinApiClass.ResumeThread((IntPtr)threadHandle3);

            InitializeCoefficients();

            ShowSolutions();
        }

        private void InitializeCoefficients()
        {
            Console.Write("a: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("b: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("c: ");
            c = Convert.ToInt32(Console.ReadLine());

            WinApiClass.SetEvent(eventHandleInput);
        }

        private void InitializeThreads()
        {
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(ComputeDelta),
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(ComputeFirstSolution),
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId2
            );

            threadHandle3 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(ComputeSecondSolution),
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId3
            );
        }

        private void InitializeEvents()
        {
            eventHandleInput = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "ReadFromKB");
            eventHandleComputeDelta = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "ComputeDelta");
            eventHandleComputeFirstSolution = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "ComputeFirstSolution");
            eventHandleComputeSecondSolution = WinApiClass.CreateEvent(IntPtr.Zero, true, false, "ComputeSecondSolution");
        }

        private uint ComputeDelta(IntPtr lpParam)
        {
            WinApiClass.WaitForSingleObject(eventHandleInput, WinApiClass.INFINITE);
            delta = b * b - (4 * a * c);

            if (delta < 0)
            {
                throw new Exception($"delta: {delta}");
            }

            WinApiClass.SetEvent(eventHandleComputeDelta);

            return 0;
        }

        private uint ComputeFirstSolution(IntPtr lpParam)
        {
            WinApiClass.WaitForSingleObject(eventHandleComputeDelta, WinApiClass.INFINITE);
            firstSolution = (-b + Math.Sqrt(delta)) / (2 * a);

            WinApiClass.SetEvent(eventHandleComputeFirstSolution);

            return 0;
        }

        private uint ComputeSecondSolution(IntPtr lpParam)
        {
            WinApiClass.WaitForSingleObject(eventHandleComputeDelta, WinApiClass.INFINITE);
            secondSolution = (-b - Math.Sqrt(delta)) / (2 * a);

            WinApiClass.SetEvent(eventHandleComputeSecondSolution);

            return 0;
        }

        private void ShowSolutions()
        {
            WinApiClass.WaitForMultipleObjects(
                2,
                new IntPtr[2] {eventHandleComputeFirstSolution, eventHandleComputeSecondSolution},
                true,
                WinApiClass.INFINITE
            );

            Console.WriteLine($"x1: {firstSolution}");
            Console.WriteLine($"x2: {secondSolution}");
        }
    }
}
