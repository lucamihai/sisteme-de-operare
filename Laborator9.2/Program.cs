using System;
using System.Linq;
using Common;

namespace Laborator9._2
{
    class Program
    {
        private static IntPtr intPtrFile;
        private static string filePath = @"..\..\..\Laborator9.1\File.txt";
        private static IntPtr handleFileMutex;

        static void Main(string[] args)
        {
            InitializeIntPtrFileWriteAppend();
            WriteToFile();
        }

        private static void WriteToFile()
        {
            handleFileMutex = WinApiClass.OpenMutex(0x00100000, true, "FileMutex");
            uint ceva = 1;

            while (ceva != 0)
            {
                ceva = WinApiClass.WaitForSingleObject(handleFileMutex, WinApiClass.INFINITE);
            }

            var stringToWrite = Constants.StringToWrite;
            var buffer = stringToWrite.ToCharArray().Select(c => (byte)c).ToArray();

            var result = WinApiClass.WriteFile(
                intPtrFile,
                buffer,
                (uint)buffer.Length,
                out uint lpNumberOfBytesWritten,
                IntPtr.Zero
            );

            WinApiClass.ReleaseMutex(handleFileMutex);
        }

        private static void InitializeIntPtrFileWriteAppend()
        {
            intPtrFile = WinApiClass.CreateFile(
                filePath,
                WinApiClass.FileAccess.FILE_APPEND_DATA,
                WinApiClass.FileShare.Write | WinApiClass.FileShare.Read,
                IntPtr.Zero,
                WinApiClass.FileMode.OPEN_EXISTING,
                0,
                IntPtr.Zero
            );
        }
    }
}
