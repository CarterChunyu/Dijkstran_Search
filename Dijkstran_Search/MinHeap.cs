using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstran_Search
{
    class MinHeap<E> where E:IComparable<E>
    {
        private E[] heap;
        private int N;

        public MinHeap(int capacity)
        {
            this.heap = new E[capacity];
            this.N = 0;
        }
        public MinHeap() : this(5)
        {
            
        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        private void ResetCapacity(int capacity)
        {
            E[] temp = new E[capacity];
            for (int i = 1; i <= N; i++)
                temp[i] = heap[i];
            this.heap = temp;            
        }
        private void Swap(int i,int j)
        {
            E temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <=N ; i++)
            {
                if (i < N)
                    builder.Append($"{heap[i]},");
                else
                    builder.Append(heap[i]);
            }
            return builder.ToString();
        }
        public void Add(E e)
        {
            if (N + 1 == this.heap.Length)
                ResetCapacity(2 * heap.Length);
            this.heap[N + 1] = e;
            N++;
            Swim(N);
        }
        private void Swim(int index)
        {
            while(index>1&&heap[index].CompareTo(heap[index/2])<0)
            {
                Swap(index, index / 2);
                index = index / 2;
            }
        }
        public E RemoveMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空堆");
            E min = heap[1];
            Swap(1, N);
            N--;
            if (N + 1 == this.heap.Length / 4)
                ResetCapacity(this.heap.Length / 2);
            Sink(1);
            return min;
        }
        private void Sink(int index)
        {
            int select = index * 2;
            while (index * 2 <= N)
            {
                if (select + 1 <= N && heap[select + 1].CompareTo(heap[select]) < 0)
                    select = select + 1;
                if (heap[select].CompareTo(heap[index]) >= 0)
                    break;
                Swap(index, select);
                index = select;
            }
        }
        public E GetMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空堆");
            return this.heap[1];
        }
    }
}
