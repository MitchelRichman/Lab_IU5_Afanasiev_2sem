//using System;
///*Домашнее задание 6.1 Написать программу, вычисляющую среднюю
//температуру за год из набора, введенного пользователем. Значения температур
//за каждый месяц необходимо сохранить в одномерный массив. Написать
//функцию, которая по данному массиву вычисляет среднюю температуру и
//возвращает среднее значение.*/

//using System;

//class TemperatureCalculator
//{
//    // Функция вычисления средней температуры
//    static double CalculateAverageTemperature(double[] temperatures)
//    {
//        double sum = 0;
//        for (int i = 0; i < temperatures.Length; i++)
//        {
//            sum += temperatures[i];
//        }
//        return sum / temperatures.Length;
//    }

//    static void Main()
//    {
//        // Массив для хранения температур по месяцам
//        double[] monthlyTemperatures = new double[12];

//        // Названия месяцев для удобства
//        string[] monthNames = {
//            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
//            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
//        };

//        Console.WriteLine("Введите среднемесячные температуры за год:\n");

//        // Ввод температур для каждого месяца
//        for (int i = 0; i < 12; i++)
//        {
//            Console.Write($"{monthNames[i]}: ");
//            monthlyTemperatures[i] = double.Parse(Console.ReadLine());
//        }

//        // Вычисление средней температуры
//        double averageTemp = CalculateAverageTemperature(monthlyTemperatures);

//        // Вывод результата
//        Console.WriteLine($"\nСредняя температура за год: {averageTemp:F2}°C");
//    }
//}