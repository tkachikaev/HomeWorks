using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Program
    {
        /// <summary>
        /// Проверка ввода пользователя числа не менее 1 и не более 1_000_000_000.
        /// Возвращает число.
        /// </summary>
        /// <returns></returns>
        static int ChekNum()
        {
            int num;
            while (true)
            {
                num = Int32.Parse(Console.ReadLine());
                if (num > 0 && num <= 1_000_000_000)
                {
                    break;
                }
                Console.WriteLine("Число не должно быть меньще 1 и не более 1 000 000 000");
            }
            return num;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("С каким числом необходмо произвести разделение?");
            int number = ChekNum();


            Console.ReadKey();
        }
    }
}

