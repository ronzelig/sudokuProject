using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    static class BoardValidator
    {
        /// <summary>
        /// send the board input to validation functions
        /// </summary>
        /// <param name="input"> the user's board input as a string </param>
        public static void validateInput(string input)
        {
            checkEmptyString(input);
            validateLength(input);
            validateChars(input);
        }
        /// <summary>
        /// vhecks if the string input is empty
        /// </summary>
        /// <param name="input"> the user's board input as a string </param> </param>
        private static void checkEmptyString(string input)
        {
            if (input.Length == 0)
                throw new ArgumentException("error: empty board");
        }
        /// <summary>
        /// checks if the length of the board input is valid (valid board size)
        /// </summary>
        /// <param name="input"> the user's board input as a string </param>
        public static void validateLength(string input)
        {
            if(Math.Sqrt(Math.Sqrt(input.Length)) % 1 != 0)           
                throw new ArgumentException("error: invalid board size");            
        }
        /// <summary>
        /// checks if every char in the board is valid by the size of the board (example: '6' is not legal for 4*4 board)
        /// </summary>
        /// <param name="input"> the user's board input as a string </param>
        public static void validateChars(string input)
        {
            int dimentionSize = (int)Math.Sqrt(input.Length);
            foreach (char value in input)
            {
                if (value < '0' || value > (char)('0' + dimentionSize))
                    throw new ArgumentException("error: '" + value + "' is not a valid value for this board");
            }
        }
        /// <summary>
        /// checks if the board is valid (not more than 1 identical value in every row, col and square)
        /// </summary>
        /// <param name="sudokoBoard"> the board that was created according to the user's input </param>
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
