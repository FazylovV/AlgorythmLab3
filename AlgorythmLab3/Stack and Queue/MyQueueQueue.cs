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
    class MyQueueQueue<T> : IStorable<T>, IExecutable
    {
        public Queue<T> Values { get; private set; } = new();

        public bool IsEmpty()
        {
            return Values.Count == 0;
        }
        public void IsEmptyForConsole()
        {
            if (Values.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }
            Console.WriteLine("Очередь не пуста.");
        }

        public object Pop()
        {
            return Values.Dequeue();
        }
        public void PopForConsole()
        {
            object firstElement = Values.Dequeue;
            Console.WriteLine(firstElement);
        }

        public void Print()
        {
            ConsoleHelper.PrintOldStructure((IStorable<object>)this, false);
        }

        public void Push(T item)
        {
            Values.Enqueue(item);
        }
        public void PushForConsole()
        {
            IStorable<object> structure = (IStorable<object>)this;
            Console.Write("Введите новый элемент: ");
            string element = Console.ReadLine();

            while (element.Length == 0)
            {
                Console.Write("Неверный ввод, попробуйте снова: ");
                element = Console.ReadLine();
            }
            structure.Push(element);
        }

        public object Top()
        {
            return Values.Peek();
        }
        public void TopForConsole()
        {
            Console.WriteLine(Values.Peek);
        }

        public long  Execute(int n)
        {
            return Measurements.ProcessInput(Program.Inputs[n], new MyQueueQueue<object>());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach(T t in Values)
            {
                yield return t;
            }
        }
    }
}
