using System;

namespace ThomasBrownNotebookApp
{
    class ListMessagePage : MessagePage
    {
        private enum BulletType { dashed, numbered, star }
        private BulletType _bulletType;
        public override IPageable Input()
        {
            Console.WriteLine("Author:");
            _pageData.Author = Console.ReadLine();
            Console.WriteLine("Title:");
            _pageData.Title = Console.ReadLine();
            do
            {
                Console.WriteLine("What type of bullet do you want to use?");
                Console.WriteLine(string.Join(", ", Enum.GetNames(typeof(BulletType))));
            } while (!Enum.TryParse(Console.ReadLine(), out _bulletType));
            
            Console.WriteLine("Input the List until <Enter> with empty line is found:");
            string currentMessage;
            int messages = 0;
            while (true)
            {
                currentMessage = Console.ReadLine();
                if (currentMessage != "")
                {
                    messages++;
                    _message += $"{GetBulletTypeChar(_bulletType,messages)} {currentMessage}\n";
                } else
                {
                    break;
                }
            }
            return this;
        }

        private string GetBulletTypeChar(BulletType bulletType, int num)
        {
            switch (bulletType)
            {
                case BulletType.dashed:
                    return "- ";
                case BulletType.numbered:
                    return num.ToString() + " ";
                case BulletType.star:
                    return "* ";
                default:
                    return "  ";
            }
        }
    }
}
