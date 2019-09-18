using Notes.Extention;
using Notes.Infrastructure;

namespace Notes.View
{
    public class PageView<T, V> : MasterView<T>
        where T: Page<V>
    {
        protected V model;

        public PageView(T info, V model) : base(info)
        {
            this.model = model;
        }
        
        public override void Render()
        {
            base.Render();
            ConsoleExt.H(_info.PageName);
            ConsoleExt.Br();
        }
    }
}
