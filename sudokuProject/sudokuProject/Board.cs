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
        private HashSet<char>[] rowsValues;
        private HashSet<char>[] colsValues;
        private HashSet<char>[] squaresValues;

        public Board(string inputString)
        {
            dimensionSize = (int)Math.Sqrt(inputString.Length);
            board = new Cell[dimensionSize, dimensionSize];
            initHashSets();
            char temp;
            for (int row = 0; row < dimensionSize; row++)
            {
                for (int col = 0; col < dimensionSize; col++)
                {
                    temp = inputString[row * dimensionSize + col];
                    board[row, col] = new Cell(row, col, temp, dimensionSize);
                    rowsValues[row].Add(temp);
                    colsValues[col].Add(temp);
                    squaresValues[board[row,col].square].Add(temp);
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
