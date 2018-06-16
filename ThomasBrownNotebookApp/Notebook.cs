using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    class Notebook
    {
        const string INTROMESSAGE = "Welcome to the Notebook Application";
        const string OUTROMESSAGE = "Goodbye";

        List<IPageable> _pages;

        public delegate void CommandFunction(string command);

        private Dictionary<string, CommandFunction> _decodeCommands = new Dictionary<string, CommandFunction>();
        private readonly string _show = "show", _new = "new", _delete = "delete";

        public CommandFunction this[string command] => _decodeCommands[command];

        public void FillDictionary()
        {
            _decodeCommands.Add(_show, ShowPages);
            _decodeCommands.Add(_new, NewPage);
            _decodeCommands.Add(_delete, DeletePage);
        }

        public void ShowPages(string command)
        {
            Console.WriteLine($"Showing {command}");
        }

        public void NewPage(string command)
        {
            Console.WriteLine($"Creating {command}");
        }

        public void DeletePage(string command)
        {
            Console.WriteLine($"Deleting {command}");
        }
    }
}
