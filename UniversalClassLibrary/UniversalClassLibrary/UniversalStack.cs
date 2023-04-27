using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Структура данных "Стек" (универсальная)
    /// </summary>
    /// <typeparam name="T"> Заданный тип данных </typeparam>
    public class UniversalStack<T>
    {
        /// <summary>
        /// Ссылка на верхний элемент стека
        /// </summary>
        UniversalStack<T> top;
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        UniversalStack<T> next;

        private T value;    //значение элемента
        private int count;  //количество элементов в стеке

        /// <summary>
        /// Создание пустого стека
        /// </summary>
        public UniversalStack()
        {
            top = null;
            next = null;
            count = 0;
        }

        /// <summary>
        /// Создание стека с первым элементом
        /// </summary>
        /// <param name="key"> Первый элемент </param>
        public UniversalStack(T key)
        {
            count++;
            UniversalStack<T> temp = new UniversalStack<T>();
            temp.next = top;
            temp.value = key;
            top = temp;
        }

        /// <summary>
        /// Добавить элемент в стек
        /// </summary>
        /// <param name="key"> Добавляемый элемент </param>
        public void Add(T key)
        {
            count++;
            UniversalStack<T> temp = new UniversalStack<T>();
            temp.next = top;
            temp.value = key;
            top = temp;
        }

        /// <summary>
        /// Достать верхний элемент их стека
        /// </summary>
        /// <returns> Значение верхнего элемента </returns>
        public T Pop()
        {
            if (IsEmpty())
                return default;
            count--;
            T temp = top.value;
            top = top.next;
            return temp;
        }

        /// <summary>
        /// Просмотр верхнего элемента стека
        /// </summary>
        /// <returns> Значение верхнего элемента </returns>
        public T Peek()
        {
            return top.value;
        }

        /// <summary>
        /// Проверка стека на пустоту
        /// </summary>
        /// <returns> Булевое значение </returns>
        public bool IsEmpty()
        {
            if (count == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Количество элементов в стеке
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
