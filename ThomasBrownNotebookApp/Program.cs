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
            //notebook = new Notebook("1", "2", "3","4");
            string[] commands;
            Console.WriteLine(Notebook.INTROMESSAGE);
            notebook.ShowCommands("");
            do
            {
                Console.WriteLine("Input commands:");
                commands = Console.ReadLine().Split(' ');
                notebook[commands[0]](commands.Length > 1 ? commands[1] : "");
            } while (commands[0] != notebook._exit);
            Console.WriteLine(Notebook.OUTROMESSAGE);
        }
    }
}
