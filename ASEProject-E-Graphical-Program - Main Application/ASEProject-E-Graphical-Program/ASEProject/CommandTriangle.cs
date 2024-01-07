using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    /// <summary>
    /// Represents the Triangle command class.
    /// </summary>
    public class CommandTriangle : ICommand
    {
        /// <summary>
        /// Calls and executes the command circle from the CommandLibrary.
        /// </summary>
        /// <param name="commandEntryList">The list to which this command belongs to.</param>
        /// <param name="parameters">An array of parameters that provide the input of coordinates.</param>
        public void Execute(CommandLibrary commandEntryList, string[] parameters)
        {
            if (parameters.Length >= 6 && int.TryParse(parameters[1], out int radius)
                && int.TryParse(parameters[2], out int height)
                && int.TryParse(parameters[3], out int x2)
                && int.TryParse(parameters[4], out int y2))

            {
                commandEntryList.DrawTriangle(parameters);
            }
        }
    }
}
