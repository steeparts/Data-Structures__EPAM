using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    class ListEnumerator<T> : IEnumerator<T>
    {
        private List<T> Collection;
        private int CurrentIndex;
        private T CurrentElem;

        public ListEnumerator(List<T> l)
        {
            Collection = l;
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
            if (++CurrentIndex >= Collection.Count)
                return false;
            else
                CurrentElem = Collection[CurrentIndex];
            return true;
        }

        public void Reset() { CurrentIndex = -1; }
    }
}