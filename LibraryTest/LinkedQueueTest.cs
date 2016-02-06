using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class LinkedQueueTest
    {
        [TestMethod] // Тест заполнения очереди 
        public void AddTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Add(8);
            data.Add(6);
            data.Add(10);
        }

        [TestMethod] // получение первого элемента
        public void TakeTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Add(8);
            data.Add(6);
            data.Take();
        }

        [TestMethod] // получение элемента из пустой очереди
        public void TakeEmptyTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Take();
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Add(8);
            data.Add(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Add(8);
            data.Add(13);
            data.GetEnumerator();
        }

        [TestMethod] //IDisposable
        public void DisposeTest()
        {
            LinkedQueue<object> data = new LinkedQueue<object>();
            data.Add(10);
            data.Add(3);
            data.Dispose();
        }
    }
}