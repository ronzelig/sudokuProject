﻿using System;

namespace sudokuProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board("000000;000000:200000?000000000;00:0@0000?000<0000080010:000000?0000000003100000000000000=0000000000000000" +
                "00000000000000000000<000000000000500000020000000000000;00>00000000000800000000000000000000000?00000000080000000000000000000000=000000400?0000000=000000");
            b.printBoard();
            //Cell c = new Cell(3, 4, '3', 9);
        }
    }
}
