using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalClassLibrary
{
    /// <summary>
    /// Класс содержащий методы вычисления интеграла
    /// </summary>
    public class Integral
    {
        /// <summary>
        /// Исчисление интеграла методом прямоугольников
        /// </summary>
        /// <param name="f"> Заданная функция </param>
        /// <param name="a"> Левая граница </param>
        /// <param name="b"> Правая граница </param>
        /// <param name="n"> Точность вычисления интеграла </param>
        /// <returns></returns>
        public static double RectanglesMethod(Func<double, double> f, double a, double b, int n)
        {
            double DeltaX = (double)(b - a) / n;    //вычисление шага
            double sum = 0;
            double x = a;                       //объявление x для начальной границы

            while (x < b)
            {
                sum += f(x) * DeltaX; //формула интегрирования
                x += DeltaX;              //Изменение DeltaX
            }
            return sum;
        }
    }
}
