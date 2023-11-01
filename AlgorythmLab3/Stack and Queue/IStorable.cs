namespace AlgorythmLab3.Stack_and_Queue;

public interface IStorable<T> : IEnumerable<T>
{
    void Push(T value);
    object Pop();
    bool IsEmpty();
    object Top();
    void Print();
}