using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class ArrayQueue<T> : Queue<T>
    {
        private T[] data;       // массив данных
        public int Capacity { get; private set; }  // ёмкость массива
        private int head;       // начало очереди
        private int tail;       // конец очереди
        private bool full;      // флаг, отображающий заполненность очереди


        // конструкторы
        public ArrayQueue() : this(10) { }

        public ArrayQueue(int n)
        {
            Count++;
            Capacity = n;
            head = 0;
            tail = 0;
            full = false;
            data = new T[n];
        }

        public ArrayQueue(ArrayQueue<T> queue)
        {
            Count = queue.Count;
            Capacity = queue.Capacity;
            data = new T[Capacity];
            queue.CopyTo(data, 0);
        }

        public ArrayQueue(LinkedQueue<T> queue)
        {
            Count = queue.Count;
            Capacity = ((Count / 10) + 1) * 10;
            data = new T[Capacity];
            queue.CopyTo(data, 0);
        }


        //добавление элемента в очередь
        public override void Add(T info)
        {
            if (full)
            {
                // уведичение ёмкости при необходимости
                Capacity += 10;
                T[] newdata = new T[Capacity];
                newdata[0] = data[head];
                head = (head + 1) % (Capacity - 10);
                int i = 1;
                while (head != tail)
                {
                    newdata[i] = data[head];
                    head = (head + 1) % (Capacity - 10);
                    i++;
                }
                head = 0;
                newdata[Count++] = info;
                tail = Count;

            }
            else
            {
                data[tail] = info;
                tail = (tail + 1) % Capacity;
                if (head == tail) full = true;
            }
        }

        // удаление всех элементов очереди
        public override void Clear()
        {
            Capacity = 10;
            Count = 0;
            head = 0; tail = 0;
            full = false;
            data = new T[Capacity];
        }

        public override object Clone()
        {
            return new ArrayQueue<T>(this);
        }

        // проверка вхождения элемента в очередь
        public override bool Contains(T info)
        {
            return data.Contains(info);
        }

        // копирование очереди в массив
        public override void CopyTo(T[] array, int index)
        {
            int p = head;
            for (int i = index; i < index + Count; i++)
                if (i < array.Length)
                {
                    array[i] = data[p];
                    p = (p + 1) % Capacity;
                }
                else
                    throw new ArgumentOutOfRangeException();
        }

        // возвращает первый элемент и удаляет его
        public override T Take()
        {
            if (head == tail && !full)
                throw new InvalidOperationException();
            else
            {
                T result = data[head];
                head = (head + 1) % Capacity;
                return result;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                    data = null;
                Disposed = true;
            }
        }

        protected override T this[int index]
        {
            get
            {
                if (index < Count)
                    return data[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < Count)
                    data[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}