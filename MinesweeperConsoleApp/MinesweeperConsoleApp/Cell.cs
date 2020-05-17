using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperConsoleApp
{
    public class Cell
    {
        // Declare variables
        public int row { get; set; }
        public int column { get; set; }
        public bool visited { get; set; }
        public bool bomb { get; set; }
        public int liveNeighbors { get; set; }


        // Default Constructor
        public Cell()
        {
            column = -1;
            row = -1;
            visited = false;
            bomb = false;
            liveNeighbors = 0;
        }

        // Constructor with parameters
        public Cell(int x, int y)
        {
            column = x;
            row = y;
            visited = false;
            bomb = false;
            liveNeighbors = 0;
        }
    }
}
