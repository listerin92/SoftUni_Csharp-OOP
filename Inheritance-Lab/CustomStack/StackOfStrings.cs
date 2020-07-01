using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {

        public bool IsEmpty()
        {
            return !this.Any();
        }

        public void AddRange(IEnumerable<string> data)
        {
            foreach (var d in data)
            {
                this.Push(d);
            }
        }
    }
}
