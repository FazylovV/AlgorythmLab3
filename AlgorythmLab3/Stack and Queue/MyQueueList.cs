using AlgorythmLab3.List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class MyQueueList : IStorable, IExecutable
    {
        public List.LinkedList<object>? Values { get; private set; } = new();

        public void Push(object item)
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
            Node<object> value = Values.head;
            while (value != null)
            {
                Console.Write($"{value.Data} ");
                value = value.Next;
            }
        }

        public void Execute(int n)
        {
            ProcessInput(Program.Inputs[n]);
        }

        private void ProcessInput(string input)
        {
            string[] data = new string[1];
            if(input.Split(" ").Length > 1)
            {
                data = input.Split(" ");
            }
            else
            {
                data = new string[1] { input };
            }
            MyQueueList queue = new();
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
            return Measurements.Timer(variableCount, new MyQueueList());
        }
    }

}