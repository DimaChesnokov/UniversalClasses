using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Структура данных "Дек" (FLIFLO)
    /// </summary>
    public class UniversalDeque<T>
    {
        T inf;    //переменная хранящая в себе значение элемента дека
        int count;  //количество элементов в деке
        UniversalDeque<T> left, right, l, r;  //ссылки на самый левый и самый правый элементы массива, а так же ссылка на элемент слева и элемент справа

        /// <summary>
        /// Создаёт пустой дек
        /// </summary>
        public UniversalDeque()
        {
            inf = default;
            count = 0;
            l = null;
            r = null;
        }

        /// <summary>
        /// Создание дека с первым указанным элементом
        /// </summary>
        /// <param name="key"> Значение первого элемента </param>
        public UniversalDeque(T key)
        {
            UniversalDeque<T> pv = new UniversalDeque<T>();
            pv.inf = key;
            left = pv;
            right = pv;
            count++;
        }

        /// <summary>
        /// Добавление нового элемента слева
        /// </summary>
        /// <param name="key"> Значение нового элемента </param>
        public void AddLeft(T key)
        {
            UniversalDeque<T> pv = new UniversalDeque<T>(); //создание нового элемента
            pv.inf = key;
            if (count == 0)
            {
                left = pv;
                right = pv;
                count++;
            }
            else
            {
                left.l = pv;
                pv.r = left;
                left = pv;
                count++;
            }
        }

        /// <summary>
        /// Добавление нового элемента справа
        /// </summary>
        /// <param name="key"> Значение нового элемента </param>
        public void AddRight(T key)
        {
            UniversalDeque<T> pv = new UniversalDeque<T>();
            pv.inf = key;
            if (count == 0)
            {
                left = pv;
                right = pv;
                count++;
            }
            else
            {
                right.r = pv;
                pv.l = right;
                right = pv;
                count++;
            }
        }

        /// <summary>
        /// Чтение элемента слева
        /// </summary>
        /// <returns> Значение крайнего левого элемента </returns>
        public T PopLeft()
        {
            if (!IsEmpty())
            {
                T temp = left.inf;
                if (count == 1)
                {
                    left = null;
                    right = null;
                }
                else
                {
                    left.r.l = null;
                    left = left.r;
                }
                count--;
                return temp;
            }
            else
                return default;
        }

        /// <summary>
        /// Чтение элемента справа
        /// </summary>
        /// <returns> Значение крайнего правого элемента </returns>
        public T PopRight()
        {
            if (!IsEmpty())
            {
                T temp = right.inf;
                if (count == 1)
                {
                    right = null;
                    left = null;
                }
                else
                {
                    right.l.r = null;
                    right = right.l;
                }
                count--;
                return temp;
            }
            else
                return default;
        }

        /// <summary>
        /// Просмотр значения крайнего левого элемента
        /// </summary>
        /// <returns> Значение крайнего левого элемента </returns>
        public T PeekLeft()
        {
            if (!IsEmpty())
                return left.inf;
            else
                return default;
        }

        /// <summary>
        /// Просмотр значения крайнего правого элемента
        /// </summary>
        /// <returns> Значение крайнего правого элемента </returns>
        public T PeekRight()
        {
            if (!IsEmpty())
                return right.inf;
            else
                return default;
        }

        /// <summary>
        /// Возвращает кол-во элементов
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count+1;
        }

        /// <summary>
        /// Проверка на пустоту дека
        /// </summary>
        /// <returns> Логическое значение (истина, ложь) </returns>
        public bool IsEmpty()
        {
            if (count == 0)
                return true;
            else
                return false;
        }
    }
}
