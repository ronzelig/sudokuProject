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

        /// <summary>
        /// initializes the board and the cells
        /// </summary>
        /// <param name="inputString"> the board input by the user we would like to solve </param>
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
        /// <summary>
        /// copy constructor for the board. copies the property from the other board and creates a new one.
        /// </summary>
        /// <param name="other"> the board we copy </param>
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

        /// <summary>
        /// initializse the matrixes properties. seperate from the constructor for comfort.
        /// </summary>
        private void initMatrixes()
        {
            rowsValues = new int[dimensionSize+1,dimensionSize+1];
            colsValues = new int[dimensionSize+1, dimensionSize+1];
            squaresValues = new int[dimensionSize+1, dimensionSize+1];
            rowsOptions = new int[dimensionSize+1, dimensionSize+1];
            colsOptions = new int[dimensionSize+1, dimensionSize+1];
            squaresOptions = new int[dimensionSize+1, dimensionSize+1];           
        }

        /// <summary>
        /// checks if the board is solved(full)
        /// </summary>
        /// <returns> 0/1 (not solved/solved) </returns>
        public bool isSolved()
        {
            return emptyCells.Count == 0;
        }
        /// <summary>
        /// creates a string that represents the board for output.
        /// </summary>
        /// <returns> the string of the board </returns>
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
