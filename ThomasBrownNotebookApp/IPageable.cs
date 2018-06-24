namespace ThomasBrownNotebookApp
{
    struct PageData
    {
        public string Author, Title;
    }

    interface IPageable
    {
        IPageable Input();
        void Output();
        PageData ThePageData { get; set; }
    }
}
