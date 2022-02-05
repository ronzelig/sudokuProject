using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuProject
{

    public class FileReader : Reader
    {
        const string REQUEST_BOARD = "Please enter file path:";
        /// <summary>
        /// file reader constructor
        /// </summary>
        public FileReader()
        {

        }
        /// <summary>
        /// gets a board file from the user
        /// </summary>
        /// <returns>the board as a string from the file</returns>
        public override string getBoard()
        {
            Console.WriteLine(REQUEST_BOARD);
            string path = Console.ReadLine();
            if (!path.EndsWith(".txt"))
                throw new FileLoadException("error: must recive text file");
            try
            {
                string boardInput = File.ReadAllText(path);
                return boardInput;
            }
            catch (FileNotFoundException)
            {
                throw new FileLoadException("error: can't find file");
            }
        }
    }
}
