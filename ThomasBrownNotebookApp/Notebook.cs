using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    class Notebook
    {
        public const string INTROMESSAGE = "Welcome to the Notebook Application done By RC based on the work of Thomas Brown";
        public const string OUTROMESSAGE = "Goodbye";

        List<IPageable> _pages;

        public delegate void CommandFunction(string command);

        private Dictionary<string, CommandFunction> _decodeCommands = new Dictionary<string, CommandFunction>();
        private readonly string _show = "show", _new = "new", _delete = "delete";

        public CommandFunction this[string command] => _decodeCommands.ContainsKey(command) ? _decodeCommands[command] : DoNothing;

        public Notebook()
        {
            _decodeCommands.Add(_show, ShowPages);
            _decodeCommands.Add(_new, NewPage);
            _decodeCommands.Add(_delete, DeletePage);
        }
        /// <summary>  
        ///  Creates a new Notebook with customized input keywords  
        /// </summary> 
        /// <param name="newCommands">0 = show, 1 = new, 2 = delete</param>
        public Notebook(params string[] newCommands) : this()
        {
            for (int i = 0; i < newCommands.Length; i++)
            {
                if (newCommands[i] == "")
                {
                    continue;
                }
                switch (i)
                {
                    case 0:
                        _decodeCommands.Remove(_show);
                        _decodeCommands.Add(_show = newCommands[i], ShowPages);
                        break;
                    case 1:
                        _decodeCommands.Remove(_new);
                        _decodeCommands.Add(_new = newCommands[i], NewPage);
                        break;
                    case 2:
                        _decodeCommands.Remove(_delete);
                        _decodeCommands.Add(_delete = newCommands[i], DeletePage);
                        break;
                }
            }
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

        public void DoNothing(string command)
        {

        }
    }
}
