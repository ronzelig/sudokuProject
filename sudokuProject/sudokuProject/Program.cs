using System;
using System.Diagnostics;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board b = new Board("00<00010020008000003?=<001:4500000@>;007500=?30020=706800?>0410;000000?>23000000<02;=90@:05>1?07>50000000000003600180002;0009=0000?:00014000@<004;000000000000?8107<240;=0?83:0500000063<:000000@09?0<200;70=5030031500?>0027;0000057>;00<13800000;000@004000900");
                //Board b = new Board("2");
                Console.WriteLine(b + "\n");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Board solution = Solver.solve(b);
                if (solution == null)
                    throw new ArgumentException("error: unsolvable board");
                Console.WriteLine(solution);
                stopwatch.Stop();
                Console.WriteLine("Solving time is {0} seconds", stopwatch.ElapsedMilliseconds / 1000.0);
            }
            catch(ArgumentException ae){
                Console.WriteLine(ae.Message);
            }
            //Console.WriteLine(b+"\n");          
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Board solution = Solver.solve(b);
            //Console.WriteLine(solution);
            //stopwatch.Stop();
            //Console.WriteLine("Solving time is {0} seconds", stopwatch.ElapsedMilliseconds/1000.0);


        }
    }
}
