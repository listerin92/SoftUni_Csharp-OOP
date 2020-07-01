using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CustomRandomList
{
    using System;
    using System.Linq;
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList(IEnumerable<string> data):base(data)
        {
            random = new Random();
        }
        public string RandomString()
        {
            string result = string.Empty;
            int index = random.Next(0, this.Count);
            result = this[index];
            this.RemoveAt(index);
            return result;
        }
    }
}
