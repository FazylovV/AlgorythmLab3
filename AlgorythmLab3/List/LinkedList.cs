namespace AlgorythmLab3
{


    public class LinkedList<T>
    {
        /// <summary>
        /// ���������� �������� ������� �������� ������
        /// </summary>
        public Node<T>? Head { get; private set; }
        /// <summary>
        /// ���������� �������� ���������� �������� ������
        /// </summary>
        public Node<T>? Tail { get; private set; }

        /// <summary>
        /// ������ ����� ���� � �������� ��������, � �������� ��� � ������ ������
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
        /// ������ ����� ���� � �������� ��������, � �������� ��� � ����� ������
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
        /// ������� ������ ������ ������. ������ �������� �� ����������� ���������� ���������
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
        /// ������� ��������� ������ ������. ��������� �������� �� ����������� ���������� ����������
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
        /// ������� ���������� ��������� � ������
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
        /// ��������� ������� �������� � ������, ��������� ��� ����� ��� ������� (������� � 0) ��� -1 ��� ����������
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
        /// ������� ���������� ��������� ��������� � ������
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
        /// ���������� ����� ������������ ������ (�� � ������� ��������)
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
        /// �������� ��������� ������ ��� � ���� ����� �������� � 
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
