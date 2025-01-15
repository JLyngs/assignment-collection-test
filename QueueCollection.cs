using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CollectionTester
{
    public class QueueCollection<T> : BaseCollection<T>
    {
        private Queue<T> _queue = new();

        protected override void FillCollectionInternal(string[] input, Func<string, T> func)
        {
            foreach (var line in input)
            {
                _queue.Enqueue(func(line));
            }
        }

        protected override void SortCollectionInternal(Func<T, T> comparer)
        {
            var sortedList = _queue.OrderBy(comparer).ToList();
            _queue = new Queue<T>(sortedList);
        }

        protected override void PrintCollectionInternal(TextWriter writer)
        {
            foreach (var line in _queue)
            {
                writer.WriteLine(line);
            }
        }

        public override T FirstObject()
        {
            return _queue.Peek();
        }

        public override T LastObject()
        {
            return _queue.Last();
        }

        public override int Count()
        {
            return _queue.Count;
        }
    }
}
