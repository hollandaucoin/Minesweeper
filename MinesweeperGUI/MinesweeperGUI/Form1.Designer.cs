namespace MinesweeperGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.welcome_label = new System.Windows.Forms.Label();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.selectSize_label = new System.Windows.Forms.Label();
            this.selectDifficulty_label = new System.Windows.Forms.Label();
            this.trackBarDifficulty = new System.Windows.Forms.TrackBar();
            this.boardSize_label = new System.Windows.Forms.Label();
            this.size_label = new System.Windows.Forms.Label();
            this.gameDifficulty_label = new System.Windows.Forms.Label();
            this.difficulty_label = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.Location = new System.Drawing.Point(114, 34);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(424, 38);
            this.welcome_label.TabIndex = 0;
            this.welcome_label.Text = "Welcome to Minesweeper!";
            // 
            // trackBarSize
            // 
            this.trackBarSize.LargeChange = 1;
            this.trackBarSize.Location = new System.Drawing.Point(27, 147);
            this.trackBarSize.Maximum = 25;
            this.trackBarSize.Minimum = 8;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(591, 56);
            this.trackBarSize.TabIndex = 1;
            this.trackBarSize.Value = 8;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // selectSize_label
            // 
            this.selectSize_label.AutoSize = true;
            this.selectSize_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSize_label.Location = new System.Drawing.Point(241, 107);
            this.selectSize_label.Name = "selectSize_label";
            this.selectSize_label.Size = new System.Drawing.Size(174, 24);
            this.selectSize_label.TabIndex = 2;
            this.selectSize_label.Text = "Select a board size:";
            // 
            // selectDifficulty_label
            // 
            this.selectDifficulty_label.AutoSize = true;
            this.selectDifficulty_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDifficulty_label.Location = new System.Drawing.Point(192, 260);
            this.selectDifficulty_label.Name = "selectDifficulty_label";
            this.selectDifficulty_label.Size = new System.Drawing.Size(273, 24);
            this.selectDifficulty_label.TabIndex = 4;
            this.selectDifficulty_label.Text = "Select a percentage of difficulty:";
            // 
            // trackBarDifficulty
            // 
            this.trackBarDifficulty.LargeChange = 1;
            this.trackBarDifficulty.Location = new System.Drawing.Point(27, 300);
            this.trackBarDifficulty.Maximum = 14;
            this.trackBarDifficulty.Minimum = 4;
            this.trackBarDifficulty.Name = "trackBarDifficulty";
            this.trackBarDifficulty.Size = new System.Drawing.Size(591, 56);
            this.trackBarDifficulty.TabIndex = 3;
            this.trackBarDifficulty.Value = 4;
            this.trackBarDifficulty.Scroll += new System.EventHandler(this.trackBarDifficulty_Scroll);
            // 
            // boardSize_label
            // 
            this.boardSize_label.AutoSize = true;
            this.boardSize_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSize_label.Location = new System.Drawing.Point(151, 406);
            this.boardSize_label.Name = "boardSize_label";
            this.boardSize_label.Size = new System.Drawing.Size(117, 24);
            this.boardSize_label.TabIndex = 5;
            this.boardSize_label.Text = "Board Size:";
            // 
            // size_label
            // 
            this.size_label.AutoSize = true;
            this.size_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_label.Location = new System.Drawing.Point(274, 406);
            this.size_label.Name = "size_label";
            this.size_label.Size = new System.Drawing.Size(20, 24);
            this.size_label.TabIndex = 6;
            this.size_label.Text = "8";
            // 
            // gameDifficulty_label
            // 
            this.gameDifficulty_label.AutoSize = true;
            this.gameDifficulty_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDifficulty_label.Location = new System.Drawing.Point(350, 406);
            this.gameDifficulty_label.Name = "gameDifficulty_label";
            this.gameDifficulty_label.Size = new System.Drawing.Size(93, 24);
            this.gameDifficulty_label.TabIndex = 7;
            this.gameDifficulty_label.Text = "Difficulty:";
            // 
            // difficulty_label
            // 
            this.difficulty_label.AutoSize = true;
            this.difficulty_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty_label.Location = new System.Drawing.Point(449, 406);
            this.difficulty_label.Name = "difficulty_label";
            this.difficulty_label.Size = new System.Drawing.Size(45, 24);
            this.difficulty_label.TabIndex = 8;
            this.difficulty_label.Text = "20%";
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.Location = new System.Drawing.Point(258, 452);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(122, 37);
            this.start_button.TabIndex = 9;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 524);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.difficulty_label);
            this.Controls.Add(this.gameDifficulty_label);
            this.Controls.Add(this.size_label);
            this.Controls.Add(this.boardSize_label);
            this.Controls.Add(this.selectDifficulty_label);
            this.Controls.Add(this.trackBarDifficulty);
            this.Controls.Add(this.selectSize_label);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.welcome_label);
            this.Name = "Form1";
            this.Text = "Minesweeper Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDifficulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Label selectSize_label;
        private System.Windows.Forms.Label selectDifficulty_label;
        private System.Windows.Forms.TrackBar trackBarDifficulty;
        private System.Windows.Forms.Label boardSize_label;
        private System.Windows.Forms.Label size_label;
        private System.Windows.Forms.Label gameDifficulty_label;
        private System.Windows.Forms.Label difficulty_label;
        private System.Windows.Forms.Button start_button;
    }
}

