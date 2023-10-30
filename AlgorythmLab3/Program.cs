using AlgorythmLab3.List;
using AlgorythmLab3.Stack_and_Queue;

namespace AlgorythmLab3
{
    public class Program
    {
        public static string[] Inputs = new string[100000];
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


            List<Data> data = new();
            data.Add(Measurements.RequestTheData("MyQueueList.Timer"));
            data.Add(Measurements.RequestTheData("MyQueueQueue.Timer"));
            Drawer.Draw("MyQueues", Measurements.SavePath, data);
        }
    }
}