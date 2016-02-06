using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class ArrayListTest
    {
        [TestMethod] // Тест заполнения списка 
        public void AppendTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(4);
            data.Append(5);
        }

        [TestMethod] // Тест заполнения с использованием Insert
        public void InsertTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(8);
            data.Insert(4, 1);
        }

        [TestMethod] // Добавление элемента в заполненный список
        public void AppendInFullListTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(3);
            data.Append(16);
            data.Append(5);
        }

        [TestMethod] // Получение последнего элемента
        public void GetLastItemTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(8);
            data.Append(10);
            data.Get(1);
        }

        [TestMethod] // Получение первого элемента
        public void GetFirstItemTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(9);
            data.Append(5);
            data.Get(0);
        }

        [TestMethod] // Поиск существующего элемента
        public void FindItemTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(6);
            data.Append(11);
            data.Find(11);
        }

        [TestMethod] // Поиск несуществующего элемента
        public void FindNotExistItemTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(8);
            data.Append(10);
            data.Find(3);
        }

        [TestMethod] // Поиск в пустом списке
        public void FindInEmptyListTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Find(4);
        }

        [TestMethod] // Удаление элемента из списка 
        public void DeleteTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(12);
            data.Append(7);
            data.Delete(7);
        }

        [TestMethod] // Удаление несуществующего элемента 
        public void DeleteNotExistItemTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(7);
            data.Append(6);
            data.Delete(5);
        }

        [TestMethod] // ICloneable
        public void CloneTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(3);
            data.Append(10);
            data.Clone();
        }

        [TestMethod] // IEnumerable
        public void EnumerableTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(18);
            data.Append(1);
            data.GetEnumerator();
        }

        [TestMethod] // IDisposable
        public void DisposeTest()
        {
            int n = 2;
            ArrayList<object> data = new ArrayList<object>(n);
            data.Append(16);
            data.Append(2);
            data.Dispose();
        }
    }
}