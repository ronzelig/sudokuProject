using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    public class Cell: IComparable
    {
        public int row { get;}
        public int col { get;}
        public int square { get; }
        public List<char> options { get; }
        public char value { get; set; }
        /// <summary>
        /// initializes a cell
        /// </summary>
        /// <param name="row"> cell row in the matrix </param>
        /// <param name="col"> cell col in the matrix </param>
        /// <param name="value"> the value of the cell </param>
        /// <param name="dimensionSize"> length of the board's rows/cols/squares (4 for 4*4)</param>
        /// <param name="board">the board that contains the cell </param>
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
        /// <summary>
        /// copy constructor for a cell
        /// </summary>
        /// <param name="other">the cell we copy</param>
        public Cell(Cell other)
        {
            row = other.row;
            col = other.col;
            square = other.square;
            options = other.options.ToList();         
            value = other.value;
        }
        /// <summary>
        /// calculates the square of the cell in the board according to its row and col and the board size
        /// </summary>
        /// <param name="row">cell row in the matrix </param>
        /// <param name="col">cell col in the matrix</param>
        /// <param name="dimensionSize">length of the board's rows/cols/squares (4 for 4*4)</param>
        /// <returns>the square number</returns>
        public int indexToSquare(int row, int col, int dimensionSize)
        {
            int squareDimention = (int)Math.Sqrt(dimensionSize);
            int SquareFirstRow = row - (row % squareDimention);
            int SquareFirstCol = col - (col % squareDimention);
            int squareNumber = SquareFirstRow + SquareFirstCol / squareDimention;
            return squareNumber;
        }
        /// <summary>
        /// checks if the cell is empty
        /// </summary>
        /// <returns> 0/1 (not empty/empty) </returns>
        public bool isEmpty()
        {
            return this.value == '0';
        }
        /// <summary>
        /// checks if a value can be in the cell (if the cell's row,col and square don't contain the same value)
        /// </summary>
        /// <param name="val"> the value we check for </param>
        /// <param name="board">the board that contains the cell</param>
        /// <returns> 0/1 (illegal/legal) </returns>
        public bool isLegalValue(char val, Board board)
        {
            return board.rowsValues[row, val - '0'] == 0 &&
                    board.colsValues[col, val - '0'] == 0 &&
                    board.squaresValues[square, val - '0'] == 0;
        }
        /// <summary>
        /// creates a string that represents the cell for output
        /// </summary>
        /// <returns> the value of the cell as a string </returns>
        public override string ToString()
        {
            return char.ToString(value);
        }
        /// <summary>
        /// compares the cell to other cell by the number of options (for sorting empty cells and back-tracking solving)
        /// </summary>
        /// <param name="obj"> the other cell we compare to </param>
        /// <returns> the difference in number of options </returns>
        public int CompareTo(object obj)
        {
            Cell other = (Cell)obj;
            return options.Count - other.options.Count;
        }

    }
}
