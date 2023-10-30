using AlgorythmLab3.List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class MyQueueList<T> : IStorable<T>, IExecutable
    {
        public List.LinkedList<T>? Values { get; private set; } = new();

        public void Push(T item)
        {
            Values.AddTail(item);
        }

        public object Pop()
        {
            object firstElement = Values.head.Data;
            Values.RemoveHead();
            return firstElement;
        }

        public bool IsEmpty()
        {
            return Values.Count == 0;
        }

        public object Top()
        {
            return Values.head.Data;
        }
        public void Print()
        {
            Node<T> value = Values.head;
            while (value != null)
            {
                Console.Write($"{value.Data} ");
                value = value.Next;
            }
        }

        public long Execute(int n)
        {
            return Measurements.ProcessInput(Program.Inputs[n], new MyQueueList<object>());
        }
    }

}