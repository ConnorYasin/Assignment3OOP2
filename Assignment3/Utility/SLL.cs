using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class SLL : ILinkedListADT
    {
        public Node head;
        public Node tail;
        public int size;
        public SLL()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
        }
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            size++;
        }
        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == size)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                size++;
            }
        }
        public void RemoveFirst() 
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot remove from an empty list");
            }
            head = head.Next;
            size--;
            if (IsEmpty())
            {
                tail = null;
            }
        }
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot remove from an empty list");
            }
            if (size == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            size--;
        }
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }
        public int Count()
        {
            return size;
        }
        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                size--;
                if (current.Next == null)
                {
                    tail = current;
                }
            }
        }
        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1; 
        }
        public User GetFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot get from an empty list");
            }
            return head.Data;
        }
        public User GetLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Cannot get from an empty list");
            }
            return tail.Data;
        }
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public void SortListByName()
        {
            if (head == null || head.Next == null)
            {
                return;
            }
            bool swapped;
            do
            {
                swapped = false;
                Node current = head;

                while (current.Next != null)
                {
                    if (string.Compare(current.Data.Name, current.Next.Data.Name, StringComparison.Ordinal) > 0)
                    {
                        User temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;

                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }


    }

}
