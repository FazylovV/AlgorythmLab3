using AlgorythmLab3.List;
using System.Collections;

namespace AlgorythmLab3.Stack_and_Queue;

public class MyStack<T> : IStorable<T>, IExecutable, IConsolable
{
    private List.LinkedList<T> _list;
    
    public MyStack()
    {
        _list = new List.LinkedList<T>();
    }
    
    public void Push(T value)
    {
        _list.AddHead(value);
    }

    public object Pop()
    {
        if (_list.head == null) return 0;
        object obj = _list.head.Data;
        _list.RemoveHead();
        return obj;
    }

    public bool IsEmpty()
    {
        return _list.Count == 0;
    }

    public object Top()
    {
        return _list.head.Data;
    }

    public void Print()
    {
        Node<T> current = _list.head;

        while (current != null)
        {
            //Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public long Execute(int n)
    {
        return Measurements.ProcessInput(Program.Inputs[n], new MyStack<object>());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T> current = _list.head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
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

    public void PopForConsole()
    {
        Console.WriteLine(Pop());
    }

    public void IsEmptyForConsole()
    {
        if(_list.Count == 0)
        {
            Console.WriteLine("Стек пуст.");
            return;
        }
        Console.WriteLine("Стек не пуст.");
    }

    public void TopForConsole()
    {
        Console.WriteLine(_list.head.Data);
    }
}