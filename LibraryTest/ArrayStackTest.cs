using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class ArrayStackTest
    {
        [TestMethod] // Тест заполнения стека 
        public void PushTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Push(8);
            data.Push(6);
            data.Push(10);
        }

        [TestMethod] // получение последнего элемента
        public void PopTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Push(8);
            data.Push(6);
            data.Pop();
        }

        [TestMethod] // получение элемента из пустго стека
        public void PopEmptyTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Pop();
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Push(8);
            data.Push(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Push(8);
            data.Push(3);
            data.Push(14s);
            data.GetEnumerator();
        }

        [TestMethod] // IDisposable
        public void DisposeTest()
        {
            int n = 2;
            ArrayStack<object> data = new ArrayStack<object>(n);
            data.Push(6);
            data.Push(10);
            data.Dispose();
        }
    }
}