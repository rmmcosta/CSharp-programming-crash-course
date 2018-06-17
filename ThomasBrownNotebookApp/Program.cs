using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            const string exitKeyword = "EXIT";
            /*notebook["show"]("stuff");
            notebook["delete"]("the page");
            notebook["new"]("things");
            notebook["cenas"]("things");*/
            string[] commands;
            Console.WriteLine(Notebook.INTROMESSAGE);
            do
            {
                Console.WriteLine("Input commands:");
                commands = Console.ReadLine().Split(' ');
                notebook[commands[0]](commands.Length > 1 ? commands[1] : "");
            } while (commands[0].ToUpper() != exitKeyword.ToUpper());
            Console.WriteLine(Notebook.OUTROMESSAGE);
        }
    }
}
