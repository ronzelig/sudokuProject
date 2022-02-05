using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public abstract class Writer
    {
        /// <summary>
        /// writes the board
        /// </summary>
        /// <param name="board"></param>
        public abstract void writeBoard(Board board);
    }
}
