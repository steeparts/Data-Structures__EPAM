using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    // Список на основе массива
	public class ArrayList<T> : List<T>
	{
		private T[] Data;
		public int Capacity { get; private set; } // размерность

		// конструторы
		public ArrayList() : this(10) { }

		public ArrayList(List<T> list)
		{
			Count = list.Count;

			ArrayList<T> l = list as ArrayList<T>;
			if (l != null)
				Capacity = l.Capacity;
			else
				Capacity = ((Count / 10) + 1) * 10;

			Data = new T[Capacity];
			for (int i = 0; i < Count; i++)
				Data[i] = list[i];
		}

        public ArrayList(int capacity)
		{
			if (capacity > 0)
			{
				Count = 0;
				Capacity = capacity;
				Data = new T[Capacity];
			}
			else
				throw new ArgumentOutOfRangeException("Capacity", "Вместимость списка должна быть натуральным числом.");
		}

		// добавление нового элемнта
		public override void Append(T info)
		{
			if (Count == Capacity)
			{
                // увеличиваем размерность, если достигли предела
				Capacity += 10;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Count; i++)
					newdata[i] = Data[i];
				newdata[Count++] = info;
				Data = newdata;
				return;
			}
			else
			{
				Data[Count++] = info;
			}
		}

		// вставка элемента в позицию index
		public override void Insert(T info, int index)
		{
            if (index >= Count)
				// если индекс больше количества элементов, то добавляется новый
				Append(info);
			else if (Count != Capacity)
			{
				int i;
                for (i = Count; i > index; i--)
					Data[i] = Data[i - 1];
				Data[i] = info;
				Count++;
			}
			else
			{
				// увеличение размерности при необходимости
				Capacity += 10;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Count; i++)
					newdata[i] = Data[i];
				Data = newdata;
                Insert(info, index);
			}
			return;
		}

		// проверка вхождения элемента в список
		public override bool Contains(T info)
		{
			return Data.Contains(info);
		}

		// копирование списка в массив
        public override void CopyTo(T[] array, int index)
		{
            for (int i = index; i < index + Count; i++)
				if (i < array.Length)
                    array[i] = Data[i - index];
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}
		
		// поиск элемента
		public override int Find(T info)
		{
			int i = 0;
			while (i < Count)
			{
				if (Data[i].Equals(info)) // если элемент был найден,
					return i; // то вернуть его индекс
				i++;
			}
			// возвращает -1 в случае неуспеха
			return -1;
		}

		// возвращает элемент по индексу
		public override T Get(int index)
		{
            if (index < Count)
				return Data[index];
			else
				throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}
		
		// удаления элемента
		public override bool Delete(T info)
		{
			int id = Find(info);
			if (id != -1)
			{
				for (int i = id; i < Count - 1; i++)
					Data[i] = Data[i + 1];
				Count--;
				return true;
			}
			else
				return false;
		}

		// очищение списка
		public override void Clear()
		{
			Capacity = 10;
			Count = 0;
			Data = new T[Capacity];
		}

		// клонирование списка
		public override object Clone()
		{
            return new ArrayList<T>(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (!Disposed)
			{
				if (disposing)
					Data = null;
				Disposed = true;
			}
		}

		// перегрузка индексатора
        public override T this[int index]
		{
			get
			{
                if (index < Count)
                    return Data[index];
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
			set
			{
                if (index < Count)
                    Data[index] = value;
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
		}
	}
}