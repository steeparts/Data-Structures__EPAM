using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public abstract class List<T> : IEnumerable<T>, IDisposable, ICloneable
    {
        public int Count 
        { 
            get; 
            protected set; 
        }

        public bool IsReadOnly { get; set; }

        protected bool Disposed = false;

        // добавление нового элемента в список
        public abstract void Append(T info);

        // вставка элемента в позицию index
        public abstract void Insert(T info, int index);

        // проверка вхождения элемента в список
        public abstract bool Contains(T info);

        // копирует список в массив
        public abstract void CopyTo(T[] array, int index);

        // возвращает индекс элемента
        public abstract int Find(T info);

        // возвращает элемент по индексу
        public abstract T Get(int index);

        // удаление элемента из списка
        public abstract bool Delete(T info);

        // очищение списка
        public abstract void Clear();

        // клонирование списка
        public abstract object Clone();

        // получение перечислителя
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
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

        // перегрузка индексатора
        public abstract T this[int id] { get; set; }

        protected abstract void Dispose(bool disposing);

        ~List()
        {
            Dispose(false);
        }
    }
}