using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public static class Solver
    {
        /// <summary>
        /// eliminates options of empty cells and sets a cell value if the value is the only option for the cell
        /// </summary>
        /// <param name="sudokuBoard"> the board we solve </param>
        /// <returns> returns rather or not an option was eliminated(if the method helped) </returns>
        public static bool nakedSingle(Board sudokuBoard)
        {
            bool eliminatedOptions = false;
            foreach (Cell cell in sudokuBoard.emptyCells.ToList())
            {
                    foreach (char option in cell.options.ToList())
                    {
                        if (!cell.isLegalValue(option, sudokuBoard))
                        {
                            deleteOption(option, cell, sudokuBoard);
                            eliminatedOptions = true;
                        }
                    }
                    if (cell.options.Count == 1)
                    {
                        insertValue(cell, cell.options[0], sudokuBoard);
                    }
            }
            return eliminatedOptions;
        }
        /// <summary>
        /// looping the empty cells and sets a cell's value if the cell is the only cell in his row/col/square that contains
        /// this value as an option
        /// </summary>
        /// <param name="sudokuBoard">the board we solve</param>
        /// <returns>returns rather or not a cell's value was found (if the methid helped) </returns>
        public static bool hiddenSingle(Board sudokuBoard)
        {
            bool foundHidden = false;            
            foreach(Cell cell in sudokuBoard.emptyCells.ToList())
            {
                    foreach (char option in cell.options.ToList())
                    {
                        if (isHiddenSingle(option, cell, sudokuBoard))
                        {
                            foundHidden = true;
                            insertValue(cell, option, sudokuBoard);
                            break;
                        }
                    }                
            }
            return foundHidden;
        }
        /// <summary>
        /// tries to solve the board using the previous methods and back-tracking(guessing all the options method)
        /// </summary>
        /// <param name="sudokuBoard">the board we solve</param>
        /// <returns> a solved board/null(if the board is unsolvable)</returns>
        public static Board solve(Board sudokuBoard)
        {
            runSimpleMethodsOnBoard(sudokuBoard); //runs naked single and hidden single to eliminate options and find values
            if (sudokuBoard.isSolved())
            {
                return sudokuBoard;
            }
            sudokuBoard.emptyCells.Sort(); //sorts the empty cells by their number of options
            Cell cell = sudokuBoard.emptyCells[0]; // selects the cell with the least options for efficiency
            foreach (char option in cell.options)
            {                
                    Board copyBoard = new Board(sudokuBoard);
                    Cell copyCell = copyBoard.board[cell.row, cell.col];
                    insertValue(copyCell, option, copyBoard); //guessing one of the options
                    Board result = solve(copyBoard); //tries to solve with the guess
                    if (result != null) // if succeeded to solve
                {
                        return result;
                    }               
            }
            return null; // if can't solve with none of the options
        }
        /// <summary>
        /// runs naked-single and hidden-single methins on the board as long as they help
        /// </summary>
        /// <param name="board">the board we solve</param>
        public static void runSimpleMethodsOnBoard(Board board)
        {
            bool nakedSingleHelped, hiddenSingleHelped;
            do
            {
                nakedSingleHelped = nakedSingle(board); 
                hiddenSingleHelped = hiddenSingle(board);
            }
            while (nakedSingleHelped || hiddenSingleHelped); // while one of the methond helped
        }
        /// <summary>
        /// inserts a value to a cell, updates board and deletes all the other options from the cell
        /// </summary>
        /// <param name="cell">the cell we update</param>
        /// <param name="val">the value we insert the cell</param>
        /// <param name="board">the board that contains the cell</param>
        public static void insertValue(Cell cell, char val, Board board)
        {
            cell.value = val;
            board.rowsValues[cell.row, val - '0']++;
            board.colsValues[cell.col, val - '0']++;
            board.squaresValues[cell.square, val - '0']++;
            foreach (char optionToDelete in cell.options.ToList())
            {
                if (optionToDelete != cell.value)
                {
                    deleteOption(optionToDelete, cell, board);
                }
            }
            board.emptyCells.Remove(cell);
        } 
        /// <summary>
        /// deletes an option from a cell and updayes the board
        /// </summary>
        /// <param name="option">the option we delete</param>
        /// <param name="cell">the crll we delete the option from</param>
        /// <param name="board">the board that contains the cell</param>
        public static void deleteOption(char option, Cell cell, Board board)
        {
            board.rowsOptions[cell.row, option - '0']--;
            board.colsOptions[cell.col, option - '0']--;
            board.squaresOptions[cell.square, option - '0']--;
            cell.options.Remove(option);
        }
        /// <summary>
        /// checks if a cell is the only cell in the row/col/square that contains the option
        /// </summary>
        /// <param name="option">the option we check about</param>
        /// <param name="cell">the cell that contains the option</param>
        /// <param name="board">the board that contains the cell</param>
        /// <returns>0/1 (the cell is the only one/not the only one)</returns>
        public static bool isHiddenSingle(char option, Cell cell, Board board)
        {
            return  board.rowsOptions[cell.row, option - '0'] == 1 ||
                    board.colsOptions[cell.col, option - '0'] == 1 ||
                    board.squaresOptions[cell.square, option - '0'] == 1;
        }

    }
}
