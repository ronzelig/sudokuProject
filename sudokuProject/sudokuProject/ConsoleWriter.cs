using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public class ConsoleWriter : Writer
    {
        /// <summary>
        /// prints the board in console
        /// </summary>
        /// <param name="board">the board we print</param>
        public override void writeBoard(Board board)
        {
            Console.WriteLine(board);
        }
    }
}
