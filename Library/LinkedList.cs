using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class LinkedList<T> : List<T>
    {
        private Node<T> head; // голова списка

        // конструкторы
        public LinkedList()
        {
            head = null;
            Count = 0;
        }

        public LinkedList(List<T> newdata)
        {
            Count = newdata.Count;
            head = null;
            if (Count != 0)
            {
                head = new Node<T>(newdata[0]);
                Node<T> data = head;
                for (int i = 1; i < Count; i++)
                {
                    data.next = new Node<T>(newdata[i]);
                    data.next.prev = data;
                    data = data.next;
                }
            }
        }

        // добавление нового элемента
        public override void Append(T info)
        {
            if (head == null)
            {
                head = new Node<T>(info);
                Count = 1;
            }
            else
            {
                Node<T> data = head;
                while (data.next != null)
                    data = data.next;
                data.next = new Node<T>(info);
                data.next.prev = data;
                Count++;
            }
        }

        // вставка элемента в позицию index
        public override void Insert(T info, int index)
        {
            index--;
            if (head == null)
            {
                head = new Node<T>(info);
                Count++;
            }
            else
            {
                int i = 0;
                Node<T> data = head;
                while (data.next != null && i != index)
                {
                    data = data.next;
                    i++;
                }
                if (i == index)
                {
                    Node<T> p = new Node<T>(info);
                    p.prev = data;
                    p.next = data.next;
                    data.next.prev = p;
                    data.next = p;
                }
                else
                {
                    data.next = new Node<T>(info);
                    data.next.prev = data;
                }
                Count++;
            }
        }

        // проверка вхождения элемента в список
        public override bool Contains(T info)
        {
            if (head == null)
                return false;
            else
            {
                Node<T> p = head;
                while (p != null && !info.Equals(p.info))
                    p = p.next;
                if (p == null)
                    return false;
                else
                    return true;
            }
        }

        // копирование списка в массив
        public override void CopyTo(T[] array, int id)
        {
            Node<T> p = head;
            for (int i = id; i < id + Count; i++)
                if (i < array.Length)
                {
                    array[i] = p.info;
                    p = p.next;
                }
                else
                    throw new IndexOutOfRangeException("Индекс вне диапазона.");
        }

        // поиск элемента
        public override int Find(T info)
        {
            if (head == null)
                return -1;
            else
            {
                int i = 0;
                Node<T> data = head;
                while (data != null && !data.info.Equals(info))
                {
                    data = data.next;
                    i++;
                }
                if (data == null) // если поиск не дал результатов,
                    // то вернуть -1
                    return -1;
                else // если элемент был найден,                    
                    return i; // то вернуть его индекс
            }
        }

        // возвращает элемент по индексу
        public override T Get(int index)
        {
            if (index < Count)
                return this[index];
            else
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
        }

        // удаляет элемент по индексу
        public override bool Delete(T info)
        {
            if (head == null)
                return false;
            else
            {
                Node<T> data = head;
                while (data.next != null && !data.next.info.Equals(info))
                    data = data.next;
                if (data.next == null)
                    return false;
                else
                {
                    data.next.next.prev = data;
                    data.next = data.next.next;
                    Count--;
                    return true;
                }
            }
        }

        // очищение списка
        public override void Clear()
        {
            Count = 0;
            head = null;
        }

        // клонирование списка
        public override object Clone()
        {
            return new LinkedList<T>(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                    head = null;
                Disposed = true;
            }
        }

        // перегрузка индексатора
        public override T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    Node<T> data = head;
                    for (int i = 0; i < index; i++)
                        data = data.next;
                    return data.info;
                }
                else
                    throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }

            set
            {
                if (index < Count)
                {
                    Node<T> data = head;
                    for (int i = 0; i < index; i++)
                        data = data.next;
                    data.info = value;
                }
                else
                    throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }
        }
    }
}