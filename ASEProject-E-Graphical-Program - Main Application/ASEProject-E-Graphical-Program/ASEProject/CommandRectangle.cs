using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    /// <summary>
    /// Represents the Rectangle command class.
    /// </summary>
    public class CommandRectangle : ICommand
    {
        /// <summary>
        /// Calls and executes the command Rectangle from the CommandLibrary.
        /// </summary>
        /// <param name="commandEntryList">The list to which this command belongs to.</param>
        /// <param name="parameters">An array of parameters that provide the input of coordinates.</param>
        public void Execute(CommandLibrary commandEntryList, string[] parameters)
        {
            if (parameters.Length >= 3 && int.TryParse(parameters[1], out int width) && int.TryParse(parameters[2], out int height))
            {
                commandEntryList.DrawRectangle(parameters);
            }
        }
    }
}
