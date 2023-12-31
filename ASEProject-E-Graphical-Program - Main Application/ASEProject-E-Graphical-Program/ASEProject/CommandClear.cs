﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    /// <summary>
    /// Represents the circle command class.
    /// </summary>
    public class CommandClear : ICommand
    {
        /// <summary>
        /// Calls and executes the command clear from the CommandLibrary.
        /// </summary>
        /// <param name="commandEntryList">The list to which this command belongs to.</param>
        /// <param name="parameters">Not required for this command.</param>
        public void Execute(CommandLibrary commandEntryList, string[] parameters)
        {
            commandEntryList.Clear();
        }
    }
}
