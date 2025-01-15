using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace CollectionTester
{
    public class ArrayListCollection<T> : BaseCollection<T>
    {
        private ArrayList arraylist = new ArrayList();

        protected override void FillCollectionInternal(string[] input, Func<string, T> func)
        {
            foreach (var line in input)
            {
                arraylist.Add(func(line));
            }
        }

        protected override void SortCollectionInternal(Func<T, T> comparer)
        {
            arraylist.Sort();
        }

        protected override void PrintCollectionInternal(TextWriter writer)
        {
            foreach (var line in arraylist)
            {
                writer.WriteLine(line);
            }
        }

        public override T FirstObject()
        {
            return (T)arraylist[0];
        }

        public override T LastObject()
        {
            return (T)arraylist[arraylist.Count - 1];
        }

        public override int Count()
        {
            return arraylist.Count;
        }
    }
}
