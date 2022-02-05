using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public class FileWriter : Writer
    {
        /// <summary>
        /// creates a file and writes the solution
        /// </summary>
        /// <param name="board">the board we write</param>
        public override void writeBoard(Board board)
        {
            string path = Directory.GetCurrentDirectory()+ "/solution.txt";
            File.WriteAllText(path, board.toStringOneLine());
            Console.WriteLine("the solution is in "+ path);
        }
    }
}
