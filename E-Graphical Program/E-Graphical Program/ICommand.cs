using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Graphical_Program
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the input command.
        /// </summary>
        /// <param name="CommandEntryList">The command list to which this command belongs to.</param>
        /// <param name="parameters">Array of parameters that provide relevant information for the command entry's execution.</param>
        void Execute(CommandEntryList commandEntryList, string[] parameters);
    }
}
