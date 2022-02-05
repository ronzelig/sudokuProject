using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Board
    {
        public Cell[,] board { get; }
        public List<Cell> emptyCells { get; }
        public int dimensionSize { get; }
        public int[,] rowsValues { get; set; }
        public int[,] colsValues { get; set; }
        public int[,] squaresValues { get; set; }
        public int[,] rowsOptions { get; set; }
        public int[,] colsOptions { get; set; }
        public int[,] squaresOptions { get; set; }

        public Board(string inputString)
        {
            BoardValidator.validateInput(inputString);
            dimensionSize = (int)Math.Sqrt(inputString.Length);
            board = new Cell[dimensionSize, dimensionSize];
            initMatrixes();
            emptyCells = new List<Cell>();
            for (int row = 0; row < dimensionSize; row++)
            {
                for (int col = 0; col < dimensionSize; col++)
                {
                    char tempChar = inputString[row * dimensionSize + col];
                    board[row, col] = new Cell(row, col, tempChar, dimensionSize, this);
                }
            }
            BoardValidator.validateBoard(this);
        }

        public Board(Board other)
        {
            dimensionSize = other.dimensionSize;
            rowsValues = (int[,])other.rowsValues.Clone();
            colsValues = (int[,])other.colsValues.Clone();
            squaresValues = (int[,])other.squaresValues.Clone();
            rowsOptions = (int[,])other.rowsOptions.Clone();
            colsOptions = (int[,])other.colsOptions.Clone();
            squaresOptions = (int[,])other.squaresOptions.Clone();
            board = new Cell[dimensionSize, dimensionSize];
            emptyCells = new List<Cell>();
            foreach (Cell cell in other.board)
            {
                board[cell.row, cell.col] = new Cell(cell);
                if (cell.isEmpty())
                    emptyCells.Add(board[cell.row, cell.col]);
            }
        }


        private void initMatrixes()
        {
            rowsValues = new int[dimensionSize+1,dimensionSize+1];
            colsValues = new int[dimensionSize+1, dimensionSize+1];
            squaresValues = new int[dimensionSize+1, dimensionSize+1];
            rowsOptions = new int[dimensionSize+1, dimensionSize+1];
            colsOptions = new int[dimensionSize+1, dimensionSize+1];
            squaresOptions = new int[dimensionSize+1, dimensionSize+1];           
        }

        public bool isSolved()
        {
            return emptyCells.Count == 0;
        }

        public override string ToString()
        {
            string result = "";
            string rowLine = (new string('-', dimensionSize*4+1) + "\n");
            for (int row = 0; row < dimensionSize; row++)
            {
                result += (rowLine);
                for (int col = 0; col < dimensionSize; col++)
                {
                      result += ("| "+ (board[row, col].isEmpty()? " ": board[row,col]) +" ");
                }
                result += ("|\n");
            }
            result += (rowLine);
            return result;
        }

    }
}
