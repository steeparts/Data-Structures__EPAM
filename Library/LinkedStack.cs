using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class LinkedStack<T> : Stack<T>
    {
        private Node<T> Head;
        private Node<T> Tail;

        public LinkedStack()
        {
            Head = null;
            Tail = null;
        }

        public LinkedStack(LinkedStack<T> stack)
        {
            Head = null;
            Tail = null;
            Node<T> data = stack.Head;
            Count = stack.Count;
            while (data != null)
            {
                Push(data.info);
                data = data.next;
            }
        }

        // добавление элемента
        public override void Push(T info)
        {
            if (Head == null)
            {
                Head = new Node<T>(info);
                Tail = Head;
                Count++;
            }
            else
            {
                Tail.next = new Node<T>(info);
                Tail.next.prev = Tail;
                Tail = Tail.next;
                Count++;
            }
        }

        // вывод последнего элемента
        public override T Pop()
        {
            T result = Tail.info;
            Tail = Tail.prev;
            Tail.next = null;
            Count--;
            return result;
        }

        // очистка стека
        public override void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        // клонирование стека
        public override object Clone()
        {
            return new LinkedStack<T>(this);
        }

        // проверка содержит ли стек элемент
        public override bool Contains(T info)
        {
            Node<T> data = Tail;
            while (data != null || !data.info.Equals(info))
                data = data.prev;
            if (data == null)
                return false;
            else
                return true;
        }

        //копирование стека в массив
        public override void CopyTo(T[] array, int id)
        {
            Node<T> data = Tail;
            while (data.prev != null)
                data = data.prev;
            for (int i = id; i < id + Count; i++)
                if (i < array.Length)
                {
                    array[i] = data.info;
                    data = data.next;
                }
                else
                    throw new ArgumentOutOfRangeException();
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Tail = null;
                    Head = null;
                }
                Disposed = true;
            }
        }

        protected override T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    Node<T> data = Tail;
                    while (data.prev != null)
                        data = data.prev;
                    for (int i = 0; i < index; i++)
                        data = data.next;
                    return data.info;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < Count)
                {
                    Node<T> data = Tail;
                    while (data.prev != null)
                        data = data.prev;
                    for (int i = 0; i < index; i++)
                        data = data.next;
                    data.info = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}