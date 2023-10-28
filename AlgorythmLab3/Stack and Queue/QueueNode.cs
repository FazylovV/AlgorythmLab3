using AlgorythmLab3.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class QueueNode<T>
    {
        public T Data { get; set; }
        public QueueNode<T>? Next { get; set; }
        public QueueNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}