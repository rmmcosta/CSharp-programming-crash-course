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
