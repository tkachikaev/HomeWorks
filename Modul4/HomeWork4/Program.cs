using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Lesson3_4(); 
        }

        /// <summary>
        /// Вывод убыточных месяцев
        /// Решил сделать 4 убыточных месяца вместо трех
        /// так как 4-ый убыточный месяц дублируется в трех местах 
        /// </summary>
        static void Lesson1()
        {

            #region Массивы и счетчики
            //Доходы
            int[] income = new int[12] { 100_000, 120_000, 80_000, 70_000, 100_000, 200_000, 130_000, 150_000, 190_000, 110_000, 150_000, 100_000 };
            //Расходы
            int[] cost = new int[12] { 80_000, 90_000, 70_000, 70_000, 80_000, 120_000, 140_000, 65_000, 90_000, 70_000, 120_000, 80_000 };

            int[] sum = new int[12];//Сумма
            int[] sumCopy = new int[12];//Использую этот массив после сортировки
            int[] badMonth = new int[4];//4 убыточных месяца ()
            int sumMonth = 0;//Сумма месяцев с доходом
            
            #endregion

            #region Красивое отображение
            Console.ForegroundColor = ConsoleColor.Yellow; //Цвет таблицы
            Console.WriteLine($"{"Месяц",5}\t{"Доходы",20}\t{"Расходы",20}\t{"Прибыль, тыс. руб",20}");//Для красивого отображения столбцов
            Console.ResetColor();//Сброс цвета
            #endregion

            #region Выводим таблицу
            for (int i = 0; i < 12; i++)//Проходим по массивам
            {
                Console.Write($"{i +1, 5}\t{income[i].ToString("C2"),20}\t{cost[i].ToString("C2"),20}");//Выводим таблицу двух массивов
                
                sum[i] = income[i] - cost[i];//Записываем сумму масивов 
                
                Console.WriteLine($"\t{sum[i].ToString("C2"), 20}");//показываем прибыль
            }
            #endregion

            #region Месяцы с расходами

            #region Находим 3 минимальных числа

            //Console.Write("1 Вывод");

            Array.Copy(sum, sumCopy, sum.Length);       //Копируем перед сортировкой, после буду работать с копи (Можно наоборот, о уже код написал)
            Array.Sort(sum);                            //Сортируем массив (Для удобства)

            for (int i = 0; i < badMonth.GetLength(0); i++)  //Цикл для пробежки по массиву из 4х элементов
            {                                               
                
                for (int j = 0; j < sum.GetLength(0); j++)   //Забраем первые числа в масив с 4мя элементами(Первые числа минимальные)
                {
                    badMonth[i] = sum[i];                    //Записываем число в массив с 4мя
                    if (j == (4-1))     //Массив на 4ом эллемене (4-1 на случай если делать ввод пользователя(input - 1))
                    {               //Чтобы не крашилось
                        break;      //выход из цикла
                    }
                }
                //Console.Write($"{badMonth[i]}, ");
            }
            //Console.WriteLine();
            //Console.Write("2 Вывод");
            //for (int i = 0; i < badMonth.GetLength(0); i++)
            //{
            //    Console.Write($"{badMonth[i]}, ");
            //}
            #endregion

            #region Выводим ВСЕ месяцы где встречаются убытки
            Console.Write("Месяцы с минимальными доходами: ");
            for (int i = 0; i < sumCopy.Length; i++)
            {
                for (int j = 0; j < badMonth.Length; j++)
                {
                    if (sumCopy[i] == badMonth[j])
                    {
                        Console.Write($"{i + 1}, ");
                    }
                }

            }
            #endregion

            #endregion

            #region Кол-во доходных месяцев
            sumMonth = 0;//Сбрасываем
            for (int i = 0; i < sum.Length; i++) 
            {
                
                if (sum[i] > 0)
                {
                    sumMonth++; //+ 1 в кол-во положительных месяцев
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Месяцев с положительной прибылью: {sumMonth}");
            #endregion
        }

        /// <summary>
        /// Треугольник паскаля
        /// с вводом числа пользователя
        /// </summary>
        static void Lesson2() 
        {
            Console.WriteLine("Сколько строк треугольника вы хоитите вывести?");
            int line  = Int32.Parse(Console.ReadLine()); //Сколько строк выводить

            int i, j, k = 1; // Три перменные К начальная
            for (i = 1; i <= line; i++) //Ограничение строк
            {
                for (j = 1; j < i + 1; j++)
                {
                    Console.Write(k++ + " "); //Вывод с пробелом
                }

                Console.Write("\n");//Табулеция
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Умножение сгенерированного массива на выбранное число от 1 до 10.
        /// </summary>
        static void Lesson3_1()
        {
            int column; //Кол-во столбцов
            int line; //Кол-во строк

            #region Кол-во строк и столбиков массива
            Console.WriteLine("Какое кол-во столбцов вы хотите создать?");
            while (true) //Проверка ввода
            {
                Console.ForegroundColor = ConsoleColor.Red; //Цвета
                Console.WriteLine("не меньше 1. не больше 10");
                Console.ForegroundColor = ConsoleColor.White;

                column = Int32.Parse(Console.ReadLine()); 
                if (column >=1 & column <= 10)
                {
                    break;
                }
            }
            Console.WriteLine("Какое кол-во строк вы хотите создать?");
            while (true) //Проверка ввода
            {
                Console.ForegroundColor = ConsoleColor.Red; //Цвета
                Console.WriteLine("не меньше 1. не больше 10");
                Console.ForegroundColor = ConsoleColor.White;

                line = Int32.Parse(Console.ReadLine());
                if (line >= 1 & line <= 10)
                {
                    break;
                }
            }
            #endregion

            #region Создание и заполнение массива
            int[,] matrix = new int[line, column]; //Массив - заполняется рандомно
            int input;//На какой число умножаем массив

            Random random = new Random();
            //int rand = random.Next(1,101);
            Console.WriteLine("Массив:");
            for (int i = 0; i < matrix.GetLength(0); i++) //Пробегаем по строкам
            {   
                for (int j = 0; j < matrix.GetLength(1); j++) //Пробегаем по столбцам
                {
                    matrix [i, j] = random.Next(1, 101);// Заполняем массив от 1 до 100
                    Console.Write($"{matrix[i,j],10}  ");//Показываем массив
                }
                Console.WriteLine();
            }
            #endregion

            #region Умножение массива
            Console.WriteLine("На какое число вы хотите умножить массив?");
            while (true)//Проверка ввода
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Диапозон доступных чисел от 1 до 10!");
                Console.ForegroundColor = ConsoleColor.White;
                input = Int32.Parse(Console.ReadLine());//Ввод пользователя
                if (input >= 1 & input <= 10) //Проверка ввода
                {
                    break; //Выход при правильном вводе
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= input; //Умножаем элменты массива
                    Console.Write($"{matrix[i,j],10} "); 
                }
                Console.WriteLine();
            }
            #endregion
        }

        /// <summary>
        /// Сложение и вычитание рандомных массивов
        /// </summary>
        static void Lesson3_2()
        {
            #region Создание и заполнение массивов
            int[,] matrix1 = new int[3, 3];// Объявляем 2
            int[,] matrix2 = new int[3, 3];// массива
            

            Random rnd = new Random();//rnd для рандомного заполнения

            // Заполняем массив 1
            for (int i = 0; i < matrix1.GetLength(0); i++) // Заполняем первый массив от 1 до 100
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = rnd.Next(10, 101);
                    Console.Write($"{matrix1[i,j]}\t ");
                }
                Console.WriteLine();
            } 
            Console.WriteLine(); // Красивое заполнение

            // Заполняем массив 2
            for (int i = 0; i < matrix2.GetLength(0); i++) // Заполняем второй массив от 1 до 100
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = rnd.Next(10, 101);
                    Console.Write($"{matrix2[i, j]}\t ");
                }
                Console.WriteLine();
            } 
            Console.WriteLine(); // Красивое заполнение

            #endregion

            Console.WriteLine("Сложить данные массивы или вычесть?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Введите + или -");
            Console.ForegroundColor = ConsoleColor.White;
            char input = Convert.ToChar(Console.ReadLine());
            #region Сложение массимов
            if (input == '+')
            {
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix1[i, j] += matrix2[i, j];
                        Console.Write($"{matrix1[i, j]}\t ");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            #region Вычитание массивов
            else if (input == '-')
            {
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix1[i, j] -= matrix2[i, j];
                        Console.Write($"{matrix1[i, j]}\t ");
                    }
                    Console.WriteLine();
                }

            }
            #endregion
        }

        /// <summary>
        /// Умножение массива, умножение разных матриц.
        /// </summary>
        static void Lesson3_3()
        {
            int column; //Кол-во столбцов
            int line; //Кол-во строк

            #region Кол-во строк и столбиков массива
            Console.WriteLine("Какое кол-во столбцов вы хотите создать?");
            while (true) //Проверка ввода
            {
                Console.ForegroundColor = ConsoleColor.Red; //Цвета
                Console.WriteLine("не меньше 1. не больше 10");
                Console.ForegroundColor = ConsoleColor.White;

                column = Int32.Parse(Console.ReadLine());
                if (column >= 1 & column <= 10)
                {
                    break;
                }
            }
            Console.WriteLine("Какое кол-во строк вы хотите создать?");
            while (true) //Проверка ввода
            {
                Console.ForegroundColor = ConsoleColor.Red; //Цвета
                Console.WriteLine("не меньше 1. не больше 10");
                Console.ForegroundColor = ConsoleColor.White;

                line = Int32.Parse(Console.ReadLine());
                if (line >= 1 & line <= 10)
                {
                    break;
                }
            }
            #endregion

            #region Объявляем матрицы
            int[,] matrix1 = new int[line, column];
            int[,] matrix2 = new int[line, column];
            #endregion

            #region Заполнение массива 1
            Random random = new Random();
            Console.WriteLine("Массив 1:");
            for (int i = 0; i < matrix1.GetLength(0); i++) //Пробегаем по строкам
            {
                for (int j = 0; j < matrix1.GetLength(1); j++) //Пробегаем по столбцам
                {
                    matrix1[i, j] = random.Next(1, 51);// Заполняем массив от 1 до 51
                    Console.Write($"{matrix1[i, j],10} ");//Показываем массив
                }
                Console.WriteLine();
            }
            #endregion

            Console.WriteLine(); //Разделитель

            #region Заполнение массива 2
            Console.WriteLine("Массив 2:");
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = random.Next(1, 51);
                    Console.Write($"{matrix2[i,j],10} ");
                }
                Console.WriteLine();
            }
            #endregion

            Console.WriteLine();

            #region Умножаем массивы
            Console.WriteLine("Массивы после умножения:");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] *= matrix2[i, j];
                    Console.Write($"{matrix1[i,j] ,10} ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }

        static void Lesson3_4()
        {
            int line1;
            int column1;
            int line2;
            int column2;

            Console.WriteLine("Введите кол-во строк первого массива");
            line1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во столбцов первого массива");
            column1 = Int32.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Введите кол-во строк второго массива");
                line2 = Int32.Parse(Console.ReadLine());
                if (column1 == line2) //Проверка: строка первой матрицы должа соответсвовать столбцу второй матрицы
                {
                    break;
                }
                Console.WriteLine($"Строка массива не оостветсвуют столбцу первого массива\nВведите: {column1}");
            }
            Console.WriteLine("Введите кол-во столбцов второго массива");
            column2 = Int32.Parse(Console.ReadLine());

            int[,] matrix1 = new int[line1, column1]; // Объявляем 
            int[,] matrix2 = new int[line2, column2]; // две матрицы

            //int lineRes = Math.Max(line1, line2);//Выясняем максималью строку и стобец. Для умножения должна
            //int columnRes = Math.Max(column1, column2); //использоваться максимальная строка и столбец

            int[,] result = new int[line1, column2];// Максимальная строка и столбец равный строке первой матрицы и столбцу второй 

            #region Заполняем две матрицы matrix1 matrix2
            Random rnd = new Random();
            Console.WriteLine("Matrix 1: ");
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = rnd.Next(1, 5);
                    Console.Write($"{matrix1[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Matrix 2: ");
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = rnd.Next(1, 5);
                    Console.Write($"{matrix2[i, j]} ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Выводим результат умножения
            Console.WriteLine("Результат умножения матриц:");
            for (int i = 0; i < matrix1.GetLength(0); i++) //Идем по строке первой матрицы
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)//Идем по столбцу второй матрицы матрицы
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }                  
                }
            }
            #endregion

            #region Результат
            Console.WriteLine();
            Console.WriteLine("Результат:");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write($"{result[i,j]} ");
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}

