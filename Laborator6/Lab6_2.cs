using System;
using System.Runtime.InteropServices;
using Common;

namespace Laborator6
{
    public class Lab6_2
    {
        private uint threadId1;
        private uint threadId2;
        private uint threadId3;
        private uint threadId4;
        private uint threadId5;
        private uint threadId6;

        private uint threadHandle1;
        private uint threadHandle2;
        private uint threadHandle3;
        private uint threadHandle4;
        private uint threadHandle5;
        private uint threadHandle6;

        private int[,] matrix;
        private int[] rowMinimum = new int[5];

        private WinApiClass.CRITICAL_SECTION criticalSection;

        public Lab6_2()
        {
            WinApiClass.InitializeCriticalSection(out criticalSection);
        }

        public void Start()
        {
            matrix = GenerateRandomMatrix();
            for (int i = 0; i < 5; i++)
            {
                rowMinimum[i] = int.MaxValue;
            }

            InitializeThreads();

            WinApiClass.ResumeThread((IntPtr)threadHandle1);
            WinApiClass.ResumeThread((IntPtr)threadHandle2);
            WinApiClass.ResumeThread((IntPtr)threadHandle3);
            WinApiClass.ResumeThread((IntPtr)threadHandle4);
            WinApiClass.ResumeThread((IntPtr)threadHandle5);
            WinApiClass.ResumeThread((IntPtr)threadHandle6);
        }

        private int[,] GenerateRandomMatrix()
        {
            var matrix = new int[5, Constants.MatrixColumnLength];
            var rng = new Random();
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < Constants.MatrixColumnLength; column++)
                {
                    matrix[row, column] = rng.Next(1, 9);
                }
            }

            return matrix;
        }

        private void InitializeThreads()
        {
            threadHandle1 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetMinimumValueFromRow),
                (IntPtr)GCHandle.Alloc(0),
                0,
                out threadId1
            );

            threadHandle2 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetMinimumValueFromRow),
                (IntPtr)GCHandle.Alloc(1),
                0,
                out threadId2
            );

            threadHandle3 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetMinimumValueFromRow),
                (IntPtr)GCHandle.Alloc(2),
                0,
                out threadId3
            );

            threadHandle4 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetMinimumValueFromRow),
                (IntPtr)GCHandle.Alloc(3),
                0,
                out threadId4
            );

            threadHandle5 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetMinimumValueFromRow),
                (IntPtr)GCHandle.Alloc(4),
                0,
                out threadId5
            );

            threadHandle6 = WinApiClass.CreateThread(
                IntPtr.Zero,
                0,
                new WinApiClass.LPTHREAD_START_ROUTINE(GetSmallestMinimum),
                IntPtr.Zero,
                0,
                out threadId6
            );
        }

        private uint GetMinimumValueFromRow(IntPtr lpParam)
        {
            WinApiClass.EnterCriticalSection(ref criticalSection);

            var paramHandle = (GCHandle)lpParam;
            var rowNumber = (int)paramHandle.Target;
            for (int col = 0; col < Constants.MatrixColumnLength; col++)
            {
                if (matrix[rowNumber, col] < rowMinimum[rowNumber])
                {
                    rowMinimum[rowNumber] = matrix[rowNumber, col];
                }
            }

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            return 0;
        }
        private uint GetSmallestMinimum(IntPtr lpParam)
        { 
            var min = int.MaxValue;

            WinApiClass.EnterCriticalSection(ref criticalSection);

            for (int col = 0; col < 5; col++)
            {
                if (rowMinimum[col] < min)
                {
                    min = rowMinimum[ col];
                }
            }

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            Console.WriteLine($"MINIMUL ESTE {min}");

            return 0;
        }
    }
}
