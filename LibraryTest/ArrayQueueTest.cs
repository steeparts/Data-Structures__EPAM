using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class ArrayQueueTest
    {
        [TestMethod] // Тест заполнения очереди 
        public void AddTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Add(8);
            data.Add(6);
        }

        [TestMethod] // получение первого элемента
        public void TakeTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Add(8);
            data.Add(10);
            data.Take();
        }

        [TestMethod] // получение элемента из пустой очереди
        public void TakeEmptyTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Take();
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Add(8);
            data.Add(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Add(8);
            data.Add(10);
            data.GetEnumerator();
        }

        [TestMethod] // IDisposable
        public void DisposeTest()
        {
            int n = 2;
            ArrayQueue<object> data = new ArrayQueue<object>(n);
            data.Add(6);
            data.Add(15);
            data.Dispose();
        }
    }
}