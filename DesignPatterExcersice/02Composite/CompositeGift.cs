using System;
using System.Collections.Generic;

namespace _02Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{this.name} contains the following products with price:");
            foreach (var gift in this.gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}