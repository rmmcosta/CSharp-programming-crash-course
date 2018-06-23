namespace ThomasBrownNotebookApp
{
    class ListMessagePage : MessagePage
    {
        private enum BulletType { Dashed, Numbered, Star }
        private BulletType _bulletType;
        public override IPageable Input()
        {
            return this;
        }
    }
}
