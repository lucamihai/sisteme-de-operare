using System;
using System.Threading;
using Common;

namespace Laborator9._1
{
    class Program
    {
        private static IntPtr intPtrFile;
        private static string filePath = @"..\..\..\Laborator9.1\File.txt";
        private static IntPtr handleFileMutex;

        static void Main(string[] args)
        {
            InitializeIntPtrFileRead();
            ReadFile();
        }

        private static void InitializeIntPtrFileRead()
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

        private static void ReadFile()
        {
            handleFileMutex = WinApiClass.CreateMutex(IntPtr.Zero, true, "FileMutex");

            var hasToRead = true;
            while (hasToRead)
            {
                Thread.Sleep(200);
                var buffer = new byte[Constants.NumberOfBytesToRead];
                hasToRead = WinApiClass.ReadFile(
                    intPtrFile,
                    buffer,
                    Constants.NumberOfBytesToRead,
                    out var bytesRead,
                    IntPtr.Zero
                );
                if (bytesRead <= 0) break;

                foreach (var asciiCode in buffer)
                {
                    var character = (char)asciiCode;
                    Console.Write(character);
                }
            }

            WinApiClass.ReleaseMutex(handleFileMutex);
        }
    }
}
