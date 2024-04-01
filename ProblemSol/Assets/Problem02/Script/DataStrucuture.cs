using System;
using UnityEngine;

namespace DataStrucuture
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        public LinkedListNode<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }

    public class Queue<T>
    {
        private LinkedList<T> list;

        public Queue()
        {
            list = new LinkedList<T>();
        }

        public void Enqueue(T data)
        {
            list.Add(data);
        }

        public T Dequeue()
        {
            if (list.head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T data = list.head.Data;
            list.head = list.head.Next;
            return data;
        }

    }

    
    public class Stack<T>
    {
        private LinkedList<T> list; 

        public Stack() 
        {
            list = new LinkedList<T>();
        }
        public void Push(T data)
        { 
            list.Add(data);
        }
        public T Pop() 
        { 
              if (list.head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            LinkedListNode<T> current = list.head;
            LinkedListNode<T> prev = null;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            if (prev != null)
            {
                prev.Next = null;
            }
            else
            {
                list.head = null;
            }

            return current.Data;
        }
    }
    


}
