using System;

namespace ThomasBrownNotebookApp
{
    class ImagePage : IPageable
    {
        private PageData _pageData;
        private string _asciiImage;
        public PageData ThePageData { get => _pageData; set => _pageData = value; }

        public IPageable Input()
        {
            Console.WriteLine("Author:");
            _pageData.Author = Console.ReadLine();
            Console.WriteLine("Title:");
            _pageData.Title = Console.ReadLine();
            Console.WriteLine("Start inputing the image until CTRL-D is found:");
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                //entered CTRL-D
                if( (keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control
                    &&
                    keyInfo.Key == ConsoleKey.D
                )
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    _asciiImage += "\n";
                }
                else
                {
                    Console.Write(keyInfo.KeyChar);
                    _asciiImage += keyInfo.KeyChar;
                }
            }
            Console.WriteLine();
            _asciiImage += "\n";
            return this;
        }

        public void Output()
        {
            Console.WriteLine($"\n/{"-".PadRight(15, '-')}Message{"-".PadRight(15, '-')}\\" +
                $"\n Title: { _pageData.Title}" +
                $"\n\n{_asciiImage}\n" +
                $" designed by {_pageData.Author}\n\n" +
                $"\\{"-".PadRight(37, '-')}/");
        }
    }
}
