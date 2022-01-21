using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Сформировать массив случайных целых чисел (размер задается пользователем). 
//Вычислить сумму чисел массива и максимальное число в массиве.  
//Реализовать решение задачи с использованием механизма задач продолжения.

namespace ITMO_BIM_m1_lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            int a_s;
            try
            {
                Console.WriteLine("Укажите размер массива:");
                a_s = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка: Некорректный ввод!");
                Console.ReadKey();
                return;
            }
            //a_s = 20;
            int[] rands = new int[a_s];
            Random Rand = new Random(); 
            for (int i = 0; i < a_s; i++)
            {
                rands[i] = Convert.ToInt32(Rand.Next(100)); //0~99
                Console.WriteLine(rands[i]);
            }
            //Summ();
            //MaxVal();

            Action act1 = new Action(Summ);
            Task task1 = new Task(act1);
            task1.Start();

            Action<Task> act2 = new Action<Task>(MaxVal);
            Task task2 = task1.ContinueWith(MaxVal);

            Console.ReadKey();
            void Summ()
            {
                int sum = 0;
                foreach (int n in rands)
                {
                    sum += n;
                }
                Console.WriteLine($"Итого: {sum}");
            }
            void MaxVal(Task task)
            {
                int m_v = 0;
                foreach (int n in rands)
                {
                    if (m_v < n)
                        m_v = n;
                }
                Console.WriteLine($"Макс.: {m_v}");
            }
        }
    }
}
