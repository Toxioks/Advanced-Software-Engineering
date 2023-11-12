using E_Graphical_Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace E_Graphical_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            commandEntryList = new CommandEntryList(DrawingCanvas.CreateGraphics());
            Graphics graphics = DrawingCanvas.CreateGraphics();
            commandParser = new CommandParser();
            CommandInputTextbox.KeyPress += CommandInputTextbox_KeyPress;
            InitializeCommandLibrary();
            ButtonClickOpen.Click += ButtonClickOpen_Click;
            ButtonClickSave.Click += ButtonClickSave_Click;
        }

        private CommandParser commandParser;
        private CommandEntryList commandEntryList;
        private Dictionary<string, ICommand> commandLibrary;


        private void InitializeCommandLibrary()
        {
            commandLibrary = new Dictionary<string, ICommand>
            {
                {"moveto", new CommandMoveTo()},
                {"drawto", new CommandDrawTo()},
                {"circle", new CommandDrawCircle() },
            };
        }


        private void ButtonClickRun_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Event: Run Button Clicked");
            string CommandProgramBox = CommandProgramBox.Text;
            string[] CommandLine = CommandProgramBox.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in CommandLine)
            {
                try
                {
                    ExecuteCommandInputFromTextbox(line);
                }

                catch
                {
                    
                }
            }
        }

        private void CommandInputTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                try
                {
                    ExecuteCommandInputFromTextbox(CommandInputTextbox.Text);
                    CommandInputTextbox.Clear();
                }
                catch
                {

                }
            }
        }

        private void ExecuteCommandInputFromTextbox(string commandText)
        {
            string[] commands = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                string commandTrimmed = command.Trim();
                Console.WriteLine($"Command Input: {commandTrimmed}");
                if (commandParser.IsValidCommand(commandTrimmed) && commandParser.HasValidParameters(commandTrimmed))
                {
                    string[] parts = commandTrimmed.Split(' ');
                    string commandName = parts[0].ToLower();

                    if (commandLibrary.ContainsKey(commandName))
                    {
                        commandLibrary[commandName].Execute(commandEntryList, parts);
                        Console.WriteLine($"{commandTrimmed} command executed.");
                    }
                    else
                    {
                        Console.WriteLine($"Unknown command: {commandTrimmed}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid command: {commandTrimmed}");
                }
            }

        }

        private void ButtonClickOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = openFileDialog.FileName;
                        Console.WriteLine($"Event: Open Button Clicked, File: {filename}");
                        string fileContent = System.IO.File.ReadAllText(filename);
                        CommandInputTextbox.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: File could not be  {ex.Message}", "Error", MessageBoxButtons.OK);
                    }

                }
            }   
        }

        private void ButtonClickSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = saveFileDialog.FileName;
                        Console.WriteLine($"Event: Save Button Clicked, File: {filename}");
                        System.IO.File.WriteAllText(filename, CommandInputTextbox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: File could not be {ex.Message}", "Error", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void CommandInputTextbox_TextUpdated(object sender, EventArgs e)
        {

        }


        private void ButtonClickClear_Click(object sender, EventArgs e)
        {

        }

        private void buttonClickSyntax_Click(object sender, EventArgs e)
        {

        }


    }
}
