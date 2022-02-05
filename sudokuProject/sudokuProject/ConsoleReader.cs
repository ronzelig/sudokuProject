using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class ConsoleReader: Reader
    {
        const string REQUEST_BOARD = "Please enter board in one line:";
        /// <summary>
        /// console reader constructor
        /// </summary>
        public ConsoleReader()
        {

        }
        /// <summary>
        /// gets a board input from the user
        /// </summary>
        /// <returns> the user board input as a string </returns>
        public override string getBoard()
        {
            Console.WriteLine(REQUEST_BOARD);
            string boardInput = Console.ReadLine();
            return boardInput;
        }
    }
}
