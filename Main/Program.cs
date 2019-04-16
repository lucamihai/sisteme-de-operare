using System;
using Laborator6;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReadingAndWriting = new FileReadingAndWriting();
            fileReadingAndWriting.Start();

            var matrixReading = new MatrixReading();
            matrixReading.Start();

            Console.Read();
            Environment.Exit(0);
        }
    }
}
