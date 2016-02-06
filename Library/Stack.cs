using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public abstract class Stack<T> : IEnumerable<T>, ICloneable, IDisposable
    {
        public int Count { get; protected set; }
        public bool IsReadOnly { get; set; }
        protected bool Disposed = false;

        // Добавление в стек
        public abstract void Push(T info);

        // Очистка стека
        public abstract void Clear();

        // Клонирование стэка
        public abstract object Clone();

        // Проверка стека на наличие элемента
        public abstract bool Contains(T info);

        // Копирование стека в массив
        public abstract void CopyTo(T[] array, int index);

        // Извлекает последний элемент и удаляет его
        public abstract T Pop();

        // Получение перечислителя
        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);

        ~Stack()
        {
            Dispose(false);
        }

        // Перегрузка индексатора
        protected abstract T this[int index] { get; set; }
    }
}