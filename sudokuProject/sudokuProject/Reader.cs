using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public abstract class Reader
    {
        /// <summary>
        /// gets a board from the user in any way and returns the board as a string
        /// </summary>
        /// <returns></returns>
        public abstract string getBoard();
    }
}
