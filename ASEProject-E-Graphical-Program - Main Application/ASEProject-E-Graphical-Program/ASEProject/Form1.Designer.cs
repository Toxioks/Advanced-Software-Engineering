namespace ASEProject
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
            ButtonOpen = new Button();
            ButtonSave = new Button();
            ButtonRun = new Button();
            buttonSyntax = new Button();
            InputProgramCode = new TextBox();
            GraphicsBox = new PictureBox();
            InputCommandBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)GraphicsBox).BeginInit();
            SuspendLayout();
            // 
            // ButtonOpen
            // 
            ButtonOpen.Location = new Point(978, 868);
            ButtonOpen.Margin = new Padding(6);
            ButtonOpen.Name = "ButtonOpen";
            ButtonOpen.Size = new Size(128, 49);
            ButtonOpen.TabIndex = 0;
            ButtonOpen.Text = "Open";
            ButtonOpen.UseVisualStyleBackColor = true;
            ButtonOpen.Click += ButtonOpen_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(1118, 868);
            ButtonSave.Margin = new Padding(6);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(128, 49);
            ButtonSave.TabIndex = 1;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonRun
            // 
            ButtonRun.Location = new Point(699, 867);
            ButtonRun.Margin = new Padding(6);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(128, 49);
            ButtonRun.TabIndex = 2;
            ButtonRun.Text = "Run";
            ButtonRun.UseVisualStyleBackColor = true;
            ButtonRun.Click += ButtonRun_Click;
            // 
            // buttonSyntax
            // 
            buttonSyntax.Location = new Point(838, 867);
            buttonSyntax.Margin = new Padding(6);
            buttonSyntax.Name = "buttonSyntax";
            buttonSyntax.Size = new Size(128, 49);
            buttonSyntax.TabIndex = 3;
            buttonSyntax.Text = "Syntax";
            buttonSyntax.UseVisualStyleBackColor = true;
            // 
            // InputProgramCode
            // 
            InputProgramCode.AcceptsReturn = true;
            InputProgramCode.Location = new Point(12, 24);
            InputProgramCode.Margin = new Padding(6);
            InputProgramCode.Multiline = true;
            InputProgramCode.Name = "InputProgramCode";
            InputProgramCode.Size = new Size(675, 831);
            InputProgramCode.TabIndex = 4;
            // 
            // GraphicsBox
            // 
            GraphicsBox.BackColor = Color.FromArgb(217, 217, 217);
            GraphicsBox.Location = new Point(698, 24);
            GraphicsBox.Margin = new Padding(6);
            GraphicsBox.Name = "GraphicsBox";
            GraphicsBox.Size = new Size(1035, 831);
            GraphicsBox.TabIndex = 5;
            GraphicsBox.TabStop = false;
            // 
            // InputCommandBox
            // 
            InputCommandBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputCommandBox.Location = new Point(12, 873);
            InputCommandBox.Margin = new Padding(6);
            InputCommandBox.Name = "InputCommandBox";
            InputCommandBox.Size = new Size(675, 39);
            InputCommandBox.TabIndex = 6;
            InputCommandBox.Text = "Enter command here";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 66, 92);
            ClientSize = new Size(1748, 946);
            Controls.Add(InputCommandBox);
            Controls.Add(GraphicsBox);
            Controls.Add(InputProgramCode);
            Controls.Add(buttonSyntax);
            Controls.Add(ButtonRun);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonOpen);
            Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Educational Programming Language";
            ((System.ComponentModel.ISupportInitialize)GraphicsBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonOpen;
        private Button ButtonSave;
        private Button ButtonRun;
        private Button buttonSyntax;
        private TextBox InputProgramCode;
        private PictureBox GraphicsBox;
        private TextBox InputCommandBox;
    }
}