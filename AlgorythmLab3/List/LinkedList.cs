namespace AlgorythmLab3.List;

using System.Collections.ObjectModel;
using static TypeChecker;


public class LinkedList<T>
{
    /// <summary>
    /// ������ ����������� ������� ������.
    /// </summary>
    private Node<T> head;
    /// <summary>
    /// ��������� ����������� ������� ������.
    /// </summary>
    private Node<T> tail;

    /// <summary>
    /// ����� ��������� � ������.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// �����, ������������ ����� ��������� ��������� ������, ����������� ����� �����.
    /// </summary>
    public int DistinctCount()
    {
        if (!IsIntegerType(typeof(T)))
        {
            Console.WriteLine("���� ����� ������������ ������ ��� �������������� ������.");
            return 0;
        }
        if (head == null) return 0;

        LinkedList<T> distinctVarsList = new();
        Node<T> currentNode = head;
        while (currentNode != null)
        {
            if (distinctVarsList.Contains(currentNode.Data) != -1)
            {
                currentNode = currentNode.Next;
                continue;
            }
            distinctVarsList.AddTail(currentNode.Data);
        }
        return distinctVarsList.Count;
    }

    /// <summary>
    /// �����, ����������� ������� �������� � ��������� ��������� � ������.
    /// </summary>
    /// <param name="data">������� ��������.</param>
    /// <returns></returns>
    public int Contains(T data)
    {
        if (head == null) return -1;

        Node<T> currentNode = head;
        for (int i = 0; i < Count; i++)
        {
            if (currentNode.Data == null) continue;
            if (currentNode.Data.Equals(data))
                return i;
            currentNode = currentNode.Next;
        }
        return -1;
    }

    /// <summary>
    /// �����, ������������ ����� ������.
    /// </summary>
    public LinkedList<T> Copy()
    {
        LinkedList<T> newList = new();
        Node<T> currentNode = head;
        while (currentNode != null)
        {
            newList.AddTail(currentNode.Data);
            currentNode = currentNode.Next;
        }
        return newList;
    }

    /// <summary>
    /// �����, �����������, �������� �� ������ ��������������� �� ����������.
    /// </summary>
    public bool IsSortedInAcsendingOrder()
    {
        if (!IsNumericType(typeof(T)))
        {
            Console.WriteLine("���� ����� ������������ ������ ��� ������ � ��������� ����������.");
            return false;
        }
        if (head == null || Count == 1) return true;

        Node<T> currentNode = head.Next;
        while (currentNode != null)
        {
            double currentData = double.Parse(currentNode.Data.ToString());
            double previousData = double.Parse(currentNode.Previous.Data.ToString());
            if (currentData < previousData)
                return false;
            currentNode = currentNode.Next;
        }
        return true;
    }

    /// <summary>
    /// �����, ����������� ����� ������� � ������ ������.
    /// </summary>
    /// <param name="data">�������� ������������ ��������.</param>
    public void AddHead(T data)
    {
        Node<T> newNode = new(data);
        AddHead(newNode);
    }

    /// <summary>
    /// �����, ����������� ������� � ������ ������.
    /// </summary>
    /// <param name="node">����������� �������.</param>
    private void AddHead(Node<T> node)
    {
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head.Previous = node;
            head = node;
        }

        Count++;
    }

    /// <summary>
    /// �����, ����������� ����� ������� � ����� ������.
    /// </summary>
    /// <param name="data">�������� ������������ ��������.</param>
    public void AddTail(T data)
    {
        Node<T> newNode = new(data);
        AddTail(newNode);
    }

    /// <summary>
    /// �����, ����������� ������� � ����� ������.
    /// </summary>
    /// <param name="node">����������� �������.</param>
    private void AddTail(Node<T> node)
    {
        if (tail == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Previous = tail;
            tail.Next = node;
            tail = node;
        }

        Count++;
    }

    /// <summary>
    /// �����, ����������� �������� ������ ����� ���������� ����.
    /// </summary>
    /// <param name="insertList">����������� ������.</param>
    /// <param name="node">���� ��� ����������� ����� �������.</param>
    private void Insert(LinkedList<T> insertList, Node<T> node)
    {
        if (tail != node)
        {
            node.Next.Previous = insertList.tail;
            insertList.tail.Next = node.Next;
        }
        else
        {
            tail = insertList.tail;
        }
        node.Next = insertList.head;
        insertList.head.Previous = node;
        Count += insertList.Count;
    }

    /// <summary>
    /// �����, ����������� �������� �������� ����� ���������� ����.
    /// </summary>
    /// <param name="insertData">�������� ������������ ��������.</param>
    /// <param name="node">���� ��� ����������� ����� �������.</param>
    private void Insert(T insertData, Node<T> node)
    {
        if (node == null)
        {
            AddHead(insertData);
            return;
        }

        Node<T> insertNode = new(insertData);
        if (tail != node)
        {
            node.Next.Previous = insertNode;
            insertNode.Next = node.Next;
        }
        else
        {
            tail = insertNode;
        }
        node.Next = insertNode;
        insertNode.Previous = node;
        Count++;
    }

    /// <summary>
    /// �����, ����������� ����� ����� ������ ����� ������� ��������� ���������� �������� ��������.
    /// </summary>
    /// <param name="data">�������� ��������, ����� �������� ��������� ������� ����� ������.</param>
    public void InsertCopyAfter(T data)
    {
        if (!IsNumericType(typeof(T)))
        {
            Console.WriteLine("���� ����� ������������ ������ ��� ������ � ��������� ����������.");
            return;
        }
        if (head == null) return;

        Node<T> currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.Data.Equals(data))
            {
                LinkedList<T> insertList = Copy();
                Insert(insertList, currentNode);
                return;
            }
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// �����, ����������� � ��������������� �� ���������� ������ ��������� ������� ��� ��������� ����������.
    /// </summary>
    /// <param name="data">�������� ������������ ��������.</param>
    public void InsertInSortedInAcsOrderList(T data)
    {
        if (!IsSortedInAcsendingOrder())
        {
            Console.WriteLine("���� ����� ������������ ������ ��� ���������������� �� ���������� ������.");
            return;
        }
        if (head == null)
        {
            Console.WriteLine("��� ���������� ������� �������� ������ ������ ��������� ���� �� ���� �������.");
            return;
        }

        double insertData = double.Parse(data.ToString());
        Node<T> currentNode = head;
        while (currentNode != null)
        {
            double currentData = double.Parse(currentNode.Data.ToString());
            if (insertData < currentData)
            {
                Insert(data, currentNode.Previous);
                return;
            }
            currentNode = currentNode.Next;
        }
        Insert(data, tail);
    }

    /// <summary>
    /// �����, ����������� ������� � ��������� ��������� ����� ������ ��������� �������� � �������� ���������.
    /// </summary>
    /// <param name="insertData">�������� ������������ ��������.</param>
    /// <param name="requiredData">�������� ��������, ����� �������� ��������� ������� �������� � ��������� ���������.</param>
    public void InsertBefore(T insertData, T requiredData)
    {
        if (head == null) return;

        Node<T> currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.Data.Equals(requiredData))
            {
                Insert(insertData, currentNode.Previous);
                return;
            }
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// �����, ��������� ������ ������� � ������.
    /// </summary>
    public void RemoveHead()
    {
        if (head == null) return;

        head = head.Next;
        head.Previous = null;
        Count--;
    }

    /// <summary>
    /// �����, ��������� ��������� ������� � ������.
    /// </summary>
    public void RemoveTail()
    {
        if (tail == null) return;

        tail = tail.Previous;
        tail.Next = null;
        Count--;
    }

    /// <summary>
    /// �����, ��������� ��������� ���� �� ������.
    /// </summary>
    /// <param name="node">����, ������� ���� �������.</param>
    private void Remove(Node<T> node)
    {
        if (Count == 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }

        if (node.Previous != null)
        {
            node.Previous.Next = node.Next;
        }
        else
        {
            head = node.Next;
            head.Previous = null;
        }

        if (node.Next != null)
        {
            node.Next.Previous = node.Previous;
        }
        else
        {
            tail = node.Previous;
            tail.Next = null;
        }

        Count--;
    }

    /// <summary>
    /// �����, ��������� �������� �� ��������� ���������� ����, ������� � ����.
    /// </summary>
    /// <param name="startNode">���� �� ��������� ��� ��������.</param>
    private void RemoveWith(Node<T> startNode)
    {
        Node<T> current = startNode;
        T removeData = current.Data;
        while (current != null)
        {
            if (current.Data.Equals(removeData))
            {
                Remove(current);
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// �����, ��������� �������� �� ��������� ���������.
    /// </summary>
    /// <param name="removeData">��������, �������� � ������� ������ ���� �������.</param>
    public void Remove(T removeData)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(removeData))
            {
                Remove(current);
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// �����, ��������� ������������� ��������.
    /// </summary>
    public void RemoveDuplicates()
    {
        if (head == null || Count == 1) return;

        Node<T> current = head;
        while (current != null)
        {
            T data = current.Data;
            Node<T> nextCurrent = current.Next;

            while (nextCurrent != null)
            {
                if (nextCurrent.Data.Equals(data))
                {
                    RemoveWith(current);
                    if (nextCurrent == current.Next)
                        current = current.Next;
                    break;
                }
                nextCurrent = nextCurrent.Next;
            }

            current = current.Next;
        }
    }

    /// <summary>
    /// �����, ����������� ������ ������� � �����.
    /// </summary>
    public void HeadToTail()
    {
        if (head == null || Count == 1) return;

        AddTail(head);
        RemoveHead();
        tail.Next = null;
    }

    /// <summary>
    /// �����, ����������� ��������� ������� � ������.
    /// </summary>
    public void TailToHead()
    {
        if (tail == null || Count == 1) return;

        AddHead(tail);
        RemoveTail();
        head.Previous = null;
    }

    /// <summary>
    /// �����, ��������������� �������� � ������.
    /// </summary>
    public void Reverse()
    {
        Node<T> current = head;
        Node<T> temp;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;

            current = current.Previous;
        }

        temp = head;
        head = tail;
        tail = temp;
    }
    /// <summary>
    /// ������� ���������� ��������� � ������, �� ���������� ��������.
    /// </summary>
    private int CountUntil(T item)
    {
        int count = 0;
        Node<T> currentNode = head;
        while  (currentNode != null)
        {
            if (currentNode.Data.Equals(item))
            {
                return count;
            }
            count++;
            currentNode = currentNode.Next;
        }
        return count;
    }
    /// <summary>
    /// �������� �� ��������������� ������ ����� ������, ������������ � ���������� ��������.
    /// </summary>
    public LinkedList<T> Split (int item)
    {
        LinkedList<T> newList = new();
        if (!IsNumericType(typeof(T)))
        {
            Console.WriteLine("���� ����� ������������ ������ ��� ������ � ��������� ����������.");
            return newList;
        }
        if (head == null) return newList;
        Node<T> currentNode = head; 
        while (currentNode != null)
        {
            if (currentNode.Data.Equals(item))
            {
                newList.head = currentNode;
                newList.tail = tail;
                
                if (currentNode == head)
                {
                    head = null;
                    tail = null;
                    newList.Count = Count;
                    Count = 0;
                }
                else
                {
                    currentNode.Previous.Next = null;
                    tail = currentNode.Previous;
                    currentNode.Previous = null;
                    int previousCount = Count;
                    Count = CountUntil(currentNode.Data);
                    newList.Count = previousCount-Count;
                }
                return newList;
            }
            currentNode = currentNode.Next;
        }
        return newList;
    }
}