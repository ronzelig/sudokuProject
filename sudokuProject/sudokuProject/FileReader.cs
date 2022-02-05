using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{

    class FileReader : Reader
    {
        const string REQUEST_BOARD = "Please enter file path:";

        public FileReader()
        {

        }
        public override string getBoard()
        {
            Console.WriteLine(REQUEST_BOARD);
            string path = Console.ReadLine();
            string boardInput = File.ReadAllText(path);
            return boardInput;
        }
    }
}
