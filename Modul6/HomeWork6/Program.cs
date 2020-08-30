using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

         

        /// <summary>
        /// Возвращает кол-во групп для цифр путем (2(group) * 2)num, + группа для 1-цы.
        /// </summary>
        /// <param name="num">Пользовательский ввод</param>
        /// <returns></returns>
        static int GroupDell(int num)
        {
            int group = 1;
            int count = 2;

            while (true)
            {
                count = count * 2;
                group += 1;
                if (count >= num)
                {
                    return group;
                }
            }
        }

        /// <summary>
        /// Создает массив листов, количество массивов зависит от принимающего значения.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        static List<List<int>> ListFill(int group)
        {
            List<List<int>> arrayGroup = new List<List<int>>();

            for (int i = 0; i < group; i++)
            {
                arrayGroup.Add(new List<int>());
            }

            return arrayGroup;
        }

        /// <summary>
        /// Возвращает массив с разбиение неделимых чисел в разных массивах.
        /// </summary>
        /// <param name="ArrayList">Массив с группами</param>
        /// <param name="Num">Максимальное число для разбиения</param>
        /// <returns></returns>
        //static List<List<int>> ListSplitting(List<List<int>> ArrayList, int Num)
        //{
            
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("С каким числом необходмо произвести разделение?");
            int number = ChekNum();

            int group = GroupDell(number);
            List<List<int>> arrayGroup = ListFill(group);

            #region Надо доделать список пробегания по массиву листов в заполнении списков
            for (int i = 0; i < arrayGroup.Count; i++)
            {
                for (int j = 0; j < arrayGroup[i].Count; j++)
                {

                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}

