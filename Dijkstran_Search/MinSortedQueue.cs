using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstran_Search
{
    class MinSortedQueue<E> : IQueue<E> where E : IComparable<E>
    {
        private MinHeap<E> heap;
        public MinSortedQueue(int capacity)
        {
            this.heap = new MinHeap<E>(capacity);
        }
        public MinSortedQueue()
        {
            this.heap = new MinHeap<E>();
        }
        public int Count { get { return heap.Count; } }

        public bool IsEmpty { get { return heap.IsEmpty; } }

        public E Dequeue()
        {
            return heap.RemoveMin();
        }

        public void Enqueue(E e)
        {
            heap.Add(e);
        }

        public E Peek()
        {
            return heap.GetMin();
        }
    }
}
