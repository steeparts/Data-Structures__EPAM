using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class LinkedQueue<T> : Queue<T>
    {
        private Node<T> Head;   // начало
        private Node<T> Tail;   // конец

        // конструкторы
        public LinkedQueue()
        {
            Head = null;
            Tail = null;
        }

        public LinkedQueue(LinkedQueue<T> newdata)
        {
            Head = null;
            Tail = null;
            Node<T> data = newdata.Head;
            Count = newdata.Count;
            while (data != null)
            {
                Add(data.info);
                data = data.next;
            }
        }

        public LinkedQueue(ArrayQueue<T> newdata)
        {
            Head = null;
            Tail = null;
            Count = newdata.Count;
            T[] data = new T[Count];
            newdata.CopyTo(data, 0);
            for (int i = 0; i < Count; i++)
                Add(data[i]);
        }

        // добавление элемента в очередь
        public override void Add(T info)
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

        // удаление всех элементов
        public override void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public override object Clone()
        {
            return new LinkedQueue<T>(this);
        }

        // проверка вхождения элемента в очередь
        public override bool Contains(T info)
        {
            Node<T> data = Head;
            while (data != Tail || !data.info.Equals(info))
                data = data.next;
            if (data == Tail)
                return false;
            else
                return true;
        }

        // копирование очереди в массив
        public override void CopyTo(T[] array, int id)
        {
            Node<T> data = Head;
            for (int i = id; i < id + Count; i++)
                if (i < array.Length)
                {
                    array[i] = data.info;
                    data = data.next;
                }
                else
                    throw new ArgumentOutOfRangeException();
        }

        // возвращает первый элемент и удаляет его
        public override T Take()
        {
            if (Head == null)
                throw new InvalidOperationException();
            else
            {
                T result = Head.info;
                if (Head.next == null)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head.next.prev = null;
                    Head = Head.next;
                }
                Count--;
                return result;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Head = null;
                    Tail = null;
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
                    Node<T> data = Head;
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
                    Node<T> data = Head;
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