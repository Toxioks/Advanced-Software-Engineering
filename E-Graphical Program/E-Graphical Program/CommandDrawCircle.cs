using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Graphical_Program
{
    public class CommandDrawCircle : ICommand
    {
        /// <summary>
        /// Executes the command to draw a circle.
        /// </summary>
        /// <param name="commandList">The command list to which this command belongs.</param>
        /// <param name="parameters">An array of parameters that provide information about the circle (e.g., center coordinates and radius).</param>
        public void Execute(CommandEntryList commandEntryList, string[] parameters)
        {
            
        }
    }
}
