using System;

namespace HomeWork5
{
    class Program
    {

        #region Методы для работы с матрицами
        /// <summary>
        /// Метод, принимающий двумерну матрицу и число, возвращающий матрицу умноженную на число
        /// </summary>
        /// <param name="Array"> Массив</param>
        /// <param name="a">Число на которое будет умножен массив</param>
        static int[,] MatrixMultiplication(int[,] Array, int a)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] *= a;
                }
            }
            return Array;
        }

        /// <summary>
        /// Метод, принимающий две матрицы, возвращающий их произведение
        /// Строка Array1 должна иметь столько же эллементов сколько
        /// элементов в столбце matrix2
        /// </summary>
        /// <param name="Array1">Матрица 1</param>
        /// <param name="Array2">Матрица 2</param>
        static int[,] MatrixMultiplication(int[,] Array1, int[,] Array2)
        {
            int[,] arrayResult = new int[Array1.GetLength(0), Array2.GetLength(1)];

                for (int i = 0; i < Array1.GetLength(0); i++) //Идем по строке первой матрицы
                {
                    for (int j = 0; j < Array2.GetLength(1); j++)//Идем по столбцу второй матрицы матрицы
                    {
                        for (int k = 0; k < Array2.GetLength(0); k++)
                        {
                            arrayResult[i, j] += Array1[i, k] * Array2[k, j];
                        }
                    }
                }

            return arrayResult;
        }

        /// <summary>
        /// Метод, принимающий две двумерные матрицы, Сложение матриц принимает в мебя первая указанная матрица в методе
        /// </summary>
        /// <param name="Array1">Матрица 1</param>
        /// <param name="Array2">Матрица 2</param>
        static void MatrixAddition(int[,] Array1, int[,] Array2)
        {
            try
            {
                for (int i = 0; i < Array1.GetLength(0); i++)
                {
                    for (int j = 0; j < Array1.GetLength(1); j++)
                    {
                        Array1[i, j] += Array2[i, j];
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Строки и столбцы матриц не совпадают по кол-ву эл-ов\n" +
                    "Нажмите любую кнопку для закрытия программы и исправления ошибки");
                Console.ForegroundColor = ConsoleColor.White;

                Environment.Exit(0);
            }
            
        }

        /// <summary>
        /// Рапечатать одномерный массив
        /// </summary>
        /// <param name="Array"></param>
        static void MatrixPrint(int[] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                    Console.Write($"{Array[i]}\t ");
            }
        }

        /// <summary>
        /// Рапечатать двумерный массив
        /// </summary>
        /// <param name="Array"></param>
        static void MatrixPrint(int[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write($"{Array[i, j]}\t ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Рапечатать одномерный массив
        /// </summary>
        /// <param name="Array"></param>
        static void MatrixPrint(string[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write($"{Array[i]}, ");
            }
        }

        /// <summary>
        /// Метод заполняющий массив
        /// </summary>
        /// <param name="Array">Массив</param>
        /// <param name="min">От</param>
        /// <param name="max">До N числа +1</param>
        static void MatrixFill(int[,] Array, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] = random.Next(min, max);
                }
            }
        }

        /// <summary>
        /// Метод заполняющий два массива
        /// </summary>
        /// <param name="Array1">Массив</param>
        /// <param name="Array1">Массив</param>
        /// <param name="min">От</param>
        /// <param name="max">До N числа +1</param>
        static void MatrixFill(int[,] Array1, int[,] Array2, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int j = 0; j < Array1.GetLength(1); j++)
                {
                    Array1[i, j] = random.Next(min, max);
                }
            }
            for (int i = 0; i < Array2.GetLength(0); i++)
            {
                for (int j = 0; j < Array2.GetLength(1); j++)
                {
                    Array2[i, j] = random.Next(min, max);
                }
            }
        }

        #endregion

        #region Методы для работы с текстом

        /// <summary>
        /// Метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string TextMinWord (string text)
        {
            string[] word = text.Split(' '); //Разделяем строку в масив по пробелам
            int minIndex = word[0].Length; //Сверяем строки с начальной, будут ли длинее (Счетчик)
            string wordMin = word[0]; //Временно запишем 0 индекс

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Length < minIndex) //Чекаем от I индекса и дальше
                {
                    minIndex = word[i].Length; //Нашли меньше, ищем дальше
                    wordMin = word[i]; //Выводим наименьшее
                }
            }
            return wordMin; //Возврат

        }

        /// <summary>
        /// Метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
        /// </summary>
        /// <param name="text">Строка со словами</param>
        /// <param name="num">Кол-во слов для вывода</param>
        /// <returns></returns>
        static string[] TextMaxWord(string text, int num)
        {
            string[] word = text.Split(' ');

            //int indexMin = 0;
            int indexMax = 0;
            string[] wordMax = new string[num];

            #region Записываем в wordMax самы длинные слова  
            for (int i = 0; i < wordMax.Length; i++)
            {
                #region Находим длинное слово
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j].Length > indexMax)
                    {
                        indexMax = word[j].Length; //Потом очистим для нового поиска
                        wordMax[i] = word[j];
                    }

                }
                #endregion

                #region Удаляем длинное слово из первоначального массива, сбрасываем счетчик
                for (int j = 0; j < word.Length; j++)
                {
                    if (indexMax == word[j].Length)
                    {
                        word[j] = " ";
                        indexMax = 0; //Можно выставить word[j] = " "
                    }
                }
                #endregion
                
            }
            #endregion

            return wordMax; //Возвращаем массив


        }

        /// <summary>
        /// Метод, в котором
        /// удалены все кратные рядом стоящие символы, оставив по одному
        /// Прииивввеееттттт => Привет
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string TexRemoveLetters(string text)
        {
            
            string newText = text;

            for (int i = 1; i < newText.Length; i++)
            {
                if (newText[i] == newText[i - 1]) // Проверем предыдущий элемент
                {
                    newText = newText.Remove(i - 1, 1); //Удаляем элемент (Предыдущий)
                    i -= 1; //Понижаем для точной отработки
                }
            }
            return newText;

        }

        /// <summary>
        /// Метод возвращает строку с информацией о прогрессии (Гео-ая. Арфе-ая).
        /// Метод не сообщает о пропущенных n позициях. числовая последовательность должна быть строго указана.
        /// Пример: 2 4 6 8... 2 4 16 256... 10 20 30 40 50... и.т.д.
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        static string MathProgres(int[] Array)
        {
            int num;
            num = Array[1] - Array[0]; //Выявляем число для Ар.Пос. Число всегда фиксированно

            string massage = " ";

            for (int i = 1; i < Array.Length; i++)
            {    
                //num = Array[i] - Array[i - 1];
                if (Array[i] - Array[i-1] == num) //Проверяем с фиксированным числом
                {
                    massage = $"Это арефмитическая последовательность. Число увеличивается на {num}";
                }
                else if (Array[i - 1] * Array[i - 1] == Array[i]) //Проверяем на умножение Гео.Посл.
                {
                    massage = "Это Геометрическая последовательность.";
                }
                else
                {
                    massage = "Числовая последовательность не определенна, введите послеодовательность по порядку" +
                              "\nПример: 2 4 6 8 10 12... или 2 4 16...";
                }
            }
            
            return massage;
        }



        #endregion


        /// <summary>
        /// Вычислить, используя рекурсию, функцию Аккермана:
        /// A(2, 5), A(1, 2)
        /// A(n, m) = m + 1, если n = 0,
        /// = A(n - 1, 1), если n <> 0, m = 0,
        /// = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int A(int n, int m) //Можно так называть методы? 
        {
            // Сделал по формуле, по правде даже не пойму какой должен быть незультат.
            if (n == 0) return m + 1; //A(n, m) = m + 1, если n = 0,
            if (m == 0) return A(n - 1, m); //= A(n - 1, 1), если n <> 0, m = 0,
            return A(n - 1, A(n, m - 1)); //A(n - 1, A(n, m - 1)), если n> 0, m > 0
        }

        #region Визуальная составляющая
        /// <summary>
        /// Пауза - Очистка
        /// </summary>
        static void LessonNext()
        {
            Console.WriteLine("Нажмите любую клавишу для перехода в следующий пример");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion


        static void Main(string[] args)
        {
            Lesson1();
            Lesson2();
            Lesson3();
            Lesson4();
            Lesson5();
        }




        /// <summary>
        /// Задание 1.
        /// </summary>
        static void Lesson1()
        {
            #region 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
            Console.WriteLine("Lesson 1.1");
            ///////////////
            int num = 3; // - Число для умножения настраивать здесь
            ///////////////
            int[,] matrix_1_1 = new int[3, 3];
            MatrixFill(matrix_1_1, 1, 6);
            Console.WriteLine("Matrix Default:");
            MatrixPrint(matrix_1_1);
            Console.WriteLine();
            MatrixMultiplication(matrix_1_1, 2);
            Console.WriteLine($"Матрица умнженная на число: Matrix_1_1 = Matrix_1_1 * {num}");
            MatrixPrint(matrix_1_1);
            Console.WriteLine();
            LessonNext();
            #endregion

            #region 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
            Console.WriteLine("Lesson 1.2");
            int[,] matrix_1 = new int[3, 5];
            int[,] matrix_2 = new int[3, 5];
            MatrixFill(matrix_1, matrix_2, 1, 6);
            Console.WriteLine("Matrix_1 Default:");
            MatrixPrint(matrix_1);
            Console.WriteLine();
            Console.WriteLine("Matrix_2 Default:");
            MatrixPrint(matrix_2);
            Console.WriteLine();
            MatrixAddition(matrix_1, matrix_2); // Результак сложения сохранен в Matrix1 (В описании метода сказанно)
            Console.WriteLine($"Результат сложений матриц: matrix_1 = matrix_1 + matrix_2");
            MatrixPrint(matrix_1);
            LessonNext(); // Чистка окна
            #endregion

            #region 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
            // P.S.
            // Строка matrix1  должна иметь столько же эллементов сколько
            // элементов в столбце matrix2. Можно ограничить при пользовательском вводе, 
            // но я не пойму как сообщить об ошибке из метода.
            Console.WriteLine("Lesson 1.3");
            int[,] matrix1 = new int[6, 3]; 
            int[,] matrix2 = new int[3, 6];
            MatrixFill(matrix1, matrix2, 1, 6);
            Console.WriteLine("Matrix1 Default:");
            MatrixPrint(matrix1);
            Console.WriteLine();
            Console.WriteLine("Matrix2 Default:");
            MatrixPrint(matrix2);
            Console.WriteLine();
            Console.WriteLine($"Результат умножения матриц: result = matrix1 + matrix2");  
            MatrixPrint(MatrixMultiplication(matrix1, matrix2)); //Метод возвращает новую матрицу result.
            LessonNext();
            #endregion
        }

        /// <summary>
        /// Задание 2.
        /// </summary>
        static void Lesson2()
        {
            #region 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
            // P.S.
            // Не пойму почему не обрабатываются русские слова, возможно из за моей версии Виндоувс. EN
            Console.WriteLine("Lesson 2.1");
            Console.WriteLine("Введите строку слов для вывода минимального слова: ");
            string textMin = Console.ReadLine();
            Console.WriteLine("Самое короткое слово:");
            Console.WriteLine(TextMinWord(textMin));
            LessonNext();

            #endregion

            #region 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
            //Опять проблема с русскими словами
            //Но у меня и посказки на ангийском :)
            Console.WriteLine("Lesson 2.*");
            int num = 0; //Кол-во слов вывода, будет запрос
            Console.WriteLine("Введите строку слов для вывода максимального слова (Можно несколько слов)");
            string textMax = Console.ReadLine();
            Console.WriteLine("Сколько слов высести");
            num = Int32.Parse(Console.ReadLine());
            string[] wordsMax = new string[num];
            wordsMax = TextMaxWord(textMax, num);
            Console.WriteLine("Самые длинные слова:");
            Console.WriteLine();
            MatrixPrint(wordsMax);
            Console.WriteLine();
            LessonNext();

            #endregion

        }

        /// <summary>
        /// Задание 3
        /// </summary>
        static void Lesson3()
        {
            #region 3. Создать метод, принимающий текст. Результатом работы метода должен быть новый текст, в котором удалены все кратные рядом стоящие символы, оставив по одному
            Console.WriteLine("Lesson 3.");
            Console.WriteLine("Введите текст с лишними буквами:");
            string text3 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Удалены повторяющиеся эллементы:");
            Console.WriteLine(TexRemoveLetters(text3));
            Console.WriteLine();
            LessonNext();

            #endregion
        }

        /// <summary>
        /// Задание 4.
        /// </summary>
        static void Lesson4()
        {
            Console.WriteLine("Lesson 4.");
            int count;
            Console.WriteLine("Введите числовую последовательность для определения прггрессии: " +
                              "\nКакое кол-во цифр вы хотите ввести?");
            count = int.Parse(Console.ReadLine());
            int[] numArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите {i + 1}-ое число, нажмите Enter:");
                int num = int.Parse(Console.ReadLine());
                numArray[i] = num;
            }

            string result = MathProgres(numArray);
            Console.WriteLine(result);
            Console.WriteLine();
            LessonNext();
        }

        /// <summary>
        ///  *Задание 5.
        /// </summary>
        static void Lesson5()
        {
            Console.WriteLine("Lesson 5");
            Console.WriteLine(A(2, 5));
            Console.WriteLine(A(1, 2));
        }
    }
}

/// Доделать защиту от ввода
/// Навести марафет
/// Цвета?
/// Аккарман не могу понять для чего он... 