namespace AlgorythmLab3.Stack_and_Queue;

public interface IStorable<T>
{
    void Push(T obj);
    object Pop();
    bool IsEmpty();
    object Top();
    void Print();
}