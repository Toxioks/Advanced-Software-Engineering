using System;
using System.Collections.Generic;
using System.Linq;

namespace ASEProject
{
    /// <summary>
    /// The class responsible for parsing and validating entered commands. 
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// A list of validated commands. Containing all required commands for the program to run.
        /// </summary>
        public List<string> ValidCommandEntry { get; } = new List<string>
        {
            "drawto",
            "moveto",
            "circle",
            "clear",
            "reset",
            "pen",
            "fill",
            "rectangle",
            "triangle",
            "if",
            "endif",
        };

        /// <summary>
        /// Authorises call if the command is found within ValidCommandEntry list.
        /// </summary>
        /// <param name="command">The string that contains the command to validate.</param>
        /// <returns>True if the command is valid/specified command, false if not.</returns>
        public bool IsValidCommandEntry(string command)
        {
            if (VariableIsDeclared(command))
            {
                return true;
            }

            string[] parts = command.Split(' ');

            if (parts.Length == 0)
                throw new InvalidCommandEntryException("Error: No Command Input.");

            string action = parts[0].ToLower();
            if (!ValidCommandEntry.Contains(action))
                throw new InvalidCommandEntryException($"Error Unknown command: {action}");

            return true;
        }

        /// <summary>
        /// Validates if a command has required parameters specified. 
        /// </summary>
        /// <param name="command">The string that contains the command to validate.</param>
        /// <returns> True if specified command has valid parameters, false if not.</returns>
        public bool HasValidParametersEntry(string command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 1)
            {
                string cmd = parts[0].ToLower();
                if (cmd == "clear" || cmd == "reset")
                    return true;
            }
            else if (parts.Length < 2)
            {
                throw new InvalidCommandEntryException("Error: Command is missing parameters.");
            }

            string action = parts[0].ToLower();
            string[] parameters = parts.Skip(1).ToArray();

            switch (action)
            {
                case "drawto":
                    if (!IsValidDrawToParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "moveto":
                    if (!IsValidMoveToParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "circle":
                    if (!IsValidCircleParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "pen":
                    if (!IsValidPenParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "fill":
                    if (!IsValidFillParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "rectangle":
                    if (!IsValidRectangleParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                case "triangle":
                    if (!IsValidTriangleParametersEntry(parameters))
                        throw new InvalidCommandEntryException($"Invalid parameters for {action} command.");
                    break;
                // Invalid Command Exception
                default:
                    throw new InvalidCommandEntryException($"Unknown command: {action}");
            }

            return true;
        }

        /// <summary>
        /// Validates if a the drawTo command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the drawTo command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns></returns>
        private bool IsValidDrawToParametersEntry(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        /// <summary>
        /// Validates if a the moveTo command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the moveto command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidMoveToParametersEntry(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        /// <summary>
        /// Validates if a the circle command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the circle command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidCircleParametersEntry(string[] parameters)
        {
            if (parameters.Length != 1)
                return false;

            return int.TryParse(parameters[0], out _);
        }

        /// <summary>
        /// Validates if a the pen command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the pen command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidPenParametersEntry(string[] parameters)
        {
            if (parameters.Length != 1)
                return false;

            string color = parameters[0].ToLower();
            return color == "red" || color == "white" || color == "blue" || color == "black" || color == "yellow" || color == "Cyan" || color == "Silver" || color == "pink" || color == "gold" || color == "brown";
        }

        /// <summary>
        /// Validates if a the fill command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the fill command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidFillParametersEntry(string[] parameters)
        {
            if (parameters.Length != 1)
                return false;

            string fillModeState = parameters[0].ToLower();
            return fillModeState == "off" || fillModeState == "on";
        }

        /// <summary>
        /// Validates if a the rectangle command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the rectangle command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidRectangleParametersEntry(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        /// <summary>
        /// Validates if a the triangle command has required parameters specified. 
        /// </summary>
        /// <param name="parameters">An Array of parameters for the triangle command.</param>
        /// <returns>True if specified command has valid parameters, false if not.</returns>
        private bool IsValidTriangleParametersEntry(string[] parameters)
        {
            if (parameters.Length != 6)
                return false;

            return parameters.All(param => int.TryParse(param, out _));
        }

        /// <summary>
        /// Checks if the specified command is a correctly formatted variable declaration.
        /// </summary>
        /// <param name="command">The command variables to declare.</param>
        /// <returns>True if the command is a variable declaration, false if not.</returns>
        public bool VariableIsDeclared(string command)
        {
            var parts = command.Split(' ');

            if (parts.Length == 2)
            {
                return false;
            }

            var variableName = parts[0].Trim();
            var variableValue = parts[1].Trim();

            return VariableIsDeclaredTrue(variableName) && int.TryParse(variableValue, out _);
        }

        /// <summary>
        /// Checks if the specified variable is a correctly formatted and vailidates.
        /// </summary>
        /// <param name="command">The variables to declare.</param>
        /// <returns>True if the variable declaration is valid, false if not.</returns>
        private bool VariableIsDeclaredTrue(string variableName)
        {
            return !string.IsNullOrEmpty(variableName) && variableName.All(char.IsLetter);
        }

        /// <summary>
        /// Checks if the specified variable is a correctly and replaces the variable with the value.
        /// </summary>
        /// <param name="command">The string of commands that hold the variables.</param>
        /// <param name="commandEntryList">The list to which this command belongs to.</param>
        /// <returns>A string of commands with replaced variable values.</returns>
        public string VariableNameReplacement(string command, CommandLibrary commandEntryList)
        {
            var parts = command.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (commandEntryList.IsVariableName(parts[i]))
                {
                    parts[i] = commandEntryList.TryGetVariable(parts[i]).ToString();
                }
            }
            return string.Join(" ", parts);
        }

        /// <summary>
        /// Checks if the the specified command is a variable declaraton or mathmatic.
        /// </summary>
        /// <param name="command">The specified command to validate.</param>
        /// <returns>True if the specified command is a variable declaration or mathmatic, false if not.</returns>
        public bool VariableIsDeclaredOrMathmatic(string command)
        {
            var parts = command.Split('=');
            if (parts.Length != 2)
            {
                return false;
            }
            var variableName = parts[0].Trim();
            var variableParam = parts[1].Trim();

            if(int.TryParse(variableParam, out _) || VariableIsDeclaredTrue(variableParam))
            {
                return VariableIsDeclaredTrue(variableName);
            }
            else
            {
                return VariableIsDeclaredTrue(variableName) && VariableIsMathmatic(variableParam);
            }
        }

        /// <summary>
        /// Checks if the the specified command is a mathmatic exoression
        /// </summary>
        /// <param name="expression">The specified command to validate.</param>
        /// <returns>True if the specified string is mathmatic, false if not.</returns>
        private bool VariableIsMathmatic(string expression)
        {
            char[] operators = { '+', '-', '*', '/' };
            var parts = expression.Split(operators);

            foreach (var part in parts)
            {
                string partTrimmed = part.Trim();
                if (!int.TryParse(partTrimmed, out _) && VariableIsDeclaredTrue(partTrimmed))
                {
                    return false;
                }
            }
            return parts.Length > 1;
        }

        /// <summary>
        /// Checks if the the specified command is a conditional if or endif statement.
        /// </summary>
        /// <param name="command">The specified command to validate.</param>
        /// <returns>True if the specified commandis a conditional statement, false if not.</returns>
        public bool ConditionalCommand(string command)
        {
            string[] parts = command.Split(' ');
            return parts.Length > 0 && (parts[0].ToLower() == "if" || parts[0].ToLower() == "endif");
        }

        /// <summary>
        /// Syntax validation of the conditional command value.
        /// </summary>
        /// <param name="command">The string of commands to validate.</param>
        /// <param name="commandEntryList">The commandList of variables to validate.</param>
        /// <returns>True is the command conditions syntax is valid, false if not.</returns>
        public bool ValidConditionalCommand(string command, CommandLibrary commandEntryList)
        {
            string[] parts = command.Split(' ');
            if (parts[0].ToLower() == "if")
            {
                if (parts.Length != 4) return false;

                string variable = parts[1];
                string operation = parts[2];
                string value = parts[3];

                if (!commandEntryList.IsVariableName(variable)) return false;

                if (!(operation == ">" || operation == "<" || operation == "==")) return false;


                return int.TryParse(value, out _);
            }
            else if (parts[0].ToLower() == "endif")
            {
                return parts.Length == 1;
            }
            return false;
        }

        public bool CommandLoop(string command)
        {
            string[] parts = command.Split(' ');
            return parts.Length > 0 && (parts[0].ToLower() == "loop" || parts[0].ToLower() == "endloop");
        }

        /// <summary>
        /// Exception thrown when an entered command is invalid. 
        /// </summary>
        public class InvalidCommandEntryException : Exception
        {
            public InvalidCommandEntryException(string message) : base(message) { }
        }
    }     
        
}
