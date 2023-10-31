using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Graphical_Program
{
    public partial class Form1 : Form
    {
        private CommandEntryList commandEntryList;
        public Form1()
        {
            InitializeComponent();
            commandEntryList = new CommandEntryList(DrawingCanvas.CreateGraphics());
            Graphics graphics = DrawingCanvas.CreateGraphics();
        }

        private void ButtonClickRun_Click(object sender, EventArgs e)
        {
            
        }

        private void CommandInputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonClickClear_Click(object sender, EventArgs e)
        {

        }

        private void buttonClickSyntax_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClickOpen_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClickSave_Click(object sender, EventArgs e)
        {

        }
    }
}
