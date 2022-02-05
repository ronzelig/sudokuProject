using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Cell: IComparable
    {
        public int row { get;}
        public int col { get;}
        public int square { get; }
        public List<char> options { get; }
        public char value { get; set; }

        public Cell(int row, int col, char value, int dimensionSize, Board board)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            square = indexToSquare(row, col, dimensionSize);
            options = new List<char>();
            if (value == '0')
            {               
                for (int i = 1; i <= dimensionSize; i++)
                {
                    options.Add((char)('0' + i));
                    board.rowsOptions[row, i]++;
                    board.colsOptions[col, i]++;
                    board.squaresOptions[square, i]++;
                }
                board.emptyCells.Add(this);
            }
            else
            {
                board.rowsValues[row, value - '0']++;
                board.colsValues[col, value - '0']++;
                board.squaresValues[square, value - '0']++;
            }
        }

        public Cell(Cell other)
        {
            row = other.row;
            col = other.col;
            square = other.square;
            options = other.options.ToList();         
            value = other.value;
        }
        
        public int indexToSquare(int row, int col, int dimensionSize)
        {
            int squareDimention = (int)Math.Sqrt(dimensionSize);
            int SquareFirstRow = row - (row % squareDimention);
            int SquareFirstCol = col - (col % squareDimention);
            int squareNumber = SquareFirstRow + SquareFirstCol / squareDimention;
            return squareNumber;
        }

        public bool isEmpty()
        {
            return this.value == '0';
        }

        public override string ToString()
        {
            return char.ToString(value);
        }

        public int CompareTo(object obj)
        {
            Cell other = (Cell)obj;
            return options.Count - other.options.Count;
        }

    }
}
