using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Graphical_Program
{
    
    public class InvalidCommandEntryException : Exception
    {
        public InvalidCommandEntryException(string message) : base(message) { }

    }

    public class CommandParser
    {

        public List<string> CommandEntryValid { get; } = new List<string>
        {
            "drawto",
            "moveto",
            "reset",
            "clear",
            "rectangle",
            "triangle",
            "circle",
            "pen",
            "fill",
        };


        public bool IsValidCommand(string command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 0)
                throw new InvalidCommandEntryException("Empty command.");

            string action = parts[0].ToLower();
            if (!CommandEntryValid.Contains(action))
                throw new InvalidCommandEntryException($"Unknown command: {action}");

            return true;
        }

        public bool HasValidParameters(string command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 1)
            {
                string cmd = parts[0].ToLower();
                    return true;
            }
            else if (parts.Length < 2)
            {
                throw new InvalidCommandEntryException("Command input is missing parameters.");
            }

            string action = parts[0].ToLower();
            string[] parameters = parts.Skip(1).ToArray();

            switch (action)
            {
                case "drawto":
                    if (!IsValidDrawToParameters(parameters))
                        throw new InvalidCommandEntryException("Invalid parameters set for ''drawto'' command.");
                    break;
                default:
                    throw new InvalidCommandEntryException($"Unknown command: {action}");
                case "circle":
                    if (!IsValidCircleParameters(parameters))
                        throw new InvalidCommandEntryException("Invalid parameters for 'circle' command.");
                    break;
            }

            return true;
        }

        private bool IsValidDrawToParameters(string[] parameters)
        {
            if (parameters.Length != 2)
                return false;

            return int.TryParse(parameters[0], out _) && int.TryParse(parameters[1], out _);
        }

        private bool IsValidCircleParameters(string[] parameters)
        {
            if (parameters.Length != 1)
                return false;

            return int.TryParse(parameters[0], out _);
        }
    }
}