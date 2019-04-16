using System;
using System.Runtime.InteropServices;
using System.Threading;
using Common;

namespace Laborator6
{
    public class MatrixReading
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
        private int[] rowMinimumValue = new int[Constants.MatrixRowLength];

        private WinApiClass.CRITICAL_SECTION criticalSection;

        public MatrixReading()
        {
            WinApiClass.InitializeCriticalSection(out criticalSection);
        }

        public void Start()
        {
            matrix = GenerateRandomMatrix();
            DisplayMatrix();
            for (int i = 0; i < 5; i++)
            {
                rowMinimumValue[i] = int.MaxValue;
            }

            InitializeThreads();

            WinApiClass.ResumeThread((IntPtr)threadHandle1);
            WinApiClass.ResumeThread((IntPtr)threadHandle2);
            WinApiClass.ResumeThread((IntPtr)threadHandle3);
            WinApiClass.ResumeThread((IntPtr)threadHandle4);
            WinApiClass.ResumeThread((IntPtr)threadHandle5);

            Thread.Sleep(50);

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

        private void DisplayMatrix()
        {
            Console.WriteLine($"Generated matrix:{Environment.NewLine}");
            for (int row = 0; row < Constants.MatrixRowLength; row++)
            {
                for (int column = 0; column < Constants.MatrixColumnLength; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }

                Console.WriteLine();
            }
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
                if (matrix[rowNumber, col] < rowMinimumValue[rowNumber])
                {
                    rowMinimumValue[rowNumber] = matrix[rowNumber, col];
                }
            }

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            return 0;
        }

        private uint GetSmallestMinimum(IntPtr lpParam)
        { 
            var minimumValue = int.MaxValue;

            WinApiClass.EnterCriticalSection(ref criticalSection);

            for (int col = 0; col < 5; col++)
            {
                if (rowMinimumValue[col] < minimumValue)
                {
                    minimumValue = rowMinimumValue[ col];
                }
            }

            WinApiClass.LeaveCriticalSection(ref criticalSection);

            Console.WriteLine($"Minimum value: {minimumValue}");

            return 0;
        }
    }
}
