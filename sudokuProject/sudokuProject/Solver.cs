using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Solver
    {
        public static bool nakedSingleSolver(Board sudokuBoard)
        {
            bool foundNumber = false;
            foreach (Cell cell in sudokuBoard.board)
            {
                if (cell.isEmpty())
                {
                    foreach (char option in cell.options.ToList())
                    {
                        if (sudokuBoard.rowsValues[cell.row].Contains(option) || 
                            sudokuBoard.colsValues[cell.col].Contains(option) || 
                            sudokuBoard.squaresValues[cell.square].Contains(option))
                        {
                            cell.options.Remove(option);
                        }
                    }
                    if(cell.options.Count == 1)
                    {
                        cell.value = cell.options[0];
                        sudokuBoard.rowsValues[cell.row].Add(cell.options[0]);
                        sudokuBoard.colsValues[cell.col].Add(cell.options[0]);
                        sudokuBoard.squaresValues[cell.square].Add(cell.options[0]);
                        foundNumber = true;
                    }
                }
            }
            return foundNumber;
        }
    }
}
