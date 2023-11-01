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
    public class MyQueueList<T> : IStorable<T>, IExecutable, IConsolable
    {
        public List.LinkedList<T> Values { get; private set; } = new();

        public void Push(T item)
        {
            Values.AddTail(item);
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


        public object Pop()
        {
            object firstElement = Values.head.Data;
            Values.RemoveHead();
            return firstElement;
        }
        public void PopForConsole()
        {
            object firstElement = Values.head.Data;
            Values.RemoveHead();
            Console.WriteLine(firstElement);
        }
        public bool IsEmpty()
        {
            return Values.Count == 0;
        }
        public void IsEmptyForConsole()
        {
            if(Values.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }
            Console.WriteLine("Очередь не пуста.");
        }

        public object Top()
        {
            return Values.head.Data;
        }
        public void TopForConsole()
        {
            Console.WriteLine(Values.head.Data);
        }

        public void Print()
        {
            ConsoleHelper.PrintOldStructure((IStorable<object>)this, false);
        }

        public long Execute(int n)
        {
            return Measurements.ProcessInput(Program.Inputs[n], new MyQueueList<object>());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Values.head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}