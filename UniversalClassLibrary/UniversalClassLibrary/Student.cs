using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Класс студент
    /// </summary>
    public class Student : IComparable<Student>
    {
        string name;         //Имя студента
        double average_mark; //Средний балл студента

        /// <summary>
        /// Возвращает имя студента
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Возвращает средний балл студента
        /// </summary>
        public double AverageMark { get { return average_mark; } }

        /// <summary>
        /// Создает элемент класса- Студент
        /// </summary>
        /// <param name="Name">Имя студента</param>
        /// <param name="AverageMark">Средний бал студента</param>
        public Student(string Name, double AverageMark)
        {
            if (AverageMark > 5)
                throw new ArgumentException("Средний балл у студента не может быть больше 5.");
            name = Name;
            average_mark = AverageMark;
        }

        /// <summary>
        /// Функция позволяющая сравнить двух студентов по их среднему баллу
        /// </summary>
        /// <param name="other"> Студент с которым сравнивают </param>
        /// <returns> Возвращает -1 если средний балл студента больше среднего балла студента с которым его сравнивают
        ///                 Возвращает 0 если средние баллы у обоих студентов равны
        ///                 Возвращает 1 если средний балл студента меньше среднего балла студента с уоторым его сравнивают</returns>
        int IComparable<Student>.CompareTo(Student other)
        {
            if (other.average_mark < this.average_mark)
                return -1;
            else if (other.average_mark == this.average_mark)
                return 0;
            else
                return 1;
        }
    }
}
