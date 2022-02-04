﻿using System;
using System.Collections.Generic;
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
            foreach (Cell cell in sudokuBoard.board)
            {
                if (cell.isEmpty())
                {
                    foreach (char option in cell.options.ToList())
                    {
                        if (sudokuBoard.rowsValues[cell.row, option-'0']!=0 || 
                            sudokuBoard.colsValues[cell.col,option-'0']!=0 || 
                            sudokuBoard.squaresValues[cell.square,option-'0']!=0)
                        {
                            cell.options.Remove(option);
                            eliminatedOptions = true;
                            sudokuBoard.rowsOptions[cell.row, option - '0']--;
                            sudokuBoard.colsOptions[cell.col, option - '0']--;
                            sudokuBoard.squaresOptions[cell.square, option - '0']--;
                        }
                    }
                    if (cell.options.Count == 1)
                    {
                        cell.value = cell.options[0];
                        sudokuBoard.rowsValues[cell.row, cell.value - '0']++;
                        sudokuBoard.colsValues[cell.col, cell.value - '0']++;
                        sudokuBoard.squaresValues[cell.square, cell.value - '0']++;
                        sudokuBoard.rowsValues[cell.row, 0]--;
                        sudokuBoard.colsValues[cell.col, 0]--;
                        sudokuBoard.squaresValues[cell.square, 0]--;
                    }
                }
            }
            return eliminatedOptions;
        }

        public static bool hiddenSingle(Board sudokuBoard)
        {
            bool foundHidden = false;
            foreach(Cell cell in sudokuBoard.board)
            {
                if (cell.isEmpty())
                {
                    foreach(char option in cell.options.ToList())
                    {
                        if (sudokuBoard.rowsOptions[cell.row,option-'0'] == 1 ||
                            sudokuBoard.colsOptions[cell.col,option-'0'] == 1 ||
                            sudokuBoard.squaresOptions[cell.square,option-'0'] == 1)
                        {
                            cell.value = option;
                            sudokuBoard.rowsValues[cell.row, option - '0']++;
                            sudokuBoard.colsValues[cell.col, option - '0']++;
                            sudokuBoard.squaresValues[cell.square, option - '0']++;
                            sudokuBoard.rowsValues[cell.row, 0]--;
                            sudokuBoard.colsValues[cell.col, 0]--;
                            sudokuBoard.squaresValues[cell.square, 0]--;
                            foundHidden = true;
                            foreach (char optionToDelete in cell.options.ToList())
                            {
                                if (optionToDelete != cell.value)
                                {
                                    sudokuBoard.rowsOptions[cell.row, optionToDelete - '0']--;
                                    sudokuBoard.colsOptions[cell.col, optionToDelete - '0']--;
                                    sudokuBoard.squaresOptions[cell.square, optionToDelete - '0']--;
                                    cell.options.Remove(optionToDelete);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return foundHidden;
        }
        public static bool backTracking(Board sudokuBoard)
        {
            Cell cell = findEmptyCell(sudokuBoard);
            if (cell == null) 
                return true;
            foreach(char option in cell.options)
            {
                if (sudokuBoard.rowsValues[cell.row, option - '0'] == 0 &&
                    sudokuBoard.colsValues[cell.col, option - '0'] == 0 &&
                    sudokuBoard.squaresValues[cell.square, option - '0'] == 0)
                {
                    cell.value = option;
                    sudokuBoard.rowsValues[cell.row, option - '0']++;
                    sudokuBoard.colsValues[cell.col, option - '0']++;
                    sudokuBoard.squaresValues[cell.square, option - '0']++;
                    if (Solver.backTracking(sudokuBoard))
                        return true;
                    else
                    {
                        sudokuBoard.rowsValues[cell.row, option - '0']--;
                        sudokuBoard.colsValues[cell.col, option - '0']--;
                        sudokuBoard.squaresValues[cell.square, option - '0']--;
                    }
                }
            }            
            cell.value = '0';
            return false;            
        }

        private static Cell findEmptyCell(Board sudokuBoard)
        {
            foreach(Cell cell in sudokuBoard.board)
            {
                if (cell.isEmpty())
                    return cell;
            }
            return null;
        }
    }
}
