using System;

namespace ThomasBrownNotebookApp
{
    class MessagePage : IPageable
    {
        protected PageData _pageData;
        protected string _message;

        public PageData ThePageData { get => _pageData; set => _pageData = value; }

        public virtual IPageable Input()
        {
            Console.WriteLine("Author:");
            _pageData.Author = Console.ReadLine();
            Console.WriteLine("Title:");
            _pageData.Title = Console.ReadLine();
            Console.WriteLine("Message:");
            _message = Console.ReadLine();
            return this;
        }

        public void Output()
        {
            Console.WriteLine($"\n/{"-".PadRight(15, '-')}Message{"-".PadRight(15,'-')}\\" +
                $"\n Title: { _pageData.Title}" + 
                $"\n\n{_message}\n" +
                $" written by {_pageData.Author}\n\n" +
                $"\\{"-".PadRight(37, '-')}/");
        }
    }
}
