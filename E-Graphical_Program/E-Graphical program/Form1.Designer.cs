namespace E_Graphical_program
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(34, 77);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 0;
            button1.Text = "DRAW";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 100);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(120, 100);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(24, 30, 54);
            button2.Dock = DockStyle.Right;
            button2.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 7.875F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(158, 161, 178);
            button2.Location = new Point(880, 0);
            button2.Name = "button2";
            button2.Size = new Size(100, 60);
            button2.TabIndex = 3;
            button2.Text = "Run";
            button2.TextImageRelation = TextImageRelation.TextAboveImage;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(24, 30, 54);
            button3.Dock = DockStyle.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 7.875F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.FromArgb(158, 161, 178);
            button3.Location = new Point(980, 0);
            button3.Name = "button3";
            button3.Size = new Size(100, 60);
            button3.TabIndex = 4;
            button3.Text = "Syntax";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(0, 39);
            textBox1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 30, 54);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button3);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 660);
            panel3.Name = "panel3";
            panel3.Size = new Size(1080, 60);
            panel3.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom;
            textBox2.BackColor = SystemColors.InactiveCaption;
            textBox2.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(10, 10);
            textBox2.Margin = new Padding(5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(860, 43);
            textBox2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Location = new Point(34, 131);
            panel4.Name = "panel4";
            panel4.Size = new Size(1014, 501);
            panel4.TabIndex = 7;
            panel4.Paint += panel4_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1080, 720);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(button1);
            ForeColor = Color.FromArgb(158, 161, 178);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Panel panel3;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox textBox2;
        private Panel panel4;
    }
}