namespace AlgorythmLab3.Stack_and_Queue;

public interface IStorable
{
    void Push();
    object Pop();
    bool IsEmpty();
    object Top();
    void Print();
}