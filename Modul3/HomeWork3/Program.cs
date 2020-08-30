using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMenu(); 
        }

        /// <summary>
        /// Основное меню игры с выбором параметров
        /// 1. Режимы игры соло
        /// 2. Режим с друзьями
        /// 3. Правила
        /// </summary>
        static void GameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string titleText = "Игра в Цифры";
            Console.SetCursorPosition((Console.WindowWidth - titleText.Length) / 2, Console.WindowHeight / 4);
            Console.WriteLine(titleText);
            Console.WriteLine("\nВыберите режим игры 1. 2 или 3\n\t1 - Одиночная игра\n\t2 - Играть с друзьями\n\t3 - Правила игры");
            int gameMod = Int32.Parse(Console.ReadLine()); // Выбор режима

            //Варианты режима игры
            switch (gameMod)
            {
                case 1:
                    GameModSin();     //1 - Одиночная игра
                    break;
                case 2:
                    GameModMul();     //2 - Игра с друзьями
                    break;
                case 3:
                    Console.WriteLine("Игроки ходят по очереди(игра сообщает о ходе текущего игрока" +
                        "\nИгрок, ход которого указан вводит число, которое может принимать значения 1, 2, 3 или 4," +
                        "\nвведенное число вычитается из загаданного или сгенерированного" +
                        "\nВыигрывает тот игрок, после чьего хода загаданное число обратилась в ноль.");
                    Console.WriteLine("\n\tДля возврата в предыдущее меню нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    GameMenu();
                    break;

            }
        }

        /// <summary>
        /// Метод игры против компьютера
        /// </summary>
        static void GameModSin()
        {
            Console.WriteLine("\t1 - Сгенерировать чило автоматически от 12 до 120\n\t2 - Ввести число самостоятельно");
            int gameModSin = Int32.Parse(Console.ReadLine());
            if (gameModSin == 1) GameModSin1();     //Режимы игры Генерация чисел
            if (gameModSin == 2) GameModSin2();     //Ввод чисел в ручную *Можно было сделать else но так красивее*

  
        }

        /// <summary>
        /// Игра против компютера
        /// использую генерацию чисел
        /// </summary>
        static void GameModSin1()
        {
            int gameNumberPc; // Число выбранное компьютером

            #region Генерация чисел
            Random gameNumber = new Random();                   //Генератор случайных чилес
            int count = gameNumber.Next(12, 121);               //от 12 до 120 включительно
            Console.WriteLine($"Загаданно число {count} Максимальное число для вычитания от 1 до 4");
            #endregion
            
            while (true)
            {
                #region Проверка пользовательского ввода
                Console.WriteLine($"Ваш ход! Число {count}");
                int userTry = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа

                //Проверка на ввод от 1 до 4 включительно
                if (userTry > 4 || userTry <= 0)
                {   
                    while (userTry > 4 || userTry <= 0)
                    {
                        Console.WriteLine("Введите число от 1 до 4");
                        userTry = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                    }
                }
                #endregion

                #region Логика игры
                count -= userTry;                               //Отнимаем число пользователя от основного числа
                if (count <= 0)
                {
                    Console.WriteLine("Поздравляю с победой!");
                    break;
                }
                else if (count > 0 && count <= 4)               //Некий AI
                {                                               //Если 1-4 осталось
                    gameNumberPc = count;
                    Console.WriteLine("Вы проиграли");
                    Console.WriteLine($"Число: {count}");       //ПК удалит необходимое число
                    break;
            }
                else
                {
                    gameNumberPc = gameNumber.Next(1, 5);       //Каждый цикл генерируем новое число от 1-4
                    Console.WriteLine($"Мое число: {gameNumberPc}");
                    count -= gameNumberPc;                      //Отнимаем от основного числа, число загаданное пк
                }
                #endregion
            }
            #region Возврат в меню
            Console.WriteLine("\n\tДля возврата в предыдущее меню нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            GameMenu();
            #endregion
        }

        /// <summary>
        /// Игра против компютера
        /// Ручной ввод
        /// </summary>
        static void GameModSin2()
        {
            int gameNumberPc; // Число выбранное компьютером

            #region Ввод числа в ручную
            Random gameNumber = new Random();                   //Генератор случайных чилес
            Console.WriteLine($"Введите число от 12 до 120");
            int count = Int32.Parse(Console.ReadLine());        //от 12 до 120 включительно - вводит пользователь

            //Проверка допустимого диапозона чисел
            if (count < 12 || count > 120)
            {
                while (count < 12 || count > 120)
                {
                    Console.WriteLine("Введите число от 12 до 120");
                    count = Int32.Parse(Console.ReadLine());  //от 12 до 120 включительно - вводит пользователь
                }
            }

            #endregion

            Console.WriteLine($"Загаданно число {count} Максимальное число для вычитания от 1 до 4");
            while (true)
            {
                #region Проверка ввода
                Console.WriteLine($"Ваш ход! Число {count}");

                //Проверка на ввод от 1 до 4 включительно
                int userTry = Int32.Parse(Console.ReadLine());  ///от 12 до 120 включительно - вводит пользователь
                if (userTry > 4 || userTry <= 0)
                {
                    while (userTry > 4 || userTry <= 0)
                    {
                        Console.WriteLine("Введите число от 1 до 4");
                        userTry = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                    }
                }
                #endregion

                #region Логика игры
                //Отнимаем число пользователя от основного числа
                count -= userTry;
                if (count <= 0)
                {
                    Console.WriteLine("Поздравляю с победой!");
                    break;
                }
                else if (count > 0 && count <= 4)               //Некий AI
                {                                               //Если 1-4 осталось
                    gameNumberPc = count;                       //ПК удалит необходимое число
                    Console.WriteLine("Вы проиграли");          //
                    Console.WriteLine($"Число: {count}");       //
                    break;
                }
                else
                {
                    gameNumberPc = gameNumber.Next(1, 5);       //Каждый цикл генерируем новое число от 1-4
                    Console.WriteLine($"Мое число: {gameNumberPc}");
                    count -= gameNumberPc;                      //Отнимаем от основного числа, число загаданное пк

                }
                #endregion
            }
            #region Возврат в меню
            Console.WriteLine("\n\tДля возврата в предыдущее меню нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            GameMenu();
            #endregion
        }


        /// <summary>
        /// Метод игры с друзьями
        /// </summary>
        static void GameModMul()
        {
            string user1; //Ник
            string user2; //Ник
            string user3; //Ник

            int numberMax = 4; ; //Максимальное число для вычета (Наверное 4 можно не указывать так как в строке 256 присвоится 4)

            #region Выбор количества игроков
            Console.WriteLine("Сколько игроков 2 - 3? ");
            int player = Int32.Parse(Console.ReadLine());
            #endregion

            #region Ввод числа / проверка ввода.
            Console.WriteLine($"Введите число от 16 до 240");
            int count = Int32.Parse(Console.ReadLine());        //от 16 до 240 включительно - вводит пользователь

            //Проверка допустимого диапозона чисел
            if (count < 16 || count > 240)
            {
                while (count < 16 || count > 240)
                {
                    Console.WriteLine("Введите число от 16 до 240");
                    count = Int32.Parse(Console.ReadLine());  //от 14 до 240 включительно - вводит пользователь
                }
            }
            //Сообщаем максимально число для игры
            Console.WriteLine($"Загаданно число {count} Максимальное число для вычитания от 1 до 4");
            #endregion

            #region Изменяем параметры вычитания
            Console.WriteLine("Хотите изменить максимальное число вычитания? (По умолчанию max = 4)?" +
                "\n\t 1 - изменить число\n\t 2 - по умолчанию max = 4");
            int numEdit = Int32.Parse(Console.ReadLine());
            if (numEdit == 1)
            {
                Console.WriteLine("Укажите максимальное число (Не менее 4 и не более 32)");
                numberMax = Int32.Parse(Console.ReadLine());
                if (numberMax > 32 || numberMax < 4)
                {
                    while (numberMax > 32 || numberMax < 4)
                    {
                        Console.WriteLine("Укажите максимальное число (Не менее 4 и не более 32)");
                        numberMax = Int32.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                numberMax = 4; ;
            }
            #endregion

            switch (player)
            {
                //Запуск игры для 2х игроков
                case 2:
                    #region Подготовка 2х игроков
                    Console.WriteLine("Игрок 1 введите имя:");
                    user1 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Игрок 2 введите имя:");
                    user2 = Convert.ToString(Console.ReadLine());
                    #endregion

                    while (true)
                    {
                        #region Ход игрока user1
                        Console.WriteLine($"Ход {user1}! Число {count}");
                        //Проверка на ввод от 1 до 4 включительно
                        int userTry1 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                        if (userTry1 > numberMax || userTry1 <= 0)
                        {
                            while (userTry1 > numberMax || userTry1 <= 0)
                            {
                                Console.WriteLine("Введите число от 1 до 4");
                                userTry1 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                            }
                        }
                        count -= userTry1; //Отнимаем число пользователя от основного числа
                        if (count <= 0)
                        {
                            Console.WriteLine($"{user1} позравляю с победой!");
                            break;
                        }
                        #endregion

                        #region Ход игрока user2
                        Console.WriteLine($"Ход {user2}! Число {count}");
                        //Проверка на ввод от 1 до 4 включительно
                        int userTry2 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                        if (userTry2 > numberMax || userTry2 <= 0)
                        {
                            while (userTry2 > numberMax || userTry2 <= 0)
                            {
                                Console.WriteLine("Введите число от 1 до 4");
                                userTry2 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                            }
                        }
                        count -= userTry2; //Отнимаем число пользователя от основного числа
                        if (count <= 0)
                        {
                            Console.WriteLine($"{user2} поздравляю с победой!");
                            break;
                        }
                        #endregion
                    }
                    break;

                //Запуск игры для 3 игрока
                case 3:
                    #region Подготовка 3х игроков
                    Console.WriteLine("Игрок 1 введите имя:");
                    user1 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Игрок 2 введите имя:");
                    user2 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Игрок 3 введите имя:");
                    user3 = Convert.ToString(Console.ReadLine());
                    #endregion

                    while (true)
                    {
                        #region Ход игрока user1
                        Console.WriteLine($"Ход {user1}! Число {count}");
                        //Проверка на ввод от 1 до 4 включительно
                        int userTry1 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                        if (userTry1 > numberMax || userTry1 <= 0)
                        {
                            while (userTry1 > numberMax || userTry1 <= 0)
                            {
                                Console.WriteLine("Введите число от 1 до 4");
                                userTry1 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                            }
                        }
                        count -= userTry1; //Отнимаем число пользователя от основного числа
                        if (count <= 0)
                        {
                            Console.WriteLine($"{user1} поздравляю с победой!");
                            break;
                        }
                        #endregion

                        #region Ход игрока user2
                        Console.WriteLine($"Ход {user2}! Число {count}");
                        //Проверка на ввод от 1 до 4 включительно
                        int userTry2 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                        if (userTry2 > numberMax || userTry2 <= 0)
                        {
                            while (userTry2 > numberMax || userTry2 <= 0)
                            {
                                Console.WriteLine("Введите число от 1 до 4");
                                userTry2 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                            }
                        }
                        count -= userTry2; //Отнимаем число пользователя от основного числа
                        if (count <= 0)
                        {
                            Console.WriteLine($"{user2} поздравляю с победой!");
                            break;
                        }
                        #endregion

                        #region Ход игрока user3
                        Console.WriteLine($"Ход {user3}! Число {count}");
                        //Проверка на ввод от 1 до 4 включительно
                        int userTry3 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                        if (userTry3 > numberMax || userTry3 <= 0)
                        {
                            while (userTry3 > numberMax || userTry3 <= 0)
                            {
                                Console.WriteLine("Введите число от 1 до 4");
                                userTry2 = Int32.Parse(Console.ReadLine());  //Ввод пользовательского числа
                            }
                        }
                        count -= userTry3; //Отнимаем число пользователя от основного числа
                        if (count <= 0)
                        {
                            Console.WriteLine($"{user3} поздравляю с победой!");
                            break;
                        }
                        #endregion
                    }

                    break;
            }
            #region Возврат в меню
            Console.WriteLine("\n\tДля возврата в предыдущее меню нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            GameMenu();
            #endregion
        }

    }
}
