using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.IO;

namespace ASEProject
{

    public partial class Form1 : Form
    {

        /// <summary>
        /// Initializes the form and the command dictionary.
        /// </summary>
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

        public class CustomInvalidCommandEntryException : Exception
        {
            public CustomInvalidCommandEntryException(string message) : base(message) { }
        }

        /// <summary>
        /// Initializes the command dictionary with all the commands set.
        /// </summary>
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
                {"rectangle", new CommandRectangle()},
                {"triangle", new CommandTriangle()},
            };
        }

        private Stack<bool> IsConditionalStack = new Stack<bool>();
        private int IntLoopValue = 0;
        private bool insideLoopStatus = false;
        private List<string> validLoopCommands = new List<string>();

        private bool ExecuteCommand()
        {
            return IsConditionalStack.Count == 0 || IsConditionalStack.Peek();
        }
        /// <summary>
        /// Handles the click event for the run button. Executes the command when the user presses the run button.
        /// </summary>
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
                catch (CustomInvalidCommandEntryException ex)
                {
                    MessageBox.Show($"Error: Command Invalid: {ex.Message}", "Invalid Command", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the run button. Executes the command when the user presses enter.
        /// </summary>
        private void ExecuteCommandFromTextBox(string commandText)
        {
            string[] commands = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commands)
            {
                string shortenedCommand = command.Trim();
                Console.WriteLine($"Error: Command Invalid: {shortenedCommand}");

                if (insideLoopStatus)
                {
                    LoopCommandEvent(shortenedCommand);
                }
                else
                {
                    CommandProcessing(shortenedCommand);
                }
            }
        }

        private void LoopCommandEvent(string command)
        {
            if (command.ToLower() == "endloop")
            {
                SendLoopCommands();
                insideLoopStatus = false;
                validLoopCommands.Clear();
            }
            else
            {
                validLoopCommands.Add(command);
            }
        }

        private void SendLoopCommands()
        {
            for (int i = 0; i < IntLoopValue; i++)
            {
                foreach (var validLoopCommand in validLoopCommands)
                {
                    CommandProcessing(validLoopCommand);
                }
            }
        }

        private void CommandProcessing(string command)
        {
            if (commandParser.CommandLoop(command))
            {
                GuideLoopCommand(command);
            }
            else if (commandParser.ConditionalCommand(command))
            {
                GuideConditionalCommand(command);
            }
            else
            {
                StandardCommandProcessing(command);
            }
        }

        private void GuideLoopCommand(string command)
        {
            string[] parts = command.Split(' ');
            if (parts[0].ToLower() == "loop")
            {
                if (insideLoopStatus)
                {
                    throw new CustomInvalidCommandEntryException("Error: Cannot have nested loops");
                }

                string StringLoopValue = parts[1];
                if (commandEntryList.IsVariableName(StringLoopValue))
                {
                    IntLoopValue = commandEntryList.TryGetVariable(StringLoopValue);
                }
                else if (!int.TryParse(StringLoopValue, out IntLoopValue))
                {
                    throw new CustomInvalidCommandEntryException("Error: Loop value must be an integer");
                }
                insideLoopStatus = true;
                validLoopCommands.Clear();
            }
            else if (parts[0].ToLower() == "endloop")
            {
                if (!insideLoopStatus)
                {
                    throw new CustomInvalidCommandEntryException("Error: Cannot have endloop without loop");
                }
                insideLoopStatus = false;
                validLoopCommands.Clear();
            }
        }

        private void GuideConditionalCommand(string command)
        {
            string[] parts = command.Split(' ');
            if (parts[0].ToLower() == "if")
            {
                bool conditionalCommandResult = ConditionEvaluation(parts[1], parts[2], parts[3]);
                IsConditionalStack.Push(conditionalCommandResult);
            }
            else if (parts[0].ToLower() == "endif")
            {
                if (IsConditionalStack.Count > 0)
                {
                    IsConditionalStack.Pop();
                }
                else
                {
                    throw new CustomInvalidCommandEntryException("Error: Cannot have endif without if");
                }
            }
        }

        private void StandardCommandProcessing(string command)
        {
            if (commandParser.VariableIsDeclaredOrMathmatic(command))
            {
                var parts = command.Split('=');
                string variableName = parts[0].Trim();
                int value = MathmaticEvaluation(parts[1].Trim());
                commandEntryList.variable(variableName, value);
            }
            else
            {
                string[] parts = commandParser.VariableNameReplacement(command, commandEntryList).Split(' ');
                string commandName = parts[0].ToLower();
                if (commandLibrary.ContainsKey(commandName))
                {
                    commandLibrary[commandName].Execute(commandEntryList, parts);
                }
                else
                {
                    throw new CustomInvalidCommandEntryException($"Error: Command {commandName} not found");
                }
            }
        }

        private int MathmaticEvaluation(string expression)
        {
            string[] data = expression.Split(' ');
            int number = 0;

            foreach (string info in data)
            {
                string trimmedInfo = info.Trim();
                if (int.TryParse(trimmedInfo, out int n2))
                {
                    number += n2;
                }
                else if (commandEntryList.IsVariableName(trimmedInfo))
                {
                    number += commandEntryList.TryGetVariable(trimmedInfo);
                }
                else
                {
                    throw new CustomInvalidCommandEntryException($"Error: Variable {trimmedInfo} not found");
                }
            }
            return number;
        }

        private bool ConditionEvaluation(string variableValue, string operation, string value)
        {
            int variable = commandEntryList.TryGetVariable(variableValue);
            int value2 = int.Parse(value);
            switch (operation)
            {
                case "<":
                    return variable > value2;
                case ">":
                    return variable < value2;
                case "==":
                    return variable == value2;
                default:
                    throw new CustomInvalidCommandEntryException($"Error: Operation {operation} not found");
            }
        }

        /// <summary>
        /// Handles the key press event for the command box. Executes the command when the user presses enter.
        /// </summary>
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
                catch (CustomInvalidCommandEntryException ex)
                {
                    MessageBox.Show($"Error: Command Invalid: {ex.Message}", "Invalid Command", MessageBoxButtons.OK);
                }
            }
        }


        /// <summary>
        /// Handles the click event for the open button. Opens a file dialog and loads the program code from a file.
        /// </summary>
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

        /// <summary>
        /// Handled click event for the save button. Opens a save file dialog and saves the program code to a file.
        /// </summary>
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

        /// <summary>
        /// Opens the help link in the default browser of the user.
        /// </summary>
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            Process openLink = new Process();
            
            try
            {
                openLink.StartInfo.UseShellExecute = true;
                openLink.StartInfo.FileName = "https://github.com/Toxioks/Advanced-Software-Engineering";
                openLink.StartInfo.CreateNoWindow = true;
                openLink.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Removes preet text from the command box when the user clicks on it.
        /// </summary>
        private void InputCommandBox_Enter(object sender, EventArgs e)
        {
            InputCommandBox.Clear();
        }

        private void Coordinates_updated(object sender, EventArgs e)
        {
            string Coordinates_updated = Coordinates.Text;
            Coordinates.Text = commandEntryList.GetCurrentPosition().ToString();


        }
        
    }
}
