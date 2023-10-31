﻿namespace E_Graphical_Program
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ButtonClickRun = new System.Windows.Forms.Button();
            this.ButtonClickClear = new System.Windows.Forms.Button();
            this.buttonClickSyntax = new System.Windows.Forms.Button();
            this.CommandInputTextbox = new System.Windows.Forms.TextBox();
            this.ButtonClickSave = new System.Windows.Forms.Button();
            this.ButtonClickOpen = new System.Windows.Forms.Button();
            this.ProgramOutputCanvas = new System.Windows.Forms.Panel();
            this.DrawingCanvas = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ProgramOutputCanvas);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 1080);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CommandInputTextbox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(840, 100);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.125F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Single Command";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ButtonClickOpen);
            this.panel4.Controls.Add(this.ButtonClickSave);
            this.panel4.Controls.Add(this.buttonClickSyntax);
            this.panel4.Controls.Add(this.ButtonClickClear);
            this.panel4.Controls.Add(this.ButtonClickRun);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(840, 50);
            this.panel4.TabIndex = 1;
            // 
            // ButtonClickRun
            // 
            this.ButtonClickRun.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClickRun.Location = new System.Drawing.Point(10, 5);
            this.ButtonClickRun.Name = "ButtonClickRun";
            this.ButtonClickRun.Size = new System.Drawing.Size(100, 40);
            this.ButtonClickRun.TabIndex = 0;
            this.ButtonClickRun.Text = "Run";
            this.ButtonClickRun.UseVisualStyleBackColor = true;
            this.ButtonClickRun.Click += new System.EventHandler(this.ButtonClickRun_Click);
            // 
            // ButtonClickClear
            // 
            this.ButtonClickClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonClickClear.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClickClear.Location = new System.Drawing.Point(120, 5);
            this.ButtonClickClear.Name = "ButtonClickClear";
            this.ButtonClickClear.Size = new System.Drawing.Size(100, 40);
            this.ButtonClickClear.TabIndex = 1;
            this.ButtonClickClear.Text = "Clear";
            this.ButtonClickClear.UseVisualStyleBackColor = true;
            this.ButtonClickClear.Click += new System.EventHandler(this.ButtonClickClear_Click);
            // 
            // buttonClickSyntax
            // 
            this.buttonClickSyntax.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClickSyntax.Location = new System.Drawing.Point(230, 5);
            this.buttonClickSyntax.Name = "buttonClickSyntax";
            this.buttonClickSyntax.Size = new System.Drawing.Size(100, 40);
            this.buttonClickSyntax.TabIndex = 2;
            this.buttonClickSyntax.Text = "Syntax";
            this.buttonClickSyntax.UseVisualStyleBackColor = true;
            this.buttonClickSyntax.Click += new System.EventHandler(this.buttonClickSyntax_Click);
            // 
            // CommandInputTextbox
            // 
            this.CommandInputTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandInputTextbox.Location = new System.Drawing.Point(10, 50);
            this.CommandInputTextbox.Name = "CommandInputTextbox";
            this.CommandInputTextbox.Size = new System.Drawing.Size(820, 39);
            this.CommandInputTextbox.TabIndex = 1;
            this.CommandInputTextbox.TextChanged += new System.EventHandler(this.CommandInputTextbox_TextChanged);
            // 
            // ButtonClickSave
            // 
            this.ButtonClickSave.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClickSave.Location = new System.Drawing.Point(730, 5);
            this.ButtonClickSave.Name = "ButtonClickSave";
            this.ButtonClickSave.Size = new System.Drawing.Size(100, 40);
            this.ButtonClickSave.TabIndex = 3;
            this.ButtonClickSave.Text = "Save";
            this.ButtonClickSave.UseVisualStyleBackColor = true;
            this.ButtonClickSave.Click += new System.EventHandler(this.ButtonClickSave_Click);
            // 
            // ButtonClickOpen
            // 
            this.ButtonClickOpen.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClickOpen.Location = new System.Drawing.Point(620, 5);
            this.ButtonClickOpen.Name = "ButtonClickOpen";
            this.ButtonClickOpen.Size = new System.Drawing.Size(100, 40);
            this.ButtonClickOpen.TabIndex = 4;
            this.ButtonClickOpen.Text = "Open";
            this.ButtonClickOpen.UseVisualStyleBackColor = true;
            this.ButtonClickOpen.Click += new System.EventHandler(this.ButtonClickOpen_Click);
            // 
            // ProgramOutputCanvas
            // 
            this.ProgramOutputCanvas.BackColor = System.Drawing.Color.MintCream;
            this.ProgramOutputCanvas.Location = new System.Drawing.Point(10, 190);
            this.ProgramOutputCanvas.Name = "ProgramOutputCanvas";
            this.ProgramOutputCanvas.Size = new System.Drawing.Size(820, 880);
            this.ProgramOutputCanvas.TabIndex = 2;
            // 
            // DrawingCanvas
            // 
            this.DrawingCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.DrawingCanvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.DrawingCanvas.Location = new System.Drawing.Point(840, 0);
            this.DrawingCanvas.Name = "DrawingCanvas";
            this.DrawingCanvas.Size = new System.Drawing.Size(1080, 1080);
            this.DrawingCanvas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(10, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.DrawingCanvas);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Programming Language";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ButtonClickRun;
        private System.Windows.Forms.Button ButtonClickClear;
        private System.Windows.Forms.Button buttonClickSyntax;
        private System.Windows.Forms.Button ButtonClickOpen;
        private System.Windows.Forms.Button ButtonClickSave;
        private System.Windows.Forms.TextBox CommandInputTextbox;
        private System.Windows.Forms.Panel ProgramOutputCanvas;
        private System.Windows.Forms.Panel DrawingCanvas;
        private System.Windows.Forms.Label label2;
    }
}

