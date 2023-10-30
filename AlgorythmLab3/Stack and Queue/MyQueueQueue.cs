using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    class MyQueueQueue<T> : IStorable<T>, IExecutable
    {
        public Queue<object> Values { get; private set; }

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
        public void Execute(int n)
        {
            ProcessInput(Program.Inputs[n]);
        }

        private void ProcessInput(string input)
        {
            string[] data = new string[1];
            if (input.Split(" ").Length > 1)
            {
                data = input.Split(" ");
            }
            else
            {
                data = new string[1] { input };
            }
            MyQueueList<object> queue = new();
            foreach (string s in data)
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
        }

        public static long Timer(int variableCount)
        {
            return Measurements.Timer(variableCount, new MyQueueQueue<object>());
        }
    }
}
