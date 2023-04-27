using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UniversalClassLibrary
{
    public class UniversalSort
    {
        /// <summary>
        /// Универсальная быстрая сортировка массива (Сортировка Хоара)
        /// </summary>
        /// <typeparam name="T"> Заданный тип данных </typeparam>
        /// <param name="Array"> Массив элементов заданного типа данных </param>
        /// <param name="start"> Левая граница сортировки </param>
        /// <param name="end"> Правая граница сортировки </param>
        public static void QuickSort<T>(T[] Array, int start, int end) where T : IComparable<T>
        {
            T pivot = Array[start + (end - start) / 2];
            int left = start;   //левая граница рассматриваемого сегмента массива
            int right = end;    //правая граница рассматриваемого сегмента массива

            do //цикл пока левая граница меньше либо равна правой границе
            {
                //движение по левой границе вправо пока рассматриваемый элемент меньше опорного
                while (Array[left].CompareTo(pivot) < 0)
                    left++;
                //движение по правой границе влево пока рассматриваемый элемент больше опорного
                while (Array[right].CompareTo(pivot) > 0)
                    right--;
                if (left <= right)  //если левая граница меньше либо равна правой границе
                {
                    if (Array[left].CompareTo(Array[right]) > 0)
                    {   //поменять местами элементы если элемент слева больше элемента справа
                        T temp = Array[left];
                        Array[left] = Array[right];
                        Array[right] = temp;
                    }           //после обмена
                    left++;     //увеличиваем левую границу на один
                    right--;    //уменьшаем правую границу на один
                }
            } while (left <= right);

            if (left < end) //если левая граница меньше максимального индекса массива
                QuickSort<T>(Array, left, end);   //повторный вызов быстрой сортировки на сегменте в половину меньше
            if (right > start)  //если правая граница больше минимального индекса массива
                QuickSort<T>(Array, start, right);//повторный вызов быстрой сортировки на сегменте в половину меньше
        }


        /// <summary>
        /// Универсальная быстрая сортировка списка (Сортировка Хоара)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QuickSort<T>(List<T> list, int start, int end) where T : IComparable<T>
        {
            T pivot = list[start + (end - start) / 2];
            //левая граница рассматриваемого сегмента списка
            int left = start;
            //правая граница рассматриваемого сегмента списка
            int right = end;

            do //цикл пока левая граница меньше либо равна правой границе
            {
                //движение по левой границе вправо пока рассматриваемый элемент меньше опорного
                while (list[left].CompareTo(pivot) < 0)
                    left++;
                //движение по правой границе влево пока рассматриваемый элемент больше опорного
                while (list[right].CompareTo(pivot) > 0)
                    right--;
                if (left <= right)  //если левая граница меньше либо равна правой границе
                {
                    if (list[left].CompareTo(list[right]) > 0)
                    {   //поменять местами элементы если элемент слева больше элемента справа
                        T temp = list[left];
                        list[left] = list[right];
                        list[right] = temp;
                    }           //после обмена
                    left++;     //увеличиваем левую границу на один
                    right--;    //уменьшаем правую границу на один
                }
            } while (left <= right);

            if (left < end) //если левая граница меньше максимального индекса списка
                QuickSort<T>(list, left, end);   //повторный вызов быстрой сортировки на сегменте в половину меньше
            if (right > start)  //если правая граница больше минимального индекса списка
                QuickSort<T>(list, start, right);//повторный вызов быстрой сортировки на сегменте в половину меньше
        }
    }
}
