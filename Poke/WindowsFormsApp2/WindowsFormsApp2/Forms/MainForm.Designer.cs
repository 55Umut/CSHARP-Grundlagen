namespace WindowsFormsApp2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.difficultyComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tik";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 94);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(423, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 94);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(223, 248);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 94);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(323, 248);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 94);
            this.button5.TabIndex = 4;
            this.button5.Text = "Tac";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(423, 248);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 94);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(223, 348);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 94);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(323, 348);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 94);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(423, 348);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 94);
            this.button9.TabIndex = 8;
            this.button9.Text = "Toe";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(602, 248);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(104, 94);
            this.button10.TabIndex = 9;
            this.button10.Text = "Highscore";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(55, 248);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(101, 94);
            this.button11.TabIndex = 10;
            this.button11.Text = "Anmelden";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(323, 50);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(94, 94);
            this.button12.TabIndex = 11;
            this.button12.Text = "Neues Spiel";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // difficultyComboBox
            // 
            this.difficultyComboBox.FormattingEnabled = true;
            this.difficultyComboBox.Location = new System.Drawing.Point(433, 50);
            this.difficultyComboBox.Name = "difficultyComboBox";
            this.difficultyComboBox.Size = new System.Drawing.Size(94, 21);
            this.difficultyComboBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(740, 521);
            this.Controls.Add(this.difficultyComboBox);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox difficultyComboBox;
    }
}