using System;
using System.Collections.Generic;

namespace task8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage a = new Storage();
            Storage b = new Storage();
            SortedSet<Product> set1 = new SortedSet<Product>();
            foreach (Product p in a.Products)
            {
                set1.Add(p);
            }
            SortedSet<Product> set2 = new SortedSet<Product>();
            foreach (Product p in b.Products)
            {
                set2.Add(p);
            }
            set1.IntersectWith(set2);
            set1.ExceptWith(set2);
            set1.SymmetricExceptWith(set2);
        }
    }
}
