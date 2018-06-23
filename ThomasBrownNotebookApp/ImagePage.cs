using System;

namespace ThomasBrownNotebookApp
{
    class ImagePage : IPageable
    {
        private PageData _pageData;
        private string asciiImage;
        public PageData MyPageData { get => _pageData; set => _pageData = value; }

        public IPageable Input()
        {
            return this;
        }

        public void Output()
        {
            throw new NotImplementedException();
        }
    }
}
