using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class LinkedStackTest
    {
        [TestMethod] // Тест заполнения стека 
        public void PushTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Push(8);
            data.Push(10);
        }

        [TestMethod] // получение последнего элемента
        public void PopTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Push(8);
            data.Push(6);
            data.Pop();
        }

        [TestMethod] // получение элемента из пустго стека
        public void PopEmptyTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Pop();
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Push(8);
            data.Push(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Push(8);
            data.Push(10);
            data.GetEnumerator();
        }

        [TestMethod] //IDisposable
        public void DisposeTest()
        {
            LinkedStack<object> data = new LinkedStack<object>();
            data.Push(8);
            data.Push(14);
            data.Dispose();
        }
    }
}