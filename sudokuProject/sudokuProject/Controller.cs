using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public static class Controller
    {
        const string MENU_MESSAGE = "Please enter:\n" +
                                    "c - for console solver\n" +
                                    "f - for file solver\n" +
                                    "e - end program";
        
        const string INVALID_INPUT_MESSAGE = "invalid input. try again:\n";
        /// <summary>
        /// prints the menu, gets the user's answer and continues according to the answer
        /// </summary>
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
                    Controller.startSolving(boardInput, "c");
                    break;
                case "f":
                    FileReader fReader = new FileReader();
                    boardInput = fReader.getBoard(); 
                    Controller.startSolving(boardInput, "f");
                    break;
                case "e":
                    break;
                default:
                    Console.WriteLine(INVALID_INPUT_MESSAGE);
                    startController();
                    break;
            }
        }
        /// <summary>
        /// creates a board using the user's input and tries to solve the sudoku
        /// </summary>
        /// <param name="boardInput"> the user's board input as a string </param>
        public static void startSolving(string boardInput, string method)
        {
            try
            {
                Board board = new Board(boardInput);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Board solution = Solver.solve(board);
                if (solution == null) //solving methind could not solve the board
                    throw new ArgumentException("error: unsolvable board");
                writeSolution(solution, method);
                stopwatch.Stop();
                Console.WriteLine("Solving time is {0} seconds\n", stopwatch.ElapsedMilliseconds / 1000.0);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            startController();
        }
        /// <summary>
        /// writes the solution according to the method
        /// </summary>
        /// <param name="board">the board we write</param>
        /// <param name="method"> the return method (console, file) </param>
        public static void writeSolution(Board board, string method)
        {
            switch (method)
            {
                case "c":
                    ConsoleWriter cWriter = new ConsoleWriter();
                    cWriter.writeBoard(board);
                    break;
                case "f":
                    FileWriter fWriter = new FileWriter();
                    fWriter.writeBoard(board);
                    break;
            }
        }
    }
}
