using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperConsoleApp
{
    public class Board
    {
        // Declare variables
        public int size { get; set; }
        public Cell[,] grid { get; set; }
        public double difficulty { get; set; }

        // Constructor
        public Board(int size)
        {
            this.size = size;

            // Create 2D array of cells
            grid = new Cell[size, size];

            // Fill the 2D array with new cells
            for (int column = 0; column < size; column++)
            {
                for (int row = 0; row < size; row++)
                {
                    grid[column, row] = new Cell(column, row);
                }
            }
        }

        // Method to set up the live neighbors
        public void setLiveNeighbors()
        {
            var rand = new Random();
            int num1 = rand.Next(0, size - 1);
            int num2 = rand.Next(0, size - 1);

            int numberOfBombs = Convert.ToInt32((size * size) * difficulty);

            for (int i = 0; i < numberOfBombs; i++)
            {
                while (grid[num1, num2].bomb == true)
                {
                    num1 = rand.Next(0, size - 1);
                    num2 = rand.Next(0, size - 1);
                }

                grid[num1, num2].bomb = true;
            }
        }

        // Method to calculate the live neighbors for each cell
        public void countLiveNeighbors()
        {
            for (int i = 0; i <  size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if(grid[i, j].bomb == true)
                    {
                        grid[i, j].liveNeighbors = 9;
                    }
                    else
                    {
                        int count = 0;

                        if (isSafe(i + 1, j))
                        {
                            if (grid[i + 1, j].bomb == true)
                            {
                                count++;
                            }
                        }
                        if(isSafe(i + 1, j + 1))
                        {
                            if (grid[i + 1, j + 1].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i, j + 1))
                        {
                            if (grid[i, j + 1].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i - 1, j + 1))
                        {
                            if (grid[i - 1, j + 1].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i - 1, j))
                        {
                            if (grid[i - 1, j].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i - 1, j - 1))
                        {
                            if (grid[i - 1, j - 1].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i, j - 1))
                        {
                            if (grid[i, j - 1].bomb == true)
                            {
                                count++;
                            }
                        }
                        if (isSafe(i + 1, j - 1))
                        {
                            if (grid[i + 1, j - 1].bomb == true)
                            {
                                count++;
                            }
                        }

                        grid[i, j].liveNeighbors = count;
                    }
                }
            } 
        }

        // Method to check if a specific x, y coordinate exists in this grid
        public bool isSafe(int num1, int num2)
        {
            if(num1 >= 0 && num1 < size && num2 >= 0 && num2 < size) {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to check if the user won the game
        public bool isFinished()
        {
            bool allCellsVisited = true;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i, j].visited == false && grid[i, j].bomb == false)
                    {
                        allCellsVisited = false;
                        break;
                    }
                }
            }

            return allCellsVisited;
        }

        // Method to flood fill the board
        public void floodFill(int row, int column)
        {
            if (isSafe(row, column) && grid[row, column].bomb == false && grid[row, column].visited == false)
            {
                grid[row, column].visited = true;

                if(grid[row, column].liveNeighbors > 0)
                {
                    return;
                }

                floodFill(row + 1, column);

                floodFill(row, column + 1);

                floodFill(row, column - 1);

                floodFill(row - 1, column);
            }
            else
            {
                return;
            }
        }
    }
}
