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
            notebook.FillDictionary();
            notebook["show"]("stuff");
            notebook["delete"]("the page");
            notebook["new"]("things");
            notebook["cenas"]("things");
        }
    }
}
