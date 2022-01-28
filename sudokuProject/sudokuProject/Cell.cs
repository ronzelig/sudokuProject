using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{
    class Cell
    {
        public int row { get;}
        public int col { get; }
        public int square { get; }
        public int[] options { get; set; }
        public char value { get; set; }

        public Cell(int row, int col, char value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            //this.square = indexToSquare(row, col);
        }

        private bool isEmpty()
        {
            return this.value == '0';
        }

        public override string ToString()
        {
            return char.ToString(value);
        }
    }
}
