using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSChallenge1
{
    class Program
    {
        public class List<T>
        {
            public class Node<T>
            {
                private T value;
                private Node<T> next;
                public Node(T val)
                {
                    value = val;
                    next = null;
                }
                public void SetNext(T val)
                {
                    next = new Node<T>(val);
                }
                public void SetNext(Node<T> newNext)
                {
                    next = newNext;
                }
                public Node<T> GetNext()
                {
                    return next;
                }
                public T GetValue()
                {
                    return value;
                }
            }
            private int size;
            private Node<T> head;
            private Node<T> tail;
            public List()
            {
                size = 0;
                head = null;
            }
            public T At(int index)
            {
                Node<T> cur = head;
                if (!(index < 0 || index >= size))
                {
                    for (int i = 0; i < index; i++)
                    {
                        cur = cur.GetNext();
                    }
                }
                return cur.GetValue();
            }
            public void Insert(T val)
            {
                if (size == 0)
                {
                    head = tail = new Node<T>(val);
                }
                else
                {
                    tail.SetNext(val);
                    tail = tail.GetNext();
                }
                size++;
            }
            public void Insert(int index, T val)
            {
                if (size < index || index < 0)
                {
                    return;
                }
                else if (index == 0)
                {
                    Node<T> tmp = new Node<T>(val);
                    tmp.SetNext(head);
                    head = tmp;
                }
                else if (index == size - 1)
                {
                    Insert(val);
                }
                else
                {
                    Node<T> cur = head;
                    int i = 0;
                    while (i < index)
                    {
                        cur = cur.GetNext();
                        i++;
                    }
                    Node<T> tmp = cur.GetNext();
                    cur.SetNext(val);
                    cur.GetNext().SetNext(tmp);
                }
                size++;
            }
            public void Delete(int index)
            {
                if (size == 0 || index < 0 || index >= size)
                {
                    return;
                }
                else if (index == 0)
                {
                    head = head.GetNext();
                }
                else
                {
                    Node<T> cur = head;
                    int i = 0;
                    while (i < index)
                    {
                        cur = cur.GetNext();
                        i++;
                    }
                    cur.SetNext(cur.GetNext().GetNext());
                }
                size--;
            }
            public void Clear()
            {
                Node<T> cur = head;
                Node<T> tmp;
                for (int i = 0; i < size; i++, cur = tmp)
                {
                    tmp = cur.GetNext();
                    cur = null;
                }
            }
            public int Find(T val)
            {
                Node<T> cur = head;
                for (int i = 0; i < size; i++)
                {
                    if (cur.GetValue().Equals(val))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            for (int i = 0; i < 4; i++)
            {
                System.Console.WriteLine(list.At(i));
            }
        }
    }
}
