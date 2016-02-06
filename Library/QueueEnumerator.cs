using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    class QueueEnumerator<T> : IEnumerator<T>
    {
        private T[] Collection;
        private int CurrentIndex;
        private T CurrentElem;

        public QueueEnumerator(Queue<T> q)
        {
            q.CopyTo(Collection, 0);
            CurrentIndex = -1;
            CurrentElem = default(T);
        }

        public T Current
        {
            get { return CurrentElem; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        void IDisposable.Dispose() { }

        public bool MoveNext()
        {
            if (++CurrentIndex >= Collection.Length)
                return false;
            else
                CurrentElem = Collection[CurrentIndex];
            return true;
        }

        public void Reset() { CurrentIndex = -1; }

        bool IEnumerator.MoveNext() { throw new NotImplementedException(); }

        void IEnumerator.Reset() { throw new NotImplementedException(); }
    }
}