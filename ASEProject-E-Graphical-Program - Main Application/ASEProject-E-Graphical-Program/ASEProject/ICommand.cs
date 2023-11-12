using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{

    public interface ICommand
    {
        void Execute(CommandLibrary commandEntryList, string[] parameters);
    }
}
