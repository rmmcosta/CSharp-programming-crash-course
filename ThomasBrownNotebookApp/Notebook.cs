using System;
using System.Collections.Generic;

namespace ThomasBrownNotebookApp
{
    class Notebook
    {
        public const string INTROMESSAGE = "Welcome to the Notebook Application done By RC based on the work of Thomas Brown";
        public const string OUTROMESSAGE = "Goodbye";

        List<IPageable> _pages;

        public delegate void CommandFunction(string command);

        private Dictionary<string, CommandFunction> _decodeCommands = new Dictionary<string, CommandFunction>();
        public readonly string _show = "show", _new = "new", _delete = "delete", _exit = "exit";

        public CommandFunction this[string command] => _decodeCommands.ContainsKey(command) ? _decodeCommands[command] : ShowCommands;

        public Notebook()
        {
            _decodeCommands.Add(_show, ShowPages);
            _decodeCommands.Add(_new, NewPage);
            _decodeCommands.Add(_delete, DeletePage);
            _decodeCommands.Add(_exit, ExitApplication);
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
                    case 3:
                        _decodeCommands.Remove(_exit);
                        _decodeCommands.Add(_exit = newCommands[i], ExitApplication);
                        break;
                }
            }
        }

        private void ShowPages(string command)
        {
            switch (command)
            {
                case "pages":
                    Console.WriteLine("showing all pages");
                    break;
                default:
                    int idOfPage = 0;
                    if (int.TryParse(command, out idOfPage))
                    {
                        Console.WriteLine("showing the page {0}", idOfPage);
                    } else
                    {
                        Console.WriteLine($"show commands:");
                        Console.WriteLine($"{"pages".PadRight(12, ' ')}lists all the created pages");
                        Console.WriteLine($"{"id of page".PadRight(12, ' ')}display that page");
                    }
                    break;
            }
        }

        private void NewPage(string command)
        {
            switch (command)
            {
                case "message":
                    Console.WriteLine("new message");
                    break;
                case "list":
                    Console.WriteLine("new list");
                    break;
                case "image":
                    Console.WriteLine("new image");
                    break;
                default:
                    Console.WriteLine($"new commands:");
                    Console.WriteLine($"{"message".PadRight(12, ' ')}create new message page");
                    Console.WriteLine($"{"list".PadRight(12, ' ')}create new list page");
                    Console.WriteLine($"{"image".PadRight(12, ' ')}create new image page");
                    break;
            }
        }

        private void DeletePage(string command)
        {
            switch (command)
            {
                case "all":
                    Console.WriteLine("deleting all pages");
                    break;
                default:
                    int idOfPage = 0;
                    if (int.TryParse(command, out idOfPage))
                    {
                        Console.WriteLine("deleting the page {0}", idOfPage);
                    }
                    else
                    {
                        Console.WriteLine($"delete commands:");
                        Console.WriteLine($"{"all".PadRight(12, ' ')}delete all the created pages");
                        Console.WriteLine($"{"id of page".PadRight(12, ' ')}delete that page");
                    }
                    break;
            }
        }

        private void ExitApplication(string command)
        {
        }

        public void ShowCommands(string dummy)
        {
            Console.WriteLine($"Please enter: " +
                $"{_show}, " +
                $"{_new}, " +
                $"{_delete} " +
                $"or {_exit}");
        }
    }
}
