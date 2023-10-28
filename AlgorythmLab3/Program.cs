using AlgorythmLab3.List;

namespace AlgorythmLab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AlgorythmLab3.List.LinkedList<int> ints = new();
            ints.AddTail(1);
            ints.AddTail(2);
            ints.AddTail(3);
            ints.AddTail(4);
            ints.AddTail(5);
            ints.AddTail(6);
            ints.Swap(3, 6);
            ints.Swap(1, 6);
        }
    }
}