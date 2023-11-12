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
                    MessageBox.Show($"Invalid Command: {ex.Message}", "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExecuteCommandFromTextBox(string commandText)
        {
            string[] commands = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                string trimmedCommand = command.Trim();
                Console.WriteLine($"Executing command: {trimmedCommand}");

                if (commandParser.IsValidCommandEntry(trimmedCommand) && commandParser.HasValidParametersEntry(trimmedCommand))
                {
                    string[] parts = trimmedCommand.Split(' ');
                    string commandName = parts[0].ToLower();

                    if (commandLibrary.ContainsKey(commandName))
                    {
                        commandLibrary[commandName].Execute(commandEntryList, parts);
                        Console.WriteLine($"{trimmedCommand} command executed.");
                    }
                    else
                    {
                        Console.WriteLine($"Unknown command: {trimmedCommand}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid command: {trimmedCommand}");
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
                    MessageBox.Show($"Invalid Command: {ex.Message}", "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string fileName = openFileDialog.FileName;
                        string fileContent = File.ReadAllText(fileName);
                        InputProgramCode.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string fileName = saveFileDialog.FileName;
                        File.WriteAllText(fileName, InputProgramCode.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
