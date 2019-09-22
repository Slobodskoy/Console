using Notes.Extention;
using Notes.Infrastructure;

namespace Notes.View
{
    public class PageView<V, C> : MasterView
    {
        public PageView() { }
        public PageView(PageInfo info, V model) : base(info)
        {
            this.Info = info;
            this.Model = model;
        }

        public PageInfo Info { get; set; }
        public V Model { get; set; }
        public override void Render()
        {
            base.Render();
            ConsoleExt.H(Info.PageName);
            ConsoleExt.Hr();
        }

        public C Controller { get; set; }
    }
}
