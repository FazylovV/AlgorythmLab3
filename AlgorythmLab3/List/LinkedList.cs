namespace AlgorythmLab3
{


    public class LinkedList<T>
    {
        /// <summary>
        /// Возвращает значение первого элемента списка
        /// </summary>
        public Node<T>? Head { get; private set; }
        /// <summary>
        /// Возвращает значение последнего элемента списка
        /// </summary>
        public Node<T>? Tail { get; private set; }

        /// <summary>
        /// Создаёт новый узел с заданным объектом, и помещает его в начало списка
        /// </summary>
        public void AddHead(T item)
        {

            if (Head != null)
            {
                Head.Previous = new Node<T>(item);
                Head.Previous.Next = Head;
                Head = Head.Previous;
            }
            else
            {
                Head = new Node<T>(item);
                Tail = Head;
            }
        }
        /// <summary>
        /// Создаёт новый узел с заданным объектом, и помещает его в конец списка
        /// </summary>
        public void AddTail(T item)
        {
            if (Tail != null)
            {
                Tail.Next = new Node<T>(item);
                Tail.Next.Previous = Tail;
                Tail = Tail.Next;
            }
            else
            {
                Tail = new Node<T>(item);
                Head = Tail;
            }
        }
        /// <summary>
        /// Удаляет первый объект списка. Первым объектом по возможности становится следующий
        /// </summary>
        public void RemoveHead()
        {
            if (Head == null) return;
            if (Head.Next != null)
            {
                Head.Next.Previous = null;
                Head = Head.Next;
            }
            else Head = null;
        }
        /// <summary>
        /// Удаляет последний объект списка. Последним объектом по возможности становится предыдущий
        /// </summary>
        public void RemoveTail()
        {
            if (Tail == null) return;
            if (Tail.Next != null)
            {
                Tail.Next.Previous = null;
                Tail = Tail.Next;
            }
            else Tail = null;
        }
        /// <summary>
        /// Считает количество элементов в списке
        /// </summary>
        public int Count()
        {
            int count = 0;
            if (Head == null) return 0;
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }
        /// <summary>
        /// Проверяет наличие элемента в списке, возвращая его номер при наличии (начиная с 0) или -1 при отсутствии
        /// </summary>
        public int Contain(T item)
        {
            if (Head == null) return -1;
            Node<T> currentNode = Head;
            int listLength = this.Count();
            for (int i = 0; i < listLength; i++)
            {
                if (currentNode.Data == null) continue;
                if (currentNode.Data.Equals(item))
                    return i;
                currentNode = currentNode.Next;
            }
            return -1;
        }
        /// <summary>
        /// Считает количество различных элементов в списке
        /// </summary>
        public int DistinctCount()
        {
            LinkedList<T> distinctVariables = new LinkedList<T>();
            int listLength = this.Count();
            Node<T> currentNode = Head;
            while (currentNode.Data != null)
            {
                if (distinctVariables.Contain(currentNode.Data) != -1)
                    continue;
                distinctVariables.AddTail(currentNode.Data);
            }
            return distinctVariables.Count();
        }
        /// <summary>
        /// Возвращает копию изначального списка (но с другими ссылками)
        /// </summary>
        public LinkedList<T> Copy()
        {
            LinkedList<T> newList = new LinkedList<T>();
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                newList.AddTail(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return newList;
        }
        /// <summary>
        /// Единожды вставляет список сам в себя после элемента Х 
        /// </summary>
        public void InsertAfterX(T x)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Data == null) continue;
                if (currentNode.Data.Equals(x))
                {
                    LinkedList<T> insertList = this.Copy();
                    if (this.Tail != currentNode)
                    {
                        currentNode.Next.Previous = insertList.Tail;
                        insertList.Tail.Next = currentNode.Next;
                    }
                    else
                    {
                        this.Tail = insertList.Tail;
                    }
                    currentNode.Next = insertList.Head;
                    insertList.Head.Previous = currentNode;
                    return;
                }
            }

        }
    }
}
