using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    struct PageData
    {
        string Author, Title;
    }

    interface IPageable
    {
        IPageable Input();
        void Output();
        PageData MyPageData { get; set; }
    }
}
