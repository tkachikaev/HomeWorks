using System;

namespace Modul2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Переменные для заполнения Записной книжки
            string firstName = "Timur";   // Name
            int age = 30;                 // Age
            float height = 1.72f;         // Рост в метрах
            double disciplineHis = 80f;   // История
            double disciplineMat = 70f;   // Математика
            double disciplineRus = 85f;   // Русский
            double disciplineAverage;     // Средний бал трех дисциплин

            //////////Титут////////
            Console.ForegroundColor = ConsoleColor.Yellow;  // Цвет текста
            string titleName = "Записная книжка";           // Текст 
            Console.SetCursorPosition((Console.WindowWidth /2 - titleName.Length), Console.WindowHeight /2 -4); // Делим ширину и высоту 2.
                                                                                                                // -4 количество строк.
            Console.WriteLine(titleName);                   //
            Console.ForegroundColor = ConsoleColor.White;   // Исходный цвет
            ///////////////////////

            #region //Вычисляем средний бал 3х дисциплин
            disciplineAverage = (disciplineHis + disciplineMat + disciplineRus) / 3; // Делим на кол-во переменных.
            #endregion

            #region //Заготовка ткста в переменной pattern
            string pattern ="Имя: {0} Возраст: {1} Рост: {2} Средний балл: {3}"; // Используем в Вывод 2
            Console.SetCursorPosition((Console.WindowWidth / 2 - (pattern.Length - firstName.Length) / 2), Console.CursorTop); //     Высота и иширина на 2.
                                                                                                       
            #endregion

            #region //Вывод 1
            Console.WriteLine(firstName +" "+ age +" "+height+" "+ disciplineAverage.ToString("##.##")); //("##.##") Для красивого отображения
            Console.ReadKey();
            #endregion

            #region //Вывод 2 используем string pattern 
            Console.SetCursorPosition((Console.WindowWidth / 2 - pattern.Length / 2), Console.CursorTop); //     Высота и иширина на 2.
            Console.WriteLine(pattern,
                firstName,
                age,
                height,
                disciplineAverage.ToString("##.##"));//("##.##") Для красивого отображения
            Console.ReadKey();
            #endregion

            #region //Вывод 4 По центру
            Console.SetCursorPosition((Console.WindowWidth / 2 - pattern.Length / 2), Console.CursorTop); //     Высота и иширина на 2.
            Console.WriteLine(pattern,
                firstName,
                age,
                height,
                disciplineAverage.ToString("##.##"));//("##.##") Для красивого отображения);
            Console.ReadKey();
            #endregion

            #region //Вывод 3 $"..."
            Console.SetCursorPosition((Console.WindowWidth / 2 - pattern.Length / 2), Console.CursorTop); //     Высота и иширина на 2.
            Console.WriteLine($"Имя: {firstName} Возраст: {age} Рост: {height} Средний балл: {disciplineAverage.ToString("##.##")}");
            Console.ReadKey();
            #endregion
        }
    }
}
