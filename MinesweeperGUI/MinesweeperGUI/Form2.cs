using Microsoft.VisualBasic;
using MinesweeperLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
        public static Board board;
        public Button[,] buttonGrid;

        // Create stopwatch object for timer
        private Stopwatch watch = new Stopwatch();

        // Set timerInterval variable
        private int timerInterval = 1000;

        // Create List of PlayerStats for leaderboard
        private List<PlayerStats> leaderboard = new List<PlayerStats>();

        /*
         * Form 2 Constructor
         */
        public Form2(int boardSize, double boardDifficulty)
        {
            InitializeComponent();

            board = new Board(boardSize);

            // Set variables to pass data from form1
            board.size = boardSize;
            board.difficulty = boardDifficulty;

            buttonGrid = new Button[board.size, board.size];

            // Set and count live neighbors
            board.setLiveNeighbors();
            board.countLiveNeighbors();

            // Populate the grid with buttons
            populateGrid();

            // Set timer interval
            timer1.Interval = 1000;
        }


        /*
         *  Method to populate the panel with buttons 
         */
        private void populateGrid()
        {
            int buttonSize = buttonPanel.Width / board.size;
            buttonPanel.Height = buttonPanel.Width;

            // Create grid of buttons
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    buttonGrid[i, j] = new Button();
                    buttonGrid[i, j].Height = buttonSize;
                    buttonGrid[i, j].Width = buttonSize;

                    // Add mousedown event to each button
                    buttonGrid[i, j].MouseDown += buttonPanel_MouseDown;

                    // Add button to the panel
                    buttonPanel.Controls.Add(buttonGrid[i, j]);

                    // Set the location of the button
                    buttonGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    buttonGrid[i, j].Tag = new Point(i, j);
                }
            }

            // Set interval of timer, and start it
            timer1.Interval = timerInterval;
            watch.Start();
        }

        /*
         * Method for the user pressing the mouse (right or left) on the panel 
         */
        private void buttonPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the row and column number of the button clicked
            Button buttonClicked = (Button)sender;
            Point location = (Point)buttonClicked.Tag;

            int x = location.X;
            int y = location.Y;

            // Check if it was left click
            if (e.Button == MouseButtons.Left)
            {
                // Initialize currentCell as button pressed on board
                Cell currentCell = board.grid[x, y];

                // If the user selected a bomb
                if (currentCell.bomb == true)
                {
                    // Game is over, call method to reveal board
                    gameOverShowBoard();

                    // Stop the timer
                    watch.Stop();

                    // Messagebox of game over
                    DialogResult result = MessageBox.Show("You hit a bomb! Game over." + Environment.NewLine + Environment.NewLine +
                        "Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);

                    // If they want to play again
                    if (result == DialogResult.Yes)
                    {
                        // Create new Form1, hide Form2, show Form1
                        Form1 f1 = new MinesweeperGUI.Form1();
                        this.Hide();
                        f1.Show();
                    }
                    // Else, they dont want to play again
                    else
                    {
                        // Close the form
                        this.Close();
                    }
                }
                else
                {
                    // Flood fill surrounding buttons
                    board.floodFill(x, y);

                    // Show all visited buttons
                    showVisited();
                }
            }
            // Else, it was a right click
            else if (e.Button == MouseButtons.Right)
            {
                // Set button to flag image
                buttonGrid[x, y].BackgroundImage = Image.FromFile(@"C:\\Users\holla\source\repos\cst-227\MinesweeperGUI\flag.png");
                buttonGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
            }

            // Check to see if game is over
            if (board.isFinished() == true)
            {
                // Stop watch
                watch.Stop();

                // Set all bomb spaces to flag
                setBombsToFlag();

                // Input message box to get users name for leaderboard
                string name = Interaction.InputBox("Congratulations, you won!" + Environment.NewLine + "Time elapsed: " + timer_label.Text +
                    Environment.NewLine + Environment.NewLine + "Enter your name to see if you made the leaderboard.", "You Won!", "NewPlayer");

                // Write score to file
                readInAndWriteOutToFile(name);
                
                // Create new Form3, hide Form2, show Form3
                Form3 f3 = new MinesweeperGUI.Form3(leaderboard, board.size);
                this.Hide();
                f3.Show();
            }
        }

        /*
         * Method to read in the file, add the user's player stats, and write it back out to the file
         * Also creating leaderboard for Form 3
         */
        private void readInAndWriteOutToFile(String name)
        {
            // Create list of type string to read in text file
            List<string> lines = new List<string>();

            // Create List of PlayerStats for all scores
            List<PlayerStats> scores = new List<PlayerStats>();

            // Create filepath
            string filePath = @"C:\Users\holla\source\repos\cst-227\MinesweeperGUI\leaderboard.txt";

            // Read in all the lines of the text file and put them in lines list
            lines = File.ReadAllLines(filePath).ToList();
            // Set int lineNumber to 0 to assist in errors
            int lineNumber = 0;

            // For each line in the list of lines
            foreach (string line in lines)
            {
                // Increment the lineNumber int for erroring
                lineNumber++;

                // Split the current line by each comma and put into array
                string[] items = line.Split(',');

                // If the array of items is 5 (needed to create PlayerStats)
                if (items.Length == 5)
                {
                    string playerName = items[0];
                    int boardSize = Int32.Parse(items[1]);
                    double diffifculty = Double.Parse(items[2]);
                    int totalSeconds = Int32.Parse(items[3]);
                    int score = Int32.Parse(items[4]);

                    // Create new player using each variable, and add to scores list
                    PlayerStats player = new PlayerStats(playerName, boardSize, diffifculty, totalSeconds, score);
                    scores.Add(player);
                }
                else
                {
                    // Write an error message to a messagebox with the incorrectly formatted line
                    MessageBox.Show("Sorry, line number " + lineNumber + " of the input file is in the incorrect format. " +
                        "Please ensure that each line follows this format: PlayerName,boardSize,difficulty,totalSeconds,score");
                }
            }

            // Get the time elapsed and the current player's score and set to variables
            int time = (int)watch.Elapsed.TotalSeconds;
            int currentPlayerScore = (int)((board.size * board.difficulty) * 500 - time);

            // Create new PlayerStat object using the user's name, board attributes, and defined variables
            PlayerStats currentPlayer = new PlayerStats(name, board.size, board.difficulty, time, currentPlayerScore);
            // Add the current player stats to the list of scores
            scores.Add(currentPlayer);

            // Create list of string for writing to file
            List<string> outContents = new List<string>();

            // Foreach playerstat in the scores list
            foreach (PlayerStats player in scores)
            {
                // Create new string p with the players stats and add to the outContents list
                String p = player.name + "," + player.sizeOfBoard + "," + player.difficulty + "," + player.time + "," + player.score;
                outContents.Add(p);
            }

            // Write the list of strings to the file
            File.WriteAllLines(filePath, outContents);

            // Use a LINQ statement to filter the scores list to get only scores of the same size board
            var highestScores =
                from player in scores
                where player.sizeOfBoard == board.size
                select player;

            // For each PlayerStat in the highestScores variable
            foreach (var player in highestScores)
            {
                // Create a new PlayerStat using the variables and add those high scores to leaderboard list
                PlayerStats highPlayer = new PlayerStats(player.name, player.sizeOfBoard, player.difficulty, player.time, player.score);
                leaderboard.Add(highPlayer);
            }

            // While the leaderboard has less than 5 PlayerStats
            while (leaderboard.Count < 5)
            {
                // Create and add newPlayer "blank" stats
                PlayerStats newPlayer = new PlayerStats("NewPlayer", board.size, 0, 0, 0);
                leaderboard.Add(newPlayer);
            }

            // Sort the leaderboard that uses the CompareTo method in PlayerStats
            leaderboard.Sort();
        }


        /*
         * Method to reveal the entire board, game over
         */
        private void gameOverShowBoard()
        {
            // Iterate through the board
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // If the cell is not a bomb
                    if (board.grid[i, j].bomb == false)
                    {
                        // Reset background image (for flags)
                        buttonGrid[i, j].BackgroundImage = null;

                        // If the cell has live neighbors
                        if (board.grid[i, j].liveNeighbors > 0)
                        {
                            // Set text of cells with 1 live neighbor to blue
                            if (board.grid[i, j].liveNeighbors == 1)
                            {
                                buttonGrid[i, j].ForeColor = Color.Blue;
                            }
                            // Set text of cells with 2 live neighbors to green
                            else if (board.grid[i, j].liveNeighbors == 2)
                            {
                                buttonGrid[i, j].ForeColor = Color.Green;
                            }
                            // Set text of cells with 3 live neighbors to red
                            else if (board.grid[i, j].liveNeighbors == 3)
                            {
                                buttonGrid[i, j].ForeColor = Color.Red;
                            }
                            // Set text of cells with more than 3 live neighbors to black
                            else if (board.grid[i, j].liveNeighbors > 3)
                            {
                                buttonGrid[i, j].ForeColor = Color.Black;
                            }
                            // Show the number of live neighbors and set background color to white
                            buttonGrid[i, j].Text = board.grid[i, j].liveNeighbors.ToString();
                            buttonGrid[i, j].BackColor = Color.White;
                        }
                        // The cell doesn't have live neighbors, just set background to white
                        else
                        {
                            buttonGrid[i, j].BackColor = Color.White;
                        }
                    }
                    // The cell is a bomb, set background image to bomb
                    else
                    {
                        buttonGrid[i, j].BackColor = Color.White;
                        buttonGrid[i, j].BackgroundImage = Image.FromFile(@"C:\\Users\holla\source\repos\cst-227\MinesweeperGUI\bomb.png");
                        buttonGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        /*
         * Method to show the visited buttons
         */
        private void showVisited()
        {
            // Iterate through board to show all visited buttons
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // If the board is visited
                    if (board.grid[i, j].visited == true)
                    {
                        // If the cell has live neighbors, show the live neighbor count
                        if (board.grid[i, j].liveNeighbors > 0)
                        {
                            // Set text of cells with 1 live neighbor to blue
                            if (board.grid[i, j].liveNeighbors == 1)
                            {
                                buttonGrid[i, j].ForeColor = Color.Blue;
                            }
                            // Set text of cells with 2 live neighbors to green
                            else if (board.grid[i, j].liveNeighbors == 2)
                            {
                                buttonGrid[i, j].ForeColor = Color.Green;
                            }
                            // Set text of cells with 3 live neighbors to red
                            else if (board.grid[i, j].liveNeighbors == 3)
                            {
                                buttonGrid[i, j].ForeColor = Color.Red;
                            }
                            // Set text of cells with more than 3 live neighbors to black
                            else if (board.grid[i, j].liveNeighbors > 3)
                            {
                                buttonGrid[i, j].ForeColor = Color.Black;
                            }
                            // Show the number of live neighbors and set background color to white
                            buttonGrid[i, j].Text = board.grid[i, j].liveNeighbors.ToString();
                            buttonGrid[i, j].BackColor = Color.White;
                        }
                        // Reset possible background image, set color to white
                        buttonGrid[i, j].BackgroundImage = null;
                        buttonGrid[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        /*
         * Method to set all the bomb buttons to flags when the user won
         */
        private void setBombsToFlag()
        {
            // Iterate through board to change all bomb images
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // If the board is visited
                    if (board.grid[i, j].bomb == true)
                    {
                        // Set bomb spaces to flag
                        buttonGrid[i, j].BackColor = Color.White;
                        buttonGrid[i, j].BackgroundImage = Image.FromFile(@"C:\\Users\holla\source\repos\cst-227\MinesweeperGUI\flag.png");
                        buttonGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }

        /*
         * Method to restart the game
         */
        private void restart_btn_Click(object sender, EventArgs e)
        {
            // Stop watch
            watch.Stop();

            // Create new Form1, hide Form2, show Form1
            Form1 f1 = new MinesweeperGUI.Form1();
            this.Hide();
            f1.Show();
        }

        /*
         * Method for each tick of timer
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the elapsed time as TimeSpan, format it to minutes and seconds
            TimeSpan ts = watch.Elapsed;
            String time = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            // Set label to time
            timer_label.Text = time;
        }

    }
}
