using System;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Board b = new Board("000000000901735280800010000003008001080001500012040009000006028060000000038192000");
            Board b = new Board("060000050109750000024000003081005000900003006003001248790146802000537960000000400");
            b.printBoard();
            while(Solver.nakedSingleSolver(b));
            Console.WriteLine("\n");
            b.printBoard();
            //Cell c = new Cell(3, 4, '3', 9);
        }
    }
}
