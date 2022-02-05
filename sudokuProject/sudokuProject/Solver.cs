using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    static class Solver
    {
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

        public static Board solve(Board sudokuBoard)
        {
            runSimpleMethodsOnBoard(sudokuBoard);
            if (sudokuBoard.isSolved())
            {
                return sudokuBoard;
            }
            sudokuBoard.emptyCells.Sort();
            Cell cell = sudokuBoard.emptyCells[0];
            foreach (char option in cell.options)
            {                
                    Board copyBoard = new Board(sudokuBoard);
                    Cell copyCell = copyBoard.board[cell.row, cell.col];
                    insertValue(copyCell, option, copyBoard);
                    Board result = solve(copyBoard);
                    if (result != null)
                    {
                        return result;
                    }               
            }
            return null;            
        }

        public static void runSimpleMethodsOnBoard(Board board)
        {
            bool nakedSingleHelped, hiddenSingleHelped;
            do
            {
                nakedSingleHelped = nakedSingle(board);
                hiddenSingleHelped = hiddenSingle(board);
            }
            while (nakedSingleHelped || hiddenSingleHelped);
        }

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

        public static void deleteOption(char option, Cell cell, Board board)
        {
            board.rowsOptions[cell.row, option - '0']--;
            board.colsOptions[cell.col, option - '0']--;
            board.squaresOptions[cell.square, option - '0']--;
            cell.options.Remove(option);
        }

        public static bool isHiddenSingle(char option, Cell cell, Board board)
        {
            return  board.rowsOptions[cell.row, option - '0'] == 1 ||
                    board.colsOptions[cell.col, option - '0'] == 1 ||
                    board.squaresOptions[cell.square, option - '0'] == 1;
        }

    }
}
