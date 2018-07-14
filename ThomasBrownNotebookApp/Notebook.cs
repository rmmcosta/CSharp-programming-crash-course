using System;
using System.Collections.Generic;

namespace ThomasBrownNotebookApp
{
    class Notebook
    {
        public const string INTROMESSAGE = "Welcome to the Notebook Application done By RC based on the work of Thomas Brown";
        public const string OUTROMESSAGE = "Goodbye!!!";

        List<IPageable> _pages = new List<IPageable>();

        //delegates
        public delegate void CommandFunction(string command);
        public delegate void ToggleFunction(bool isOn);

        //dictionaries
        private Dictionary<string, CommandFunction> _decodeCommands = new Dictionary<string, CommandFunction>();
        public readonly string _show = "show", _new = "new", _delete = "delete", _log="log", _exit = "exit";

        //delegates implementation
        public CommandFunction this[string command] => _decodeCommands.ContainsKey(command) ? _decodeCommands[command] : ShowCommands;

        //events
        public event CommandFunction OnPageAdded, OnPageDeleted, OnIncorrectCommand;
        public event ToggleFunction OnToggleLogging;

        //constructors
        public Notebook()
        {
            _decodeCommands.Add(_show, ShowPages);
            _decodeCommands.Add(_new, NewPage);
            _decodeCommands.Add(_delete, DeletePage);
            _decodeCommands.Add(_log, Log);
            _decodeCommands.Add(_exit, ExitApplication);
        }
        /// <summary>  
        ///  Creates a new Notebook with customized input keywords  
        /// </summary> 
        /// <param name="newCommands">0 = show, 1 = new, 2 = delete</param>
        /// 
        // the this() it's so that if not all the commands are filled add the default ones 
        //by running the default constructor
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

        //instance methods
        private void ShowPages(string command)
        {
            switch (command)
            {
                case "pages":
                    Console.WriteLine($"\n/{"-".PadRight(15, '-')}Pages{"-".PadRight(15, '-')}\\");
                    for (int i = 0; i < _pages.Count; i++)
                    {
                        Console.WriteLine($"Id:{i} {_pages[i].ThePageData.Title}");
                    }
                    Console.WriteLine($"\\{"-".PadRight(37, '-')}/");
                    break;
                default:
                    int idOfPage = 0;
                    if (int.TryParse(command, out idOfPage))
                    {
                        if (idOfPage < _pages.Count)
                        {
                            _pages[idOfPage].Output();
                        }
                        else
                        {
                            //raise incorrect PageId event
                            if (OnIncorrectCommand != null)
                            {
                                OnIncorrectCommand("The Page Id you entered it's outside of the range!");
                            }
                        }
                    }
                    else
                    {
                        //raise incorrect command event
                        if (command != "" && OnIncorrectCommand != null)
                        {
                            OnIncorrectCommand("Wrong option for show command!");
                        }

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
                    _pages.Add(new MessagePage().Input());

                    //raise page add event
                    if (OnPageAdded != null)
                    {
                        OnPageAdded("Textual Message");
                    }

                    break;

                case "list":
                    _pages.Add(new ListMessagePage().Input());

                    //raise page add event
                    if (OnPageAdded != null)
                    {
                        OnPageAdded("Message List");
                    }

                    break;

                case "image":
                    _pages.Add(new ImagePage().Input());

                    //raise page add event
                    if (OnPageAdded != null)
                    {
                        OnPageAdded("Image");
                    }

                    break;

                default:

                    //raise incorrect command event
                    if (command !="" && OnIncorrectCommand != null)
                    {
                        OnIncorrectCommand("Wrong option for create command!");
                    }

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
                    _pages.Clear();

                    //raise page delete event
                    if (OnPageDeleted != null)
                    {
                        OnPageDeleted("");
                    }

                    break;

                default:
                    int idOfPage = 0;
                    if (int.TryParse(command, out idOfPage))
                    {
                        if (idOfPage < _pages.Count)
                        {
                            _pages.RemoveAt(idOfPage);

                            //raise page delete event
                            if (OnPageDeleted != null)
                            {
                                OnPageDeleted(idOfPage.ToString());
                            }
                        }
                        else
                        {
                            //raise incorrect PageId event
                            if (OnIncorrectCommand != null)
                            {
                                OnIncorrectCommand("The Page Id you entered it's outside of the range!");
                            }
                        }
                    }
                    else
                    {
                        //raise incorrect command event
                        if (command != "" && OnIncorrectCommand != null)
                        {
                            OnIncorrectCommand("Wrong option for delete command!");
                        }

                        Console.WriteLine($"delete commands:");
                        Console.WriteLine($"{"all".PadRight(12, ' ')}delete all the created pages");
                        Console.WriteLine($"{"id of page".PadRight(12, ' ')}delete that page");
                    }
                    break;
            }
        }

        private void Log(string command)
        {
            switch (command)
            {
                case "on":

                    //raise event start logging
                    if (OnToggleLogging != null)
                    {
                        OnToggleLogging(true);
                    }
                    break;

                case "off":
                    //raise event stop logging
                    if (OnToggleLogging != null)
                    {
                        OnToggleLogging(false);
                    }
                    break;

                default:

                    //raise incorrect command event
                    if (command != "" && OnIncorrectCommand != null)
                    {
                        OnIncorrectCommand("Wrong option for log command!");
                    }

                    Console.WriteLine($"log commands:");
                    Console.WriteLine($"{"on".PadRight(12, ' ')}turn on the logger");
                    Console.WriteLine($"{"off".PadRight(12, ' ')}turn off the logger");
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
                $"{_delete}, " +
                $"{_log} " +
                $"or {_exit}");
        }
    }
}
