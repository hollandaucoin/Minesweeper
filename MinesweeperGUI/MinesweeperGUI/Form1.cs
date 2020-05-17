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
    public partial class Form1 : Form
    {
        // Set variables to lowest options
        public int size = 8;
        public double difficulty = 0.2;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // Create new Form2, hide Form1, show Form2
            Form2 f2 = new MinesweeperGUI.Form2(size, difficulty);
            this.Hide();
            f2.Show();
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            // Set size variable to value of trackbar
            size = trackBarSize.Value;

            // Set label to selected size
            size_label.Text = size.ToString();
        }

        private void trackBarDifficulty_Scroll(object sender, EventArgs e)
        {
            // Set difficulty variable to value of trackbar
            difficulty = ((double)trackBarDifficulty.Value / 20.0);

            // Set difficulty to selected size
            difficulty_label.Text = (((double)trackBarDifficulty.Value / 20.0) * 100).ToString() + "%";
        }
    }
}
