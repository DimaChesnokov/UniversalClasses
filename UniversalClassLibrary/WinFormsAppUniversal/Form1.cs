using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalClassLibrary;

namespace WinFormsAppUniversal
{
    public partial class Form1 : Form
    {
        static List<int> list = new List<int>();
        static List<string> list1 = new List<string>();
        static UniversalList<string> UnList = new UniversalList<string>();
        static UniversalStack<string> stck = new UniversalStack<string>();
        public Form1()
        {
            InitializeComponent();
        }
        
        //-----------Вычисление интеграла------------
        //Кнопка вычисления интеграла
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if (comboBox1.Text == "(x^(3))/((e^(x))-1)")
                    textBox3.Text = Convert.ToString(IntegralOne());
                else if (comboBox1.Text == "1/(x^(5))")
                    textBox3.Text = Convert.ToString(IntegralTwo());
                else if (comboBox1.Text == "2*x-(7^(x))")
                    textBox3.Text = Convert.ToString(IntegralThree());
                else if (comboBox1.Text == "(3*x+1)^(9)")
                    textBox3.Text = Convert.ToString(IntegralFour());
                else if (comboBox1.Text == "1/(4*x-5)")
                    textBox3.Text = Convert.ToString(IntegralFive());
            }
            catch 
            {
                MessageBox.Show("Вы ввели недопустимые значения.\nВозможно ввели не корректные данные или не ввели их вовсе!", "Ошибка!");
            }
        }
        
        //Методы вычисления интеграла по заданным функциям
        public double IntegralOne()
        {
            double f(double x) => ((Math.Pow(x, 3)) / (Math.Pow(Math.E, x) - 1));
            return Integral.RectanglesMethod(f, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox4.Text));
        }
        public double IntegralTwo()
        {
            double f(double x) => (1/(Math.Pow(x,5)));
            return Integral.RectanglesMethod(f, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox4.Text));
        }
        public double IntegralThree()
        {
            double f(double x) => ((2*x)-Math.Pow(7,x));
            return Integral.RectanglesMethod(f, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox4.Text));
        }
        public double IntegralFour()
        {
            double f(double x) => (Math.Pow(3*x+1,9));
            return Integral.RectanglesMethod(f, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox4.Text));
        }
        public double IntegralFive()
        {
            double f(double x) => (1/(4*x-5));
            return Integral.RectanglesMethod(f, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox4.Text));
        }

        //------------Сортировка------------
        //Сортировка чисел 
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            list.Clear();
            Random r = new Random();
            for (int i = 0; i <= 100; i++)
            {
                list.Add(r.Next(100));
                richTextBox1.Text = richTextBox1.Text+" " + list[i];
            }
            richTextBox2.Text = "";
            UniversalSort.QuickSort(list, 0, list.Count - 1);
            for (int i = 0; i <= 100; i++)
            {
                richTextBox2.Text = richTextBox2.Text + " " + list[i];
            }
        }

        //Сортировка символов
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            list1.Clear();
            Random r = new Random();
            for (int i = 0; i <= 100; i++)
            {
                list1.Add(Convert.ToString(Convert.ToChar(r.Next(33,100))));
                richTextBox1.Text = richTextBox1.Text + " " + list1[i];
            }
            richTextBox2.Text = "";
            UniversalSort.QuickSort(list1, 0, list1.Count - 1);
            for (int i = 0; i <= 100; i++)
            {
                richTextBox2.Text = richTextBox2.Text + " " + list1[i];
            }
        }

        //Сортировка текста
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            list1.Clear();
            int z = 0;
            string str = "";
            Random r = new Random();
            for (int i = 0; i <= 100; i++)
            {
                z = r.Next(2,5);
                for(int j = 0; j <= z; j++)
                {
                    str = str + (Convert.ToString(Convert.ToChar(r.Next(97, 122))));
                }
                list1.Add(str);
                richTextBox1.Text = richTextBox1.Text + " " + list1[i];
                str = "";
            }
            richTextBox2.Text = "";
            UniversalSort.QuickSort(list1, 0, list1.Count - 1);
            for (int i = 0; i <= 100; i++)
            {
                richTextBox2.Text = richTextBox2.Text + " " + list1[i];
            }
        }

        // Сортировка класса студенты по среднему балу
        private void button8_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            richTextBox1.Text = "";
            Student std1 = new Student("Дима", r.Next(2, 5));
            Student std2 = new Student("Лёша", r.Next(2, 5));
            Student std3 = new Student("Женя", r.Next(2, 5));
            Student std4 = new Student("Артём", r.Next(2, 5));
            Student std5 = new Student("Миша", r.Next(2, 5));
            Student std6 = new Student("Максим", r.Next(2, 5));
            Student std7 = new Student("Стас", r.Next(2, 5));
            Student[] students = { std1, std2, std3, std4, std5, std6, std7 };
            for (int i = 0; i <= 6; i++)
            {
                richTextBox1.Text = richTextBox1.Text + students[i].Name + " " + Convert.ToString(students[i].AverageMark) + "\n";
            }
            UniversalSort.QuickSort(students, 0, students.Length - 1);
            richTextBox2.Text = "";
            for (int i = 0; i <= 6; i++)
            {
                richTextBox2.Text = richTextBox2.Text + students[i].Name + " " + Convert.ToString(students[i].AverageMark) + "\n";
            }
        }

        //-----------Стек-----------
        //Добавление элемента в стек
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                richTextBox3.Text = textBox5.Text + ("\n") + richTextBox3.Text;
                stck.Add(textBox5.Text);
                textBox5.Text = "";
            }
            catch
            {
                MessageBox.Show("Стек пуст!", "Предупреждение!");
            }
        }

        //Удаление элемента из стека
        private void button6_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.AddRange(richTextBox3.Lines);
            list.RemoveAt(0);
            richTextBox3.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                richTextBox3.AppendText(list[i] + "\n");
            }
            richTextBox4.Text= stck.Pop();
        }

        //Просмотр элемента в стеке
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox4.Text = stck.Peek();
            }
            catch
            {
                MessageBox.Show("Стек пуст!", "Предупреждение!");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (textBox7.Text == "")
                count = 0;
            else
                count = Convert.ToInt32(textBox7.Text);
            if ((UnList.Count() > count)|| (textBox7.Text == ""))
            {
                if (textBox7.Text == "")
                {
                    UnList.AddToTheEnd(textBox6.Text);
                    UnListReload();
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else
                {
                    UnList.Insert(Convert.ToInt32(textBox7.Text), textBox6.Text);
                    UnListReload();
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Список пуст или индекс больше размера списка!", "Внимание!");
            }
        }
        private void UnListReload()
        {
            richTextBox6.Text = "";
            for (int i = 0; i < UnList.Count(); i++)
            {
                richTextBox6.Text = richTextBox6.Text + UnList.Get(i) + "\n";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (textBox7.Text == "")
                count = 0;
            else
                count = Convert.ToInt32(textBox7.Text);
            if ((UnList.Count() > count) || (textBox7.Text == ""))
            {
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Индекс введён неверно или больше размера списка!", "Внимание!");
                }
                else
                {
                    richTextBox5.Text = "";
                    richTextBox5.Text = UnList.RemoveByIndex(Convert.ToInt32(textBox7.Text));
                    UnListReload();
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Список пуст или индекс больше размера списка!", "Внимание!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (textBox7.Text == "")
                count = 0;
            else
                count = Convert.ToInt32(textBox7.Text);
            if ((UnList.Count() > count) || (textBox7.Text == ""))
            {
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Индекс введён неверно или больше размера списка!", "Внимание!");
                }
                else
                {
                    richTextBox5.Text = "";
                    richTextBox5.Text = UnList.Get(Convert.ToInt32(textBox7.Text));
                    UnListReload();
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Список пуст или индекс больше размера списка!", "Внимание!");
            }
        }
    }
}
