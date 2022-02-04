using System;
using System.Diagnostics;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Board b = new Board("000000000000=00600000000000000000000000000000000003000?000000000000000002:000000000000000000000000000000000400000007000000000000000000300000>008000000000800000000000000>000000000000000000000090600;000000000=00000000600000000000000200003007000000000000000>0");
            b.printBoard();
            Console.WriteLine("\n");
            bool b1, b2;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            do
            {
                //b.printBoard();
                //Console.WriteLine("");
                b1 = Solver.nakedSingle(b);
                b2 = Solver.hiddenSingle(b);
            }
            while (b1 || b2);
            Solver.backTracking(b);
            //b.printBoard();
            //Console.WriteLine("\n");
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);


        }
    }
}
