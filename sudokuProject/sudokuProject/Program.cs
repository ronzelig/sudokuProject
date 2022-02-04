using System;
using System.Diagnostics;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {         
            Board b = new Board("030>0:060092040?5@00<00;006300070?09000000040;@007000010@;00000000010>0000000=00600;0000092=4001090008;00000207" +
                "000040<0?0008050000>=160<0:700983000200001000;<?0<000;00:00@0=000@090>3070200:006000041?020050009>000070000;06030000060000>0:1" +
                "@50?20000300000000:");
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
            //Solver.backTracking(b);
            b.printBoard();
            Console.WriteLine("\n");
            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
