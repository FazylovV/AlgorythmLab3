using AlgorythmLab3.List;
using AlgorythmLab3.Stack_and_Queue;
using System.Runtime.ExceptionServices;

namespace AlgorythmLab3
{
    public class Program
    {
        public static string[] Inputs = new string[10000];
        //= File.ReadAllLines("c:\\test\\input.txt");
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
            for(int i = 1; i < 1000; i += 1)
            {
                Inputs[i] = Input.CreateInput(i);
            }
            List<Data> data = new();
            data.Add(Measurements.RequestTheData("MyQueueList", new MyQueueList<object>()));
            data.Add(Measurements.RequestTheData("MyQueueQueue", new MyQueueQueue<object>()));
            Drawer.Draw("MyQueues", Measurements.SavePath, data);
        }
    }
}