using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace ASEProject
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitializeCommandDictionary();
            commandEntryList = new CommandLibrary(GraphicsBox.CreateGraphics());
            commandParser = new CommandParser();
            InputCommandBox.KeyPress += CommandBox_KeyPress;
            ButtonOpen.Click += ButtonOpen_Click;
            ButtonSave.Click += ButtonSave_Click;
        }

        private Dictionary<string, ICommand> commandLibrary;
        private CommandLibrary commandEntryList;
        private CommandParser commandParser;

        public class CustomInvalidCommandException : Exception
        {
            public CustomInvalidCommandException() { }
            public CustomInvalidCommandException(string message) : base(message) { }
            public CustomInvalidCommandException(string message, Exception inner) : base(message, inner) { }
        }

        private void InitializeCommandDictionary()
        {
            commandLibrary = new Dictionary<string, ICommand>
            {
                {"drawto", new CommandDrawTo()},
                {"moveto", new CommandMoveTo()},
                {"circle", new CommandCircle()},
                {"clear", new CommandClear()},
                {"reset", new CommandReset()},
                {"pen", new CommandPenColor()},
                {"fill", new CommandFill()},
            };
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Run button clicked");
            string programCode = InputProgramCode.Text;
            string[] lines = programCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                try
                {
                    ExecuteCommandFromTextBox(line);
                }
                catch (CustomInvalidCommandException ex)
                {
                    MessageBox.Show($"Error: Command Invalid: {ex.Message}", "Invalid Command", MessageBoxButtons.OK);
                }
            }
        }
        private void ExecuteCommandFromTextBox(string commandText)
        {
            string[] commands = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                string shortenedCommand = command.Trim();
                Console.WriteLine($"Error: Command Invalid: {shortenedCommand}");

                if (commandParser.IsValidCommandEntry(shortenedCommand) && commandParser.HasValidParametersEntry(shortenedCommand))
                {
                    string[] parts = shortenedCommand.Split(' ');
                    string commandName = parts[0].ToLower();

                    if (commandLibrary.ContainsKey(commandName))
                    {
                        commandLibrary[commandName].Execute(commandEntryList, parts);
                        Console.WriteLine($"{shortenedCommand} command successful.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Command Invalid: {shortenedCommand}");
                }
            }
        }

        private void CommandBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                try
                {
                    ExecuteCommandFromTextBox(InputCommandBox.Text);
                    InputCommandBox.Clear();
                }
                catch (CustomInvalidCommandException ex)
                {
                    MessageBox.Show($"Error: Command Invalid: {ex.Message}", "Invalid Command", MessageBoxButtons.OK);
                }
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string programName = openFileDialog.FileName;
                        string fileContent = File.ReadAllText(programName);
                        InputProgramCode.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: Opening File: {ex.Message}", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string programName = saveFileDialog.FileName;
                        File.WriteAllText(programName, InputProgramCode.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: Saving File: {ex.Message}", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
