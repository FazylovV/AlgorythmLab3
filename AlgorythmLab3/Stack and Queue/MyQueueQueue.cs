using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    class MyQueueQueue<T> : IStorable<T>, IExecutable
    {
        public Queue<T> Values { get; private set; } = new();

        public bool IsEmpty()
        {
            return Values.Count == 0;
        }

        public object Pop()
        {
            return Values.Dequeue();
        }

        public void Print()
        {
            foreach(object item in Values)
            {
                Console.Write($"{item} ");
            }
        }

        public void Push(T item)
        {
            Values.Enqueue(item);
        }

        public object Top()
        {
            return Values.Peek();
        }
        public long  Execute(int n)
        {
            return ProcessInput(Program.Inputs[n]);
        }

        private long ProcessInput(string input)
        {
            string[] operations = input.Split(" ");
            MyQueueQueue<object> queue = new();

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
