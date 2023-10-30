using AlgorythmLab3.List;

namespace AlgorythmLab3.Stack_and_Queue;

public class MyStack<T> : IStorable<T>, IExecutable
{
    private List.LinkedList<T> _list;
    
    public MyStack()
    {
        _list = new List.LinkedList<T>();
    }
    
    public void Push(T obj)
    {
        _list.AddHead(obj);
    }

    public object Pop()
    {
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
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public long Execute(int n)
    {
        return Measurements.ProcessInput(Program.Inputs[n], new MyStack<object>());
    }
}