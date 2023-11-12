using System;
using System.Collections.Generic;
using System.Linq;

namespace ASEProject
{
    /// <summary>
    /// Exception thrown when an entered command is invalid. 
    /// </summary>
    public class InvalidCommandEntryException : Exception
    {
        public InvalidCommandEntryException(string message) : base(message) { }
    }

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
        };

        /// <summary>
        /// Authorises call if the command is found within ValidCommandEntry list.
        /// </summary>
        /// <param name="command">The string that contains the command to validate.</param>
        public bool IsValidCommandEntry(string command)
        {
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
                throw new InvalidCommandEntryException("Command is missing parameters.");
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
                        throw new InvalidCommandEntryException("Invalid parameters for 'circle' command.");
                    break;
                    // Invalid Command
                default:
                    throw new InvalidCommandEntryException($"Unknown command: {action}");
            }

            return true;
        }

        /// <summary>
        /// Validates if a the drawTo command has required parameters specified. 
        /// </summary>
        private bool IsValidDrawToParametersEntry(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        /// <summary>
        /// Validates if a the moveTo command has required parameters specified. 
        /// </summary>
        private bool IsValidMoveToParametersEntry(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        /// <summary>
        /// Validates if a the circle command has required parameters specified. 
        /// </summary>
        private bool IsValidCircleParametersEntry(string[] parameters)
        {
            if (parameters.Length != 1)
                return false;

            return int.TryParse(parameters[0], out _);
        }
    }
}
