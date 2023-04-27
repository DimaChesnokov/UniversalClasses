using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Класс представляющий собой универсальный элемент списка
    /// </summary>
    /// <typeparam name="T"> Тип данных элемента </typeparam>
    public class Element<T>
    {
        public T value;                 //значение элемента
        public Element<T> prev;//ссылка на предыдущий элемент

        /// <summary>
        /// Конструктор элемента с введённым значением
        /// </summary>
        /// <param name="val"> значение элемента </param>
        public Element(T val)
        {
            this.value = val;
            prev = null;
        }
    }

    /// <summary>
    /// Класс "Двусвязный список"
    /// </summary>
    /// <typeparam name="T"> тип данных хранящихся в этом списке </typeparam>
    public class UniversalUnidirectionalList<T>
    {
        /// <summary>
        /// Ссылка на первый элемент списка
        /// </summary>
        Element<T> head;
        /// <summary>
        /// Ссылка на последний элемент списка
        /// </summary>
        Element<T> tail;
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        int count;

        public UniversalUnidirectionalList() { }

        public UniversalUnidirectionalList(T val)
        {
            Element<T> newNode = new Element<T>(val);
            head = newNode;
            tail = newNode;
        }

        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Вернуть элемент из списка по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Element<T> GetElement(int index)
        {
            if (index > count || index < 0)
                return null;

            Element<T> temp = head;
            for (int i = 0; i < count; i++)
                if (i == index)
                    return temp;
                else
                    temp = temp.prev;

            return null;
        }

        /// <summary>
        /// Чтение элемента по индексу в листе
        /// </summary>
        public T Get(int index)
        {
            if (IsEmpty())
                return default(T);

            Element<T> temp = GetElement(index);

            return temp.value;
        }

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        public void AddToTheEnd(T val)
        {
            Element<T> pv = new Element<T>(val);
            if (head == null)
            {
                head = pv;
                tail = pv;
            }
            else
            {
                tail.prev = pv;
                pv.prev = tail;
                tail = pv;
            }
            count++;
        }

        /// <summary>
        /// Добавить элемент в начало списка
        /// </summary>
        public void AddToTheTop(T val)
        {
            Element<T> pv = new Element<T>(val);
            if (head == null)
            {
                head = pv;
                tail = pv;
            }
            else
            {
                pv.prev = head;
                head = pv;
            }
            count++;
        }

        /// <summary>
        /// Удаление элемента из листа по индексу
        /// </summary>
        public T RemoveByIndex(int index)
        {
            if (IsEmpty())
                return default(T);

            Element<T> temp = GetElement(index);

            if (index == 0)
            {
                T tempvalue = head.value;
                head = head.prev;
                count--;
                return tempvalue;
            }

            Element<T> tempnext = GetElement(index - 1);

            T tmp = temp.value;
            tempnext.prev = temp.prev;
            count--;
            return tmp;
        }

        /// <summary>
        /// Копировать часть листа по индексам начала и конца
        /// </summary>
        public UniversalUnidirectionalList<T> CopyPartOfList(int start, int end)
        {
            if ((end < start) || (end > count) || (start < 0)) return null;

            UniversalUnidirectionalList<T> slicedList = new UniversalUnidirectionalList<T>();

            Element<T> cur = GetElement(start);
            while (start < end + 1 && cur != null)
            {
                start++;
                slicedList.AddToTheEnd(cur.value);
                cur = cur.prev;
            }

            return slicedList;
        }

        /// <summary>
        /// Соеденить 2 листа
        /// </summary>
        public UniversalUnidirectionalList<T> MergeLists(UniversalUnidirectionalList<T> list)
        {
            tail.prev = list.head;
            tail = list.tail;
            count = count + list.count;
            return this;
        }

        /// <summary>
        /// Соеденить 2 листа, создав новый лист
        /// </summary>
        public UniversalUnidirectionalList<T> ConcatCopy(UniversalUnidirectionalList<T> list)
        {
            UniversalUnidirectionalList<T> newList = new UniversalUnidirectionalList<T>();

            Element<T> cur = head;
            while (cur != null)
            {
                newList.AddToTheEnd(cur.value);
                cur = cur.prev;
            }

            cur = list.head;
            while (cur != null)
            {
                newList.AddToTheEnd(cur.value);
                cur = cur.prev;
            }

            return newList;
        }

        public int Count
        {
            get { return count; }
        }
    }
}
