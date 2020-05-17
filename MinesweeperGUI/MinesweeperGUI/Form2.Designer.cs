namespace MinesweeperGUI
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerlabel_label = new System.Windows.Forms.Label();
            this.timer_label = new System.Windows.Forms.Label();
            this.restart_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPanel.Location = new System.Drawing.Point(15, 54);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(650, 650);
            this.buttonPanel.TabIndex = 0;
            this.buttonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPanel_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerlabel_label
            // 
            this.timerlabel_label.AutoSize = true;
            this.timerlabel_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerlabel_label.Location = new System.Drawing.Point(172, 18);
            this.timerlabel_label.Name = "timerlabel_label";
            this.timerlabel_label.Size = new System.Drawing.Size(63, 24);
            this.timerlabel_label.TabIndex = 2;
            this.timerlabel_label.Text = "Time:";
            // 
            // timer_label
            // 
            this.timer_label.AutoSize = true;
            this.timer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer_label.Location = new System.Drawing.Point(235, 18);
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(55, 24);
            this.timer_label.TabIndex = 3;
            this.timer_label.Text = "00:00";
            // 
            // restart_btn
            // 
            this.restart_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart_btn.Location = new System.Drawing.Point(405, 11);
            this.restart_btn.Name = "restart_btn";
            this.restart_btn.Size = new System.Drawing.Size(100, 35);
            this.restart_btn.TabIndex = 4;
            this.restart_btn.Text = "Restart";
            this.restart_btn.UseVisualStyleBackColor = true;
            this.restart_btn.Click += new System.EventHandler(this.restart_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 716);
            this.Controls.Add(this.restart_btn);
            this.Controls.Add(this.timer_label);
            this.Controls.Add(this.timerlabel_label);
            this.Controls.Add(this.buttonPanel);
            this.Name = "Form2";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timerlabel_label;
        private System.Windows.Forms.Label timer_label;
        private System.Windows.Forms.Button restart_btn;
    }
}