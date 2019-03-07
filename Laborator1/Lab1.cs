using System;
using System.IO;

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

            CheckForErrorAndNotify();

            byte[] bytes = new byte[512];
            uint bytesRead = 0;

            WinApiClass.ReadFile(
                intPtrReadFile,
                bytes,
                512,
                out bytesRead,
                IntPtr.Zero
                );

            for (int iteration = 0; iteration < 4; iteration++)
            {
                Console.WriteLine($" > Partitia {iteration + 1}");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine($"Boot Flag: {bytes[446 + iteration * 16].ToString("X")}");
                Console.WriteLine($"Adresa cap: {bytes[447 + iteration * 16].ToString("X")}");

                Console.WriteLine($"Cap sector: {((bytes[449 + iteration * 16] << 8) | bytes[448 + iteration * 16]).ToString("X")}");

                Console.WriteLine($"Tip partitie: {bytes[450 + iteration * 16].ToString("X")}");

                Console.WriteLine($"Sfarsit adresa cap: {bytes[451 + iteration * 16].ToString("X")}");
                Console.WriteLine($"Sfarsit adresa sector: {((bytes[453 + iteration * 16] << 8) | bytes[452 + iteration * 16]).ToString("X")}");

                Console.WriteLine($"Sectoare relative: {(int)(bytes[457 + iteration * 16] << 3 * 8) | (bytes[456 + iteration * 16] << 2 * 8) | (bytes[455 + iteration * 16] << 8) | bytes[454 + iteration * 16]}");

                Console.WriteLine($"Total sectoare: {(int)(bytes[461 + iteration * 16] << 3 * 8) | (bytes[460 + iteration * 16] << 2 * 8) | (bytes[459 + iteration * 16] << 8) | bytes[458 + iteration * 16]}\n");


                intPtrReadFile = new IntPtr(intPtrReadFile.ToInt64() + 512);
            }
        }

        private void CheckForErrorAndNotify()
        {
            int lastErrorCode = WinApiClass.GetLastError();
            if (lastErrorCode != 0)
            {
                Console.WriteLine($"Error code {lastErrorCode}");
                return;
            }
        }
    }
}
