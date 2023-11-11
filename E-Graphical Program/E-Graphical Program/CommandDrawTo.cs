using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Graphical_Program
{
    public class CommandDrawTo : ICommand
    {
        /// <summary>
        /// Executes the command to move the drawing position to a specific point.
        /// </summary>
        /// <param name="commandEntryList">The command list to which this command belongs.</param>
        /// <param name="parameters">An array of parameters that provide the destination coordinates (X and Y).</param>
        public void Execute(CommandEntryList commandEntryList, string[] parameters)
        {
            if (parameters.Length >= 3 && int.TryParse(parameters[1], out int x) && int.TryParse(parameters[2], out int y))
            {
                commandEntryList.DrawTo(parameters);
            }
        }
    }
}
