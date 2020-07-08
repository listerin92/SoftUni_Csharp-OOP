using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : IItem, IAddCollection
    {
        private readonly IList<IItem> items;

        public AddCollection()
        {
            this.items = new List<IItem>();

        }
        public AddCollection(string str) : this()
        {
            this.Str = str;
        }

        public IReadOnlyCollection<IItem> AddCollectionList => (IReadOnlyCollection<IItem>)this.items;

        public int Add(IItem item)
        {
            this.items.Add(item);
            return this.items.IndexOf(item);
        }

        public string Str { get; }
    }
}