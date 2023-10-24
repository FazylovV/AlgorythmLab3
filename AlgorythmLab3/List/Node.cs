using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.List
{
    internal class Node<T>
    {
        /// <summary>
        /// Возвращает значение объекта в узле
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Возвращает ссылку на следующий объект, или null, если такого нет
        /// </summary>
        public Node<T>? Next { get; set; }
        /// <summary>
        /// Возвращает ссылку на предыдущий объект, или null, если такого нет
        /// </summary>
        public Node<T>? Previous { get; set; }

        public Node(T data)
    {
            Previous = null;
            Data = data;
            Next = null;
        }
    }
}
