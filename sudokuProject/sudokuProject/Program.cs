using System;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Board b = new Board("000000000901735280800010000003008001080001500012040009000006028060000000038192000");
            Board b = new Board("060000050109750000024000003081005000900003006003001248790146802000537960000000400");
            //b.printBoard();
            //while (Solver.nakedSingleSolver(b))
            //{
            //    Console.WriteLine("\n");
            //    b.printBoard();
            //}
            bool b1, b2;
            do
            {
                b.printBoard();
                Console.WriteLine("\n");
                b1 = Solver.nakedSingleSolver(b);
                b.printBoard();
                Console.WriteLine("\n");
                b2 = Solver.hiddenSingleSolver(b);
            }
            while (b1||b2);
            b.printBoard();
            
            //string indent = char.ToString('-');

            //Cell c = new Cell(3, 4, '3', 9);
        }
    }
}
