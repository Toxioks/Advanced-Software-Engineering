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
            label1 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            panel3 = new Panel();
            textBox3 = new TextBox();
            button_Run = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            panel4 = new Panel();
            panel5 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(33, 77);
            button1.Margin = new Padding(4, 2, 4, 2);
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1081, 100);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(130, 19);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(745, 57);
            label1.TabIndex = 1;
            label1.Text = "Educational Programming Language";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 2, 4, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 100);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(121, 100);
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
            button2.Location = new Point(881, 0);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(100, 60);
            button2.TabIndex = 3;
            button2.Text = "Open";
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
            button3.Location = new Point(981, 0);
            button3.Margin = new Padding(4, 2, 4, 2);
            button3.Name = "button3";
            button3.Size = new Size(100, 60);
            button3.TabIndex = 4;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(4, 2, 4, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(0, 39);
            textBox1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 30, 54);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(button_Run);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button3);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 661);
            panel3.Margin = new Padding(4, 2, 4, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1081, 60);
            panel3.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 11);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(662, 39);
            textBox3.TabIndex = 9;
            // 
            // button_Run
            // 
            button_Run.BackColor = Color.FromArgb(24, 30, 54);
            button_Run.Dock = DockStyle.Right;
            button_Run.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
            button_Run.FlatAppearance.BorderSize = 0;
            button_Run.FlatStyle = FlatStyle.Flat;
            button_Run.Font = new Font("Segoe UI", 7.875F, FontStyle.Bold, GraphicsUnit.Point);
            button_Run.ForeColor = Color.FromArgb(158, 161, 178);
            button_Run.Location = new Point(681, 0);
            button_Run.Margin = new Padding(4, 2, 4, 2);
            button_Run.Name = "button_Run";
            button_Run.Size = new Size(100, 60);
            button_Run.TabIndex = 8;
            button_Run.Text = "Run";
            button_Run.TextImageRelation = TextImageRelation.TextAboveImage;
            button_Run.UseVisualStyleBackColor = false;
            button_Run.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(24, 30, 54);
            button4.Dock = DockStyle.Right;
            button4.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 255);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 7.875F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.FromArgb(158, 161, 178);
            button4.Location = new Point(781, 0);
            button4.Margin = new Padding(4, 2, 4, 2);
            button4.Name = "button4";
            button4.Size = new Size(100, 60);
            button4.TabIndex = 7;
            button4.Text = "Syntax";
            button4.TextImageRelation = TextImageRelation.TextAboveImage;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom;
            textBox2.BackColor = SystemColors.InactiveCaption;
            textBox2.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(6, -145);
            textBox2.Margin = new Padding(6, 4, 6, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(661, 43);
            textBox2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(461, 100);
            panel4.Margin = new Padding(4, 2, 4, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(620, 561);
            panel4.TabIndex = 7;
            panel4.Paint += panel4_Paint;
            // 
            // panel5
            // 
            panel5.BackColor = Color.MintCream;
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 100);
            panel5.Margin = new Padding(4, 2, 4, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(461, 561);
            panel5.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1081, 721);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(button1);
            ForeColor = Color.FromArgb(158, 161, 178);
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Panel panel5;
        private Label label1;
        private Button button4;
        private Button button_Run;
        private TextBox textBox3;
    }
}