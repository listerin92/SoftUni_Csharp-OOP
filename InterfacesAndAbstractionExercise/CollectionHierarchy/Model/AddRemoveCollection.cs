using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection, IItem
    {
        private readonly IList<IItem> items;

        public AddRemoveCollection()
        {
            this.items = new List<IItem>();
        }

        public AddRemoveCollection(string str) :this()
        {
            this.Str = str;
        }
        public string Str { get; protected set; }
        public IReadOnlyCollection<IItem> AddRemoveCollectionList => (IReadOnlyCollection<IItem>)this.items;

        public virtual int Add(IItem item)
        {
            this.items.Insert(0, item);
            return this.items.IndexOf(item);
        }

        public virtual string Remove()
        {
            string oldItem = items.Last().Str;
            this.items.Remove(items.Last());
            return oldItem;
        }
    }
}