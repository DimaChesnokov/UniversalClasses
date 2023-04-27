using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Структура данных "Кольцевая очередь" (FIFO)
    /// </summary>
    public class UniversalCircularQueue<T>
    {
        private T inf;                //информация об элементе
        private UniversalCircularQueue<T> head, tail, next; //ссылки на начало, конец и следующий элемент очереди
        private int count;

        /// <summary>
        /// Создание пустой очереди
        /// </summary>
        public UniversalCircularQueue()
        {
            count = 0;
            next = null;
            head = null;
            tail = null;
        }

        /// <summary>
        /// Создание очереди с элементом хранящим в себе значение key
        /// </summary>
        /// <param name="key"> Значение нового элемента </param>
        public UniversalCircularQueue(T key)
        {
            count++;
            UniversalCircularQueue<T> pv = new UniversalCircularQueue<T>();
            pv.inf = key;
            head = pv;
            tail = pv;
        }

        /// <summary>
        /// Добавление элемента в конец очереди
        /// </summary>
        /// <param name="key"> Значение нового элемента </param>
        public void Add(T key)
        {
            UniversalCircularQueue<T> pv = new UniversalCircularQueue<T>();
            if (count == 0)
            {
                count++;
                pv.inf = key;
                head = pv;
                tail = pv;
            }
            else
            {
                count++;
                pv.inf = key;
                tail.next = pv;
                tail = pv;
            }
        }

        /// <summary>
        /// Удаление с возвращением первого элемента очереди
        /// </summary>
        /// <returns> Первый элемент очереди </returns>
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T Temp = head.inf;
                tail.next = head;
                head = head.next;
                tail = tail.next;
                return Temp;
            }
            else
                return default;
        }

        /// <summary>
        /// Просмотр первого элемента в очереди
        /// </summary>
        /// <returns> Первый элемент очереди </returns>
        public T PeekFirst()
        {
            if (!IsEmpty())
                return head.inf;
            else
                return default;
        }

        /// <summary>
        /// Просмотр последнего элемента очереди
        /// </summary>
        /// <returns> Последний элемент очереди </returns>
        public T PeekLast()
        {
            if (!IsEmpty())
                return tail.inf;
            else
                return default;
        }

        /// <summary>
        /// Проверка на пустоту очереди
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Количество элементов в очереди
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
