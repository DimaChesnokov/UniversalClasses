using System;
using System.Collections.Generic;
using System.ComponentModel;
using UniversalClassLibrary;

namespace UniversalConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestListStr();
            //TestListInt();
            //TestDequeStr();
            //TestDequeInt();
            //TestQueueInt();
            //TestQueueStr();
            //TestQueuePrStr();
            //TestUniversalSort();
        }

        //Универсальный лист (Строки)
        static void TestListStr()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный лист (Строки)");
            UniversalList<string> list = new UniversalList<string>();
            list.AddToTheTop("Tom");
            list.AddToTheTop("Alice");
            list.AddToTheEnd("Alex");
            list.AddToTheEnd("Mike");
            list.Insert(2, "Insert");
            list.RemoveByIndex(4);
            Console.WriteLine("Элементы 1 списка:");
            for(int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine("("+i+") Элемент = "+list.Get(i));
            }
            UniversalList<string> list2 = list.CopyPartOfList(2, list.Count());
            Console.WriteLine("");
            Console.WriteLine("Элементы 2 списка:");
            for (int i = 0; i < list2.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + list2.Get(i));
            }
            UniversalList<string> list3 = list.MergeLists(list2);
            Console.WriteLine("");
            Console.WriteLine("Элементы 3 списка:");
            for (int i = 0; i < list3.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + list3.Get(i));
            }
        }

        //Универсальный лист (Числа)
        static void TestListInt()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный лист (Числа)");
            UniversalList<int> list = new UniversalList<int>();
            list.AddToTheTop(1);
            list.AddToTheTop(2);
            list.AddToTheEnd(3);
            list.AddToTheEnd(4);
            list.Insert(2, 5);
            list.RemoveByIndex(4);
            Console.WriteLine("Элементы 1 списка:");
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + list.Get(i));
            }
            UniversalList<int> list2 = list.CopyPartOfList(2, list.Count());
            Console.WriteLine("");
            Console.WriteLine("Элементы 2 списка:");
            for (int i = 0; i < list2.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + list2.Get(i));
            }
            UniversalList<int> list3 = list.MergeLists(list2);
            Console.WriteLine("");
            Console.WriteLine("Элементы 3 списка:");
            for (int i = 0; i < list3.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + list3.Get(i));
            }
        }

        //Универсальный Дек (Строки)
        static void TestDequeStr()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный Дек (Строки)");
            UniversalDeque<string> deque = new UniversalDeque<string>();
            deque.AddLeft("Второй");
            deque.AddLeft("Первый");
            deque.AddRight("Третий");
            deque.AddRight("Четвёртый");
            deque.AddRight("Пятый");
            deque.AddRight("Шестой");
            Console.WriteLine("Вывод значение левого элемента:" +deque.PeekLeft());
            Console.WriteLine("Вывод значение правого элемента:" + deque.PeekRight());
            Console.WriteLine("Вывод значение левого элемента с его удалением:" + deque.PopLeft());
            Console.WriteLine("Вывод значение правого элемента с его удалением:" + deque.PeekRight());
            Console.WriteLine("Оставшиеся элементы дека:");
            Console.WriteLine();
            for (int i = 0; i <= deque.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " +deque.PopLeft());
            }
        }

        //Универсальный Дек (Числа)
        static void TestDequeInt()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный Дек (Числа)");
            UniversalDeque<int> deque = new UniversalDeque<int>();
            deque.AddLeft(20);
            deque.AddLeft(10);
            deque.AddRight(30);
            deque.AddRight(40);
            deque.AddRight(50);
            deque.AddRight(60);
            Console.WriteLine("Вывод значение левого элемента:" + deque.PeekLeft());
            Console.WriteLine("Вывод значение правого элемента:" + deque.PeekRight());
            Console.WriteLine("Вывод значение левого элемента с его удалением:" + deque.PopLeft());
            Console.WriteLine("Вывод значение правого элемента с его удалением:" + deque.PeekRight());
            Console.WriteLine("Оставшиеся элементы дека:");
            Console.WriteLine();
            for (int i = 0; i <= deque.Count(); i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + deque.PopLeft());
            }
        }

        //Универсальный Очередь (Числа)
        static void TestQueueInt()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный Очередь (Числа)");
            UniversalQueue<int> queue = new UniversalQueue<int>();
            queue.Add(10);
            queue.Add(20);
            queue.Add(30);
            queue.Add(40);
            queue.Add(50);
            queue.Add(60);
            Console.WriteLine("Просмотр первого элемента очереди:" + queue.PeekFirst());
            Console.WriteLine("Просмотр последнего элемента в очереди:" + queue.PeekLast());
            Console.WriteLine("Оставшиеся элементы Очереди:");
            Console.WriteLine();
            for (int i = 0; i <= queue.Count+4; i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + queue.Dequeue());
            }
        }

        //Универсальный Очередь (Строки)
        static void TestQueueStr()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный Очередь (Строки)");
            UniversalQueue<string> queue = new UniversalQueue<string>();
            queue.Add("Первый");
            queue.Add("Второй");
            queue.Add("Третий");
            queue.Add("Четвёртый");
            queue.Add("Пятый");
            queue.Add("Шестой");
            Console.WriteLine("Просмотр первого элемента очереди:" + queue.PeekFirst());
            Console.WriteLine("Просмотр последнего элемента в очереди:" + queue.PeekLast());
            Console.WriteLine("Оставшиеся элементы Очереди:");
            Console.WriteLine();
            for (int i = 0; i <= queue.Count + 4; i++)
            {
                Console.WriteLine("(" + i + ") Элемент = " + queue.Dequeue());
            }
        }

        //Универсальный Очередь с приоритетом (Строки)
        static void TestQueuePrStr()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальный Очередь с приоритетом (Строки)");
            UniversalPriorityQueue<string> queuepr = new UniversalPriorityQueue<string>();
            queuepr.Add("Первый", 1);
            queuepr.Add("Второй", 1);
            queuepr.Add("Третий", 3);
            queuepr.Add("Четвёртый", 3);
            queuepr.Add("Пятый", 2);
            queuepr.Add("Шестой", 2);
            Console.WriteLine("Просмотр первого элемента очереди:" + queuepr.PeekFirst());
            Console.WriteLine("Просмотр последнего элемента в очереди:" + queuepr.PeekLast());
            Console.WriteLine("Оставшиеся элементы Очереди:");
            Console.WriteLine();
            for (int i = 0; i <= queuepr.Count + 4; i++)
            {
                Console.WriteLine("(" + i + ")" + "Элемент = " + queuepr.Dequeue());
            }
        }

        //Универсальная сортировка по среднему баллу (Класс студенты)
        static void TestUniversalSort()
        {
            Console.WriteLine();
            Console.WriteLine("Универсальная сортировка по среднему баллу (Класс студенты)");
            Student std1 = new Student("Дима", 4);
            Student std2 = new Student("Лёша", 3);
            Student std3 = new Student("Женя", 3.5);
            Student std4 = new Student("Артём", 4.7);
            Student[] students = { std1, std2, std3, std4 };

            Console.WriteLine("Студенты до сортировки:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].Name);

            UniversalSort.QuickSort(students, 0, students.Length - 1);
            Console.WriteLine("Студенты после сортировки:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].Name);
        } 
    }
}
