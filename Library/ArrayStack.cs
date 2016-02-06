using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class ArrayStack<T> : Stack<T>
    {
        private T[] Data;
        public int Capacity { get; private set; }

        public ArrayStack() : this(10) { }

        public ArrayStack(int n)
        {
            Capacity = n;
            Count = 0;
            Data = new T[n];
        }

        public ArrayStack(ArrayStack<T> stack)
        {
            Count = stack.Count;
            Capacity = stack.Capacity;
            Data = new T[Capacity];
            stack.CopyTo(Data, 0);
        }

        public ArrayStack(LinkedStack<T> stack)
        {
            Count = stack.Count;
            Capacity = (Count / 10 + 1) * 10;
            Data = new T[Capacity];
            stack.CopyTo(Data, 0);
        }

        // Добавление элемента
        public override void Push(T info)
        {
            if (Count == Capacity)
            {
                Capacity += 10;
                T[] newdata = new T[Capacity];
                for (int i = 0; i < Count; i++)
                    newdata[i] = Data[i];
                Data = newdata;
            }
            Data[Count++] = info;
        }

        // Очистка стека
        public override void Clear()
        {
            Capacity = 10;
            Count = 0;
            Data = new T[Capacity];
        }

        // Извлекает последний элемент
        public override T Pop()
        {
            return Data[--Count];
        }

        // Клонирование стэка
        public override object Clone()
        {
            return new ArrayStack<T>(this);
        }

        //проверка содержит ли стек элемент
        public override bool Contains(T info)
        {
            return Data.Contains(info);
        }

        // копирование стека в массив
        public override void CopyTo(T[] array, int index)
        {
            for (int i = index; i < index + Count; i++)
                if (i < array.Length)
                    array[i] = Data[i - index];
                else
                    throw new ArgumentOutOfRangeException();
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                    Data = null;
                Disposed = true;
            }
        }

        protected override T this[int index]
        {
            get
            {
                if (index < Count)
                    return Data[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < Count)
                    Data[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}