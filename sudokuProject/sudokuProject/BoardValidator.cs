using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    static class BoardValidator
    {
        public static void validateInput(string input)
        {
            checkEmptyString(input);
            validateLength(input);
            validateChars(input);
        }

        private static void checkEmptyString(string input)
        {
            if (input.Length == 0)
                throw new ArgumentException("error: empty board");
        }

        public static void validateLength(string input)
        {
            if(Math.Sqrt(Math.Sqrt(input.Length)) % 1 != 0)           
                throw new ArgumentException("error: invalid board size");            
        }

        public static void validateChars(string input)
        {
            int dimentionSize = (int)Math.Sqrt(input.Length);
            foreach (char value in input)
            {
                if (value < '0' || value > (char)('0' + dimentionSize))
                    throw new ArgumentException("error: '" + value + "' is not a valid value for this board");
            }
        }

        public static void validateBoard(Board sudokoBoard)
        {
            foreach(Cell cell in sudokoBoard.board)
            {
                if (!cell.isEmpty())
                {
                    if (sudokoBoard.rowsValues[cell.row, cell.value - '0'] > 1)
                        throw new ArgumentException("error: more than one '" + cell.value + "' in the same row");
                    if (sudokoBoard.colsValues[cell.col, cell.value - '0'] > 1)
                        throw new ArgumentException("error: more than one '" + cell.value + "' in the same col");
                    if (sudokoBoard.squaresValues[cell.square, cell.value - '0'] > 1)
                        throw new ArgumentException("error: more than one '" + cell.value + "' in the same square");
                }
            }
        }
    }
}
