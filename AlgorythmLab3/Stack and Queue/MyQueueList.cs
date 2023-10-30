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
            return ProcessInput(Program.Inputs[n]);
        }

        private long ProcessInput(string input)
        {
            string[] operations = input.Split(" ");
            MyQueueList<object> queue = new();

            Stopwatch timer = new();
            timer.Start();
            foreach (string s in operations)
            {
                switch (s[0])
                {
                    case '1':
                        queue.Push(s.Split(",")[1]);
                        break;
                    case '2':
                        queue.Pop();
                        break;
                    case '3':
                        queue.Top();
                        break;
                    case '4':
                        queue.IsEmpty();
                        break;
                    case '5':
                        queue.Print();
                        break;
                }
            }
            timer.Stop();

            return timer.ElapsedTicks;
        }
    }

}