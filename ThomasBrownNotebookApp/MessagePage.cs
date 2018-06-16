using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasBrownNotebookApp
{
    class MessagePage : IPageable
    {
        protected PageData _pageData;
        protected string _message;

        public PageData MyPageData { get => _pageData; set => _pageData = value; }

        public virtual IPageable Input()
        {
            throw new NotImplementedException();
        }

        public void Output()
        {
            throw new NotImplementedException();
        }
    }
}
