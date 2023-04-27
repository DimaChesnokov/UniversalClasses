using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Структура данных "Очередь с приоритетами" (FIFO)
    /// </summary>
    public class UniversalPriorityQueue<T>
    {
        private T inf;                //информация об элементе
        private int priority;
        private UniversalPriorityQueue<T> head, tail, next; //ссылки на начало, конец и следующий элемент очереди
        private int count;

        /// <summary>
        /// Создание пустой очереди с приоритетами
        /// </summary>
        public UniversalPriorityQueue()
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
        /// <param name="priority"> Приоритет данного элемента (не может быть меньше нуля) </param>
        public UniversalPriorityQueue(T key, int priority)
        {
            count++;
            UniversalPriorityQueue<T> pv = new UniversalPriorityQueue<T>();
            pv.inf = key;
            pv.priority = priority;
            head = pv;
            tail = pv;
        }

        /// <summary>
        /// Добавление элемента в конец очереди
        /// </summary>
        /// <param name="key"> Значение нового элемента </param>
        /// <param name="priority"> Приоритет данного элемента (не может быть меньше нуля) </param>
        public void Add(T key, int priority)
        {
            UniversalPriorityQueue<T> pv;
            if (count == 0)
            {
                pv = new UniversalPriorityQueue<T>();
                count++;
                pv.inf = key;
                pv.priority = priority;
                head = pv;
                tail = pv;
            }
            else
            {
                count++;
                pv = new UniversalPriorityQueue<T>();
                pv.inf = key;
                pv.priority = priority;
                FindPlaceOfElement(pv);
            }
        }

        /// <summary>
        /// Вставка элемента в очередь по приоритету
        /// </summary>
        /// <param name="pv"> Вставляемый элемент </param>
        private void FindPlaceOfElement(UniversalPriorityQueue<T> pv)
        {
            if(head.priority < pv.priority)
            {
                pv.next = head;
                head = pv;
                return;
            }

            UniversalPriorityQueue<T> temp = head;
            for (int i = 0; i < count; i++)
            {
                if (temp.next == null)
                    {
                        temp.next = pv;
                        tail = pv;
                        break;
                    }
                if (temp.next.priority >= pv.priority)
                {
                    temp = temp.next;
                }
                else
                {
                    pv.next = temp.next;
                    temp.next = pv;
                    break;
                }
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
                count--;
                T Temp = head.inf;
                head = head.next;
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
