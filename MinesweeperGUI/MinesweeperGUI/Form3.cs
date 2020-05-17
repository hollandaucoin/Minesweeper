using MinesweeperLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form3 : Form
    {
        public Form3(List<PlayerStats> leaderboard, int size)
        {
            InitializeComponent();
            populateLeaderboard(leaderboard);

            boardSize_label.Text = "Board Size: " + size;
        }

        private void populateLeaderboard(List<PlayerStats> leaderboard)
        {
            // Set number 1 on leaderboard
            name_label1.Text = leaderboard.ElementAt(0).name;
            difficulty_label1.Text = ((leaderboard.ElementAt(0).difficulty) * 100).ToString() + "%";
            score_label1.Text = leaderboard.ElementAt(0).score.ToString();

            // Set number 2 on leaderboard
            name_label2.Text = leaderboard.ElementAt(1).name;
            difficulty_label2.Text = ((leaderboard.ElementAt(1).difficulty) * 100).ToString() + "%";
            score_label2.Text = leaderboard.ElementAt(1).score.ToString();

            // Set number 3 on leaderboard
            name_label3.Text = leaderboard.ElementAt(2).name;
            difficulty_label3.Text = ((leaderboard.ElementAt(2).difficulty) * 100).ToString() + "%";
            score_label3.Text = leaderboard.ElementAt(2).score.ToString();

            // Set number 4 on leaderboard
            name_label4.Text = leaderboard.ElementAt(3).name;
            difficulty_label4.Text = ((leaderboard.ElementAt(3).difficulty) * 100).ToString() + "%";
            score_label4.Text = leaderboard.ElementAt(3).score.ToString();

            // Set number 5 on leaderboard
            name_label5.Text = leaderboard.ElementAt(4).name;
            difficulty_label5.Text = ((leaderboard.ElementAt(4).difficulty) * 100).ToString() + "%";
            score_label5.Text = leaderboard.ElementAt(4).score.ToString();
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            // Create new Form1, hide Form3, show Form1
            Form1 f1 = new MinesweeperGUI.Form1();
            this.Hide();
            f1.Show();
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
