using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        private readonly IList<IItem> items;

        public MyList()
        {
            this.items = new List<IItem>();

        }

        public MyList(string str) : this()
        {
            base.Str = str;
        }
        

        public int Used => this.items.Count;

        public IReadOnlyCollection<IItem> Repairs => (IReadOnlyCollection<IItem>)this.items;
        public override int Add(IItem item)
        {
            this.items.Insert(0, item);
            return this.items.IndexOf(item);
        }
        public override string Remove()
        {
            string oldItem = this.items.First().Str;
            this.items.RemoveAt(0);
            return oldItem;
        }
    }
}