using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Класс для представления элемента в списке
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Поля
        /// </summary>
        public T value;
        public Node<T> next;
        public Node<T> prev;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Node(T val)
        {
            this.value = val;
            next = null;
            prev = null;
        }
    }

    /// <summary>
    /// Структура данных "Список"
    /// </summary>
    public class UniversalList<T>
    {
        Node<T> head;    //ссылка на первый элемент
        Node<T> tail;    //ссылка на последний элемент
        int count = 0;   //количество элементов в списке

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public UniversalList() { }

        /// <summary>
        /// Конструктор для создания списка с первым элементом
        /// </summary>
        public UniversalList(T val)
        {
            Node<T> newNode = new Node<T>(val);
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
        /// Возвращает кол-во элементов
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Чтение элемента по индексу в листе
        /// </summary>
        public T Get(int index)
        {
            if (IsEmpty())
                return default(T);

            Node<T> temp = GetElement(index);

            return temp.value;
        }

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        public void AddToTheEnd(T val)
        {
            Node<T> pv = new Node<T>(val);
            if (head == null)
            {
                head = pv;
                tail = pv;
            }
            else
            {
                tail.next = pv;
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
            Node<T> pv = new Node<T>(val);
            if (head == null)
            {
                head = pv;
                tail = pv;
            }
            else
            {
                pv.next = head;
                head.prev = pv;
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


            Node<T> temp = GetElement(index);

            if (index == 0)
            {
                T tmp = head.value;
                head = head.next;
                head.prev = null;
                count--;
                return tmp;
            }

            if (index == count - 1)
            {
                T tmp = tail.value;
                tail = tail.prev;
                tail.next = null;
                count--;
                return tmp;
            }

            temp.next.prev = temp.prev;
            temp.prev.next = temp.next;
            count--;
            return temp.value;


            //return default(T);
        }

        /// <summary>
        /// Копировать часть листа по индексам начала и конца
        /// </summary>
        public UniversalList<T> CopyPartOfList(int start, int end)
        {
            if ((end < start) || (end > count) || (start < 0)) return null;

            UniversalList<T> slicedList = new UniversalList<T>();

            Node<T> cur = GetElement(start);
            while (start < end + 1 && cur != null)
            {
                start++;
                slicedList.AddToTheEnd(cur.value);
                cur = cur.next;
            }

            return slicedList;
        }

        /// <summary>
        /// Соеденить 2 листа
        /// </summary>
        public UniversalList<T> MergeLists(UniversalList<T> list)
        {
            list.head.prev = tail;
            tail.next = list.head;
            tail = list.tail;
            count = count + list.count;
            return this;
        }

        /// <summary>
        /// Соеденить 2 листа, создав новый лист
        /// </summary>
        public UniversalList<T> ConcatCopy(UniversalList<T> list)
        {
            UniversalList<T> newList = new UniversalList<T>();

            Node<T> cur = head;
            while (cur != null)
            {
                newList.AddToTheEnd(cur.value);
                cur = cur.next;
            }

            cur = list.head;
            while (cur != null)
            {
                newList.AddToTheEnd(cur.value);
                cur = cur.next;
            }

            return newList;
        }

        /// <summary>
        /// Вернуть элемент из списка по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetElement(int index)
        {
            if (index > count || index < 0)
                return null;

            Node<T> temp = head;
            for (int i = 0; i < count; i++)
                if (i == index)
                    return temp;
                else
                    temp = temp.next;

            return null;
        }

        /// <summary>
        /// Добавить элемент в определённый индекс
        /// </summary>
        public UniversalList<T> Insert(int index, T val)
        {
            Node<T> newNode = new Node<T>(val);
            if (index > count)
            {
                AddToTheEnd(val);
            }
            else if (index <= 0)
            {
                AddToTheTop(val);
            }
            else
            {
                if (index > count)
                    AddToTheTop(val);
                Node<T> leader = GetElement(index-1);
                Node<T> holdingPointer = leader.next;
                leader.next = newNode;
                newNode.next = holdingPointer;
                newNode.prev = leader;
            }
            count++;

            return this;
        }
    }
}
