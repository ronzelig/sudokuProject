using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Board
    {
        private Cell[,] board;
        private int dimensionSize;
        //private HashSet<char>[] rowsValues;
        //private HashSet<char>[] colsValues;
        //private HashSet<char>[] squaresValues;

        public Board(string inputString)
        {
            dimensionSize = (int)Math.Sqrt(inputString.Length);
            board = new Cell[dimensionSize, dimensionSize];
            char temp;
            for (int row = 0; row < dimensionSize; row++)
            {
                for (int col = 0; col < dimensionSize; col++)
                {
                    temp = inputString[row * dimensionSize + col];
                    board[row, col] = new Cell(row, col, temp);
                }
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
