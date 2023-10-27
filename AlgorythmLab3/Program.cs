// See https://aka.ms/new-console-template for more information

using AlgorythmLab3.Stack_and_Queue;

Console.WriteLine("Hello, World!");

var queue = new MyQueue<object>();
queue.Enqueue("string 1");
queue.Enqueue("string 2");
queue.Enqueue("string 3");
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

queue.Print();
Console.WriteLine();
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());