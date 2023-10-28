using AlgorythmLab3.List;

namespace AlgorythmLab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AlgorythmLab3.List.LinkedList<int> ints = new();
            AlgorythmLab3.List.LinkedList<int> cuts = ints.Split(1);
        }
    }
}