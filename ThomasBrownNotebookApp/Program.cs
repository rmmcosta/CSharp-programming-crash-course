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
            //if we want to create a notebook with new commands
            //Notebook notebook = new Notebook("Listar","Criar","Eliminar","Sair");
            //we can also define just a part of the commands
            //Notebook notebook = new Notebook("Listar", "Criar");

            NotebookLogger notebookLogger = new NotebookLogger(notebook);

            string[] commands;
            Console.WriteLine(Notebook.INTROMESSAGE);
            notebook.ShowCommands("");
            do
            {
                Console.WriteLine("Input commands:");
                string input = Console.ReadLine();
                commands = input.Split(' ');
                notebook[commands[0]](commands.Length > 1 ? commands[1] : "");
            } while (commands[0] != notebook._exit);
            Console.WriteLine(Notebook.OUTROMESSAGE);
        }
    }
}
