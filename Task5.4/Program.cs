using System;
using System.Collections.Generic;

namespace Task5._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int keyOfDictionary = 0;
            Dictionary<int, string> fullName = new Dictionary<int, string>();
            Dictionary<int, string> job = new Dictionary<int, string>();

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню: \n1.Добавить досье. \n2.Вывести досье. \n3.Удалить досье.\n4.Выход.");
                int state = int.Parse(Console.ReadLine());

                switch (state)
                {
                    case 1:
                        AddFile(fullName, keyOfDictionary, "Введите ФИО:");
                        AddFile(job, keyOfDictionary, "Введите должность:");
                        keyOfDictionary++;
                        break;
                    case 2:
                        ViewFile(fullName, job);
                        break;
                    case 3:
                        DeleteFile(ref fullName, ref job);
                        break;
                    case 4:
                        isWork = false;
                        break;

                }

                Console.WriteLine();
            }
        }

        static Dictionary<int, string> AddFile(Dictionary<int, string> dictionary, int keyOfDictionary, string text)
        {
            Console.WriteLine(text);
            string input = Console.ReadLine();
            dictionary.Add(keyOfDictionary, input);
            return dictionary;
        }

        static void ViewFile(Dictionary<int, string> fullName, Dictionary<int, string> job)
        {
            Console.WriteLine("Все досье:");
            int keyOfDictionary = 0;

            for (int i = 0; i < fullName.Count; i++)
            {
                Console.WriteLine($"{keyOfDictionary + 1}.{fullName[keyOfDictionary]} - {job[keyOfDictionary]}");
                keyOfDictionary++;
            }
        }

        static void DeleteFile(ref Dictionary<int, string> fullName, ref Dictionary<int, string> job)
        {
            Console.WriteLine("Введите номер досье по индексу:");
            int deletingKeyOfDictionary = int.Parse(Console.ReadLine()) - 1;
            bool contains = fullName.ContainsKey(deletingKeyOfDictionary);

            if (contains)
            {
                DeleteByKey(fullName, deletingKeyOfDictionary);
                DeleteByKey(job, deletingKeyOfDictionary);
                Console.WriteLine("Досье успешно удаленно!");
            }
            else
            {
                Console.WriteLine("Такого досье нет!");
            }
        }

        static Dictionary<int, string> DeleteByKey(Dictionary<int, string> dictionary, int deletingKeyOfDictionary)
        {
            dictionary.Remove(deletingKeyOfDictionary);
            return dictionary;
        }
    }
}
