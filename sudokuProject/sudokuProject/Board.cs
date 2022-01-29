using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Board
    {
        public Cell[,] board { get; }
        public int dimensionSize { get; }
        public HashSet<char>[] rowsValues { get; set; }
        public HashSet<char>[] colsValues { get; set; }
        public HashSet<char>[] squaresValues { get; set; }

        public Board(string inputString)
        {
            dimensionSize = (int)Math.Sqrt(inputString.Length);
            board = new Cell[dimensionSize, dimensionSize];
            initHashSets();
            for (int row = 0; row < dimensionSize; row++)
            {
                for (int col = 0; col < dimensionSize; col++)
                {
                    char tempChar = inputString[row * dimensionSize + col];
                    board[row, col] = new Cell(row, col, tempChar, dimensionSize);
                    rowsValues[row].Add(tempChar);
                    colsValues[col].Add(tempChar);
                    squaresValues[board[row,col].square].Add(tempChar);
                }
            }
        }

        private void initHashSets()
        {
            rowsValues = new HashSet<char>[dimensionSize];
            colsValues = new HashSet<char>[dimensionSize];
            squaresValues = new HashSet<char>[dimensionSize];
            for(int i = 0; i<dimensionSize; i++)
            {
                rowsValues[i] = new HashSet<char>();
                colsValues[i] = new HashSet<char>();
                squaresValues[i] = new HashSet<char>();
            }
        }

        public void printBoard()
        {
            for (int row = 0; row < dimensionSize; row++)
            {
                for (int col = 0; col < dimensionSize; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine("");
            }
        }
    }
}
