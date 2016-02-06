using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod] // Тест заполнения списка 
        public void AppendTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(6);
            data.Append(10);
        }

        [TestMethod] // Тест заполнения с использованием Insert
        public void InsertTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(4);
            data.Insert(2, 1);
        }

        [TestMethod] // Добавление элемента в заполненный список
        public void AppendInFullListTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(11);
            data.Append(6);
            data.Append(3);
        }

        [TestMethod] // получение последнего элемента
        public void GetLastItemTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(4);
            data.Append(2);
            data.Get(1);
        }

        [TestMethod] // получение первого элемента
        public void GetFirstItemTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(8);
            data.Append(10);
            data.Get(0);
        }

        [TestMethod] // Поиск существующего элемента
        public void FindItemTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(6);
            data.Append(10);
            data.Find(10);
        }

        [TestMethod] //Поиск не существующего элемента
        public void FindNotExistItemTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(8);
            data.Append(4);
            data.Find(11);
        }

        [TestMethod] // Поиск в пустом списке
        public void FindInEmptyListTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Find(11);
        }

        [TestMethod] // Удаление элемента из списка 
        public void DeleteTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(9);
            data.Append(6);
            data.Delete(9);
        }

        [TestMethod] // Удаление несуществующего элемента 
        public void DeleteNotExistItemTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(8);
            data.Append(6);
            data.Delete(5);
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(6);
            data.Append(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(8);
            data.Append(6);
            data.GetEnumerator();
        }

        [TestMethod] // IDisposable
        public void DisposeTest()
        {
            LinkedList<object> data = new LinkedList<object>();
            data.Append(3);
            data.Append(14);
            data.Dispose();
        }
    }
}