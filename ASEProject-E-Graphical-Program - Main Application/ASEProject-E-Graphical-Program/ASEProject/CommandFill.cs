﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    /// <summary>
    /// Represents the Fill command class.
    /// </summary>
    public class CommandFill : ICommand
    {
        /// <summary>
        /// Calls and executes the command Fill from the CommandLibrary.
        /// </summary>
        /// <param name="commandEntryList">The list to which this command belongs to.</param>
        /// <param name="parameters">An array of parameters that provide the colour change selected.</param>
        public void Execute(CommandLibrary commandEntryList, string[] parameters)
        {

            if (parameters.Length >= 2)
            {
                commandEntryList.UpdateFillMode(parameters);
            }
        }
    }
}
