using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    class NotebookLogger
    {
        private Notebook _trackedNotebook;
        private bool _isLogging = true;

        public NotebookLogger(Notebook notebook)
        {
            _trackedNotebook = notebook;
            _trackedNotebook.OnToggleLogging += ToggleLogging;
            Attach();
        }

        private void PrintPageAdded(string pageType)
        {
            Console.WriteLine($"{pageType} created!");
        }

        private void PrintPageDeleted(string pageId)
        {
            if (pageId != "")
            {
                Console.WriteLine($"The page {pageId} was deleted!");
            }
            else
            {
                Console.WriteLine($"All pages were deleted!");
            }
        }

        private void IncorrectCommand(string incorrectCommandMessage)
        {
            Console.WriteLine($"Bad Command: {incorrectCommandMessage}");
        }

        private void Attach()
        {
            _trackedNotebook.OnIncorrectCommand += IncorrectCommand;
            _trackedNotebook.OnPageAdded += PrintPageAdded;
            _trackedNotebook.OnPageDeleted += PrintPageDeleted;
        }

        private void Detach()
        {
            _trackedNotebook.OnIncorrectCommand -= IncorrectCommand;
            _trackedNotebook.OnPageAdded -= PrintPageAdded;
            _trackedNotebook.OnPageDeleted -= PrintPageDeleted;
        }

        private void ToggleLogging(bool isOn)
        {
            if (isOn)
            {
                if (!_isLogging)
                {
                    Attach();
                }
                else
                {
                    Console.WriteLine("Logging already On!");
                    return;
                }
            }
            else
            {
                if (_isLogging)
                {
                    Detach();
                }
                else
                {
                    Console.WriteLine("Logging already Off!");
                    return;
                }
            }

            _isLogging = isOn;
            Console.WriteLine($"Logging turned {(_isLogging ? "On":"Off")}!");
        }
    }
}
