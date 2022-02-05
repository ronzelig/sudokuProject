using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    static class Controller
    {
        const string MENU_MESSAGE = "Please enter:\n" +
                                    "c - for console solver\n" +
                                    "f - for file solver\n" +
                                    "e - end program";
        
        const string INVALID_INPUT_MESSAGE = "invalid input. try again:\n";
        public static void startController()
        {
            Console.WriteLine(MENU_MESSAGE);
            string answer = Console.ReadLine();
            string boardInput = "";
            switch (answer)
            {
                case "c":
                    ConsoleReader cReader= new ConsoleReader();
                    boardInput = cReader.getBoard();
                    break;
                case "f":
                    FileReader fReader = new FileReader();
                    boardInput = fReader.getBoard();
                    break;
                case "e":
                    break;
                default:
                    Console.WriteLine(INVALID_INPUT_MESSAGE);
                    startController();
                    break;
            }
            if (answer != "e")
                Controller.startSolving(boardInput);
        }

        private static void startSolving(string boardInput)
        {
            try
            {
                Board board = new Board(boardInput);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Board solution = Solver.solve(board);
                if (solution == null)
                    throw new ArgumentException("error: unsolvable board");
                Console.WriteLine(solution);
                stopwatch.Stop();
                Console.WriteLine("Solving time is {0} seconds\n", stopwatch.ElapsedMilliseconds / 1000.0);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            startController();
        }
    }
}
