// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество операций (от 2 до 40):");
        int n = int.Parse(Console.ReadLine());

        if (n < 2 || n > 40)
        {
            Console.WriteLine("Неверное количество операций!");
            return;
        }

        string[] names = new string[n];
        double[] prices = new double[n];

        // Ввод данных
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите название товара/услуги для операции {i + 1}:");
            names[i] = Console.ReadLine();

            Console.WriteLine($"Введите сумму для операции {i + 1} (в рублях):");
            prices[i] = double.Parse(Console.ReadLine());
        }

        int choice;
        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика (среднее, максимальное, минимальное, сумма)");
            Console.WriteLine("3. Сортировка по цене (пузырьковая сортировка)");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт меню: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nСписок трат:");
                    for (int i = 0; i < n; i++)
                        Console.WriteLine($"{names[i]} - {prices[i]} руб.");
                    break;

                case 2:
                    double sum = 0;
                    double max = prices[0];
                    double min = prices[0];

                    for (int i = 0; i < n; i++)
                    {
                        sum += prices[i];
                        if (prices[i] > max) max = prices[i];
                        if (prices[i] < min) min = prices[i];
                    }
                    double avg = sum / n;

                    Console.WriteLine($"\nСумма: {sum} руб.");
                    Console.WriteLine($"Среднее: {avg:F2} руб.");
                    Console.WriteLine($"Максимум: {max} руб.");
                    Console.WriteLine($"Минимум: {min} руб.");
                    break;

                case 3:
                    
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = 0; j < n - i - 1; j++)
                        {
                            if (prices[j] > prices[j + 1])
                            {
                              
                                double tempPrice = prices[j];
                                prices[j] = prices[j + 1];
                                prices[j + 1] = tempPrice;

                                string tempName = names[j];
                                names[j] = names[j + 1];
                                names[j + 1] = tempName;
                            }
                        }
                    }
                    Console.WriteLine("\nДанные отсортированы по цене (возрастание).");
                    break;

                case 4:
                    Console.WriteLine("\nВведите курс для конвертации:");
                    double rate = double.Parse(Console.ReadLine());

                    Console.WriteLine("Список трат в другой валюте:");
                    for (int i = 0; i < n; i++)
                        Console.WriteLine($"{names[i]} - {(prices[i] * rate):F2}");
                    break;

                case 5:
                    Console.WriteLine("\nВведите название для поиска:");
                    string search = Console.ReadLine().ToLower();
                    bool found = false;

                    for (int i = 0; i < n; i++)
                    {
                        if (names[i].ToLower().Contains(search))
                        {
                            Console.WriteLine($"{names[i]} - {prices[i]} руб");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Ничего не найдено");
                    break;

                case 0:
                    Console.WriteLine("Выход из программы");
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }

        } while (choice != 0);
    }
}