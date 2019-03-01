using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = CreateListAndFill(100, 1.0);
            List<DateTime> dList = CreateListAndFill(100, DateTime.Now);

            for (int i =0; i<list.Count; i+=10)
            {
                list[i] = Math.Round(Math.Sqrt(list[i]), 2);
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static List <T>CreateListAndFill<T>(int capacity, T fillValue)
        {
            List<T> list = new List<T>(capacity);
            for (int i = 0; i < capacity; ++i) list.Add(fillValue);
            return list; 
        }
    }
}