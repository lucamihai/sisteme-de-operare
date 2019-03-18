using System;
using System.IO;
using Common;

namespace Laborator1
{
    public class Lab1
    {
        private string MbrFilePath
        {
            get
            {
                var fileName = "MBR.BIN";
                var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

                return path;
            }
        }

        public void CitesteChestiiDinMbr()
        {
            var intPtrReadFile = WinApiClass.CreateFile(
                MbrFilePath,
                WinApiClass.FileAccess.GenericRead,
                WinApiClass.FileShare.None,
                IntPtr.Zero,
                WinApiClass.FileMode.OPEN_EXISTING,
                0,
                IntPtr.Zero
            );

            CheckForErrorAndThrowIfError();

            byte[] buffer = new byte[Constants.SectorSizeInBytes];
            uint bytesRead = 0;

            WinApiClass.ReadFile(
                intPtrReadFile,
                buffer,
                (uint)Constants.SectorSizeInBytes,
                out bytesRead,
                IntPtr.Zero
                );

            for (int iteration = 0; iteration < 4; iteration++)
            {
                Console.WriteLine($" > Partition {iteration + 1}");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine($"Boot Flag: {buffer[446 + iteration * 16].ToString("X")}");
                Console.WriteLine($"Head address: {buffer[447 + iteration * 16].ToString("X")}");

                Console.WriteLine($"Sector head: {((buffer[449 + iteration * 16] << 8) | buffer[448 + iteration * 16]).ToString("X")}");

                Console.WriteLine($"Partition type: {buffer[450 + iteration * 16].ToString("X")}");

                Console.WriteLine($"Head address end: {buffer[451 + iteration * 16].ToString("X")}");
                Console.WriteLine($"Sector address end: {((buffer[453 + iteration * 16] << 8) | buffer[452 + iteration * 16]).ToString("X")}");

                Console.WriteLine($"Relative sectors: {(int)(buffer[457 + iteration * 16] << 3 * 8) | (buffer[456 + iteration * 16] << 2 * 8) | (buffer[455 + iteration * 16] << 8) | buffer[454 + iteration * 16]}");

                Console.WriteLine($"Total sectors: {(int)(buffer[461 + iteration * 16] << 3 * 8) | (buffer[460 + iteration * 16] << 2 * 8) | (buffer[459 + iteration * 16] << 8) | buffer[458 + iteration * 16]}\n");


                intPtrReadFile = new IntPtr(intPtrReadFile.ToInt64() + 512);
            }
        }

        private void CheckForErrorAndThrowIfError()
        {
            int lastErrorCode = WinApiClass.GetLastError();
            if (lastErrorCode != 0)
            {
                throw new Exception($"Got error code {lastErrorCode} when reading MBR.BIN");
            }
        }
    }
}
