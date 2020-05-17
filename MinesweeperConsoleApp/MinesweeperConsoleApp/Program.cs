using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome user
            Console.WriteLine("Welcome to Minesweeper.");
            Console.WriteLine();

            // Create board using user input of size
            Board board = new Board(getBoardSize());

            // Ask user the difficulty level
            board.difficulty = getDifficultyLevel();

            // Set and count live neighbors
            board.setLiveNeighbors();
            board.countLiveNeighbors();

            Console.WriteLine();
            Console.WriteLine("The board has been set.");

            // Print starting board
            printBoardDuringGame(board);
            Console.WriteLine();

            // Play game
            playGame(board);

            Console.ReadLine();

        }

        // Method to play game
        public static void playGame(Board board)
        {
            // Initialize booleans
            bool gameOver = false;
            bool validRow = false;
            bool validColumn = false;

            // Initialize row and column
            int row = 0;
            int column = 0;

            // While loop to create playable game
            while (gameOver == false)
            {
                // Get a valid row
                while (validRow == false)
                {
                    Console.WriteLine("Enter a row number:");

                    // Try to parse the input, if not tell user to try again
                    try
                    {
                        row = Int32.Parse(Console.ReadLine()) - 1;

                        // Check if the input is on the board
                        if (row >= 0 && row < board.size)
                        {
                            validRow = true;
                        }
                        else
                        {
                            validRow = false;
                            Console.WriteLine("Sorry that is an invalid input, please try again.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry that is an invalid input, please try again.");
                    }
                }

                // Get a valid column
                while (validColumn == false)
                {
                    Console.WriteLine("Enter a column number:");

                    // Try to parse the input, if not tell user to try again
                    try
                    {
                        column = Int32.Parse(Console.ReadLine()) - 1;

                        // Check if the input is on the board
                        if (column >= 0 && column < board.size)
                        {
                            validColumn = true;
                        }
                        else
                        {
                            validColumn = false;
                            Console.WriteLine("Sorry that is an invalid input, please try again.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry that is an invalid input, please try again.");
                    }
                }

                // Check to see if user selected a bomb
                if (board.grid[row, column].bomb == true)
                {
                    // Output game is over and set activeBombSelected to true breaking the loop
                    Console.WriteLine();
                    printFinished(board);
                    Console.WriteLine();
                    Console.WriteLine("You hit a bomb, the game is over.");
                    gameOver = true;
                    break;
                }
                // Else, set the position to visited and print board
                else
                {
                    board.floodFill(row, column);
                    printBoardDuringGame(board);
                    Console.WriteLine();

                    Console.WriteLine("The point at row = " + (row + 1) + " and column = " + (column + 1) +
                                    " has " + board.grid[row, column].liveNeighbors + " live neighbors.");
                    Console.WriteLine();
                }

                // If all the non-bomb cells have been visited, tell user they won the game
                if (board.isFinished() == true)
                {
                    printFinished(board);
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, you have won the game!");
                    gameOver = true;
                }
                // Else, reset the validRow and validColumn booleans
                else
                {
                    validRow = false;
                    validColumn = false;
                }
            }
        }

        private static void printFinished(Board board)
        {
            Console.WriteLine();

            // Create row of numbers at top
            Console.Write("      ");
            for (int x = 1; x < board.size + 1; x++)
            {
                if (x < 10)
                {
                    Console.Write(x + "   ");
                }
                else
                {
                    Console.Write(x + "  ");
                }
            }

            Console.WriteLine();

            // Main for loop to grid grid
            for (int i = 0; i < board.size; i++)
            {

                // Make bar at the top
                Console.Write("    +");
                for (int j = 0; j < board.size; j++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();

                // Add numbers down the side
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + "  ");
                }
                else
                {
                    Console.Write(" " + (i + 1) + " ");
                }

                // Create cells
                for (int j = 0; j < board.size; j++)
                {
                    Cell currentCell = board.grid[i, j];

                    Console.Write("| " + currentCell.liveNeighbors + " ");
                }
                // Add bar at the end of each  row
                Console.WriteLine("|");
            }

            // Make bar at the bottom
            Console.Write("    +");
            for (int j = 0; j < board.size; j++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }

        // Method to print the board during the game
        public static void printBoardDuringGame(Board board)
        {
            Console.WriteLine();

            // Create row of numbers at top
            Console.Write("      ");
            for (int x = 1; x < board.size + 1; x++)
            {
                if (x < 10)
                {
                    Console.Write(x + "   ");
                }
                else
                {
                    Console.Write(x + "  ");
                }
            }

            Console.WriteLine();

            // Main for loop to grid grid
            for (int i = 0; i < board.size; i++)
            {

                // Make bar at the top
                Console.Write("    +");
                for (int j = 0; j < board.size; j++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();

                // Add numbers down the side
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + "  ");
                }
                else
                {
                    Console.Write(" " + (i + 1) + " ");
                }

                // Create cells
                for (int j = 0; j < board.size; j++)
                {
                    Cell currentCell = board.grid[i, j];

                    // If the cell hasn't been visited, set to '?'
                    if (currentCell.visited == false)
                    {
                        Console.Write("|   ");
                    }
                    // If the cell has been visited but has no live neighbors set to empty
                    else if (currentCell.visited == true && currentCell.liveNeighbors == 0)
                    {
                        Console.Write("| . ");
                    }
                    // Else, the cell has been visited but has neighbors, set it to the number of visitors
                    else
                    {
                        Console.Write("| " + currentCell.liveNeighbors + " ");
                    }
                }
                // Add bar at the end of each  row
                Console.WriteLine("|");
            }

            // Make bar at the bottom
            Console.Write("    +");
            for (int j = 0; j < board.size; j++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }


        // Method to get the difficulty that the user selects
        public static double getDifficultyLevel()
        {
            // Get the user's input
            Console.WriteLine("Please enter the difficulty you would like: (Easy, Medium, Hard)");
            String difficultyLevel = Console.ReadLine().ToLower();

            // While the user didn't input a correct response, keep asking
            while(!difficultyLevel.Equals("easy") && !difficultyLevel.Equals("medium") && !difficultyLevel.Equals("hard"))
            {
                Console.WriteLine("That is an invalid response, please try again.");
                difficultyLevel = Console.ReadLine().ToLower();
            }

            // If user selected easy, set difficulty to be 20% of cells are bombs
            if (difficultyLevel.Equals("easy"))
            {
                return 0.1;
            }
            // If user selected medium, set difficulty to be 40% of cells are bombs
            else if (difficultyLevel.Equals("medium"))
            {
                return 0.4;
            }
            // Else the user selected hard, set difficulty to be 60% of cells are bombs
            else
            {
                return 0.6;
            }
        }


        // Method to get the size of the board from user
        public static int getBoardSize()
        {
            // Boolean to get valid board size
            bool validSize = false;
            int boardSize = 0;

            // Get a valid column
            while (validSize == false)
            {
                Console.WriteLine("Please enter the size of board you would like to play:");

                // Try to parse the input, if not tell user to try again
                try
                {
                    boardSize = Int32.Parse(Console.ReadLine());

                    // Check if the input is on the board
                    if (boardSize > 6 && boardSize < 26)
                    {
                        validSize = true;
                    }
                    else
                    {
                        validSize = false;
                        Console.WriteLine("Sorry that is an invalid input, please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry that is an invalid input, please try again.");
                }
            }

            // Return the size
            return boardSize;
        }

    }

}
