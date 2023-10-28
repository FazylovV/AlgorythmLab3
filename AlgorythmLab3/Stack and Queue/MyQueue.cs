using AlgorythmLab3.List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public QueueNode<T>? Head {  get; private set; }
        public QueueNode<T>? Tail { get; private set; }

        public void Enqueue(T item)
        {
            QueueNode<T> node = new(item);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                QueueNode<T> temp = Tail;
                Tail = node;
                temp.Next = Tail;
            }
        }

        public T Dequeue()
        {
            if(Head != null)
            {
                T value = Head.Data;
                Head = Head.Next;
                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public T First()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return Head.Data;
        }

        public void Print()
        {
            QueueNode<T> currentNode = Head;
            while (currentNode != null)
            {
                Console.Write($" {currentNode.Data} ");
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QueueNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}