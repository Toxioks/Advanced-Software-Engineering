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

        /// <summary>
        /// A dictionary that contains all the commands.
        /// </summary>
        private Dictionary<string, ICommand> commandLibrary;

        /// <summary>
        /// A list that contains all the commands.
        /// </summary>
        private CommandLibrary commandEntryList;

        /// <summary>
        /// A parser that contains all the commands.
        /// </summary>
        private CommandParser commandParser;

        /// <summary>
        /// A stack that contains all the conditional statements, used to check if the conditional statement is true or false.
        /// </summary>
        private Stack<bool> IsConditionalStack = new Stack<bool>();

        /// <summary>
        /// A variable that contains the value of the loop and it's iterations.
        /// </summary>
        private int IntLoopValue = 0;

        /// <summary>
        /// Specifies if the current command is inside or outside of the loop.
        /// </summary>
        private bool insideLoopStatus = false;

        /// <summary>
        /// A list that stores all the valid commands to be executed.
        /// </summary>
        private List<string> validLoopCommands = new List<string>();

        /// <summary>
        /// A class that handles the custom invalid command entry exception.
        /// </summary>
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
        /// Handles the click event for the run button and executes the specified command from the command box.
        /// </summary>
        /// <param name="commandText">The command to be executed.</param>
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

        /// <summary>
        /// Handles the loop command event. Checks if the command is a loop command or not and executing.
        /// </summary>
        /// <param name="command">The specified command line used to process within the loop</param>
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

        /// <summary>
        /// Sends the all specified commands to be executed within the loop.
        /// </summary>
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

        /// <summary>
        /// Handles the command processing event. Checks if the command and it's conditions.
        /// </summary>
        /// <param name="command">The specified command line to be processed</param>
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

        /// <summary>
        /// Executes and process's the specified loop command.
        /// </summary>
        /// <param name="command">The specified command to be processed within the loop</param>
        /// <exception cref="CustomInvalidCommandEntryException">Throw's an exception when a condition or syntax is invalid.</exception>
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

        /// <summary>
        /// Executes and process's the specified conditional command.
        /// </summary>
        /// <param name="command">The specified conditional command to process</param>
        /// <exception cref="CustomInvalidCommandEntryException">Throw's an exception when a condition or syntax is invalid.</exception>
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

        /// <summary>
        /// Executes and process's the specified standard command.
        /// </summary>
        /// <param name="command">The specified command to process</param>
        /// <exception cref="CustomInvalidCommandEntryException">Throw's a excepton when a condition or syntax is invalid</exception>
        private void StandardCommandProcessing(string command)
        {
            if (commandParser.VariableIsDeclaredOrMathmatic(command))
            {
                var parts = command.Split('=');
                string variableName = parts[0].Trim();
                int value = MathmaticEvaluation(parts[1].Trim());
                commandEntryList.Variable(variableName, value);
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

        /// <summary>
        /// Evaluates the mathmatic expression and returns the value.
        /// </summary>
        /// <param name="expression">The expression value to evaluate</param>
        /// <returns>The value of the mathmatic expression.</returns>
        /// <exception cref="CustomInvalidCommandEntryException">Throw's a exceptionn when an invalid term or condition is encountered.</exception>
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

        /// <summary>
        /// Evaluates the specified condition and returns the value.
        /// </summary>
        /// <param name="variableValue">The specified variable to evaluate</param>
        /// <param name="operation">The specified operation to evaluate</param>
        /// <param name="value">The specified value to evaluate</param>
        /// <returns>True if the case condition is met, false if not.</returns>
        /// <exception cref="CustomInvalidCommandEntryException">Throw's a invalid exception when a invalid operation is provided.</exception>
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
                case "!=":
                    return variable != value2;
                case "<=":
                    return variable >= value2;  
                case ">=":
                    return variable <= value2;
                default:
                    throw new CustomInvalidCommandEntryException($"Error: Operation {operation} not found.");
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

        /// <summary>
        /// Updated the specified pen coordinates when the user clicks on the graphics box.
        /// </summary>
        /// <param name="sender">Argument sender</param>
        /// <param name="e">Where event data is stored</param>
        /// <returns>The pen object's current position.</returns>
        private void Coordinates_updated(object sender, EventArgs e)
        {
            string Coordinates_updated = Coordinates.Text;
            Coordinates.Text = commandEntryList.GetCurrentPosition().ToString();


        }
        
    }
}
