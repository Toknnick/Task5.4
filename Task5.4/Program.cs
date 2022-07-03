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
            Dictionary<int, string> fullNames = new Dictionary<int, string>();
            Dictionary<int, string> jobs = new Dictionary<int, string>();

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню: \n1.Добавить досье. \n2.Вывести досье. \n3.Удалить досье.\n4.Выход.");
                string state = Console.ReadLine();

                switch (state)
                {
                    case "1":
                        AddFile(fullNames, jobs, keyOfDictionary, "Введите ФИО:", "Введите должность:");
                        keyOfDictionary++;
                        break;
                    case "2":
                        ViewFile(fullNames, jobs);
                        break;
                    case "3":
                        DeleteFile(fullNames, jobs);
                        break;
                    case "4":
                        isWork = false;
                        break;

                }

                Console.WriteLine();
            }
        }

        static void AddFile(Dictionary<int, string> fullNames, Dictionary<int, string> jobs, int keyOfDictionary, string text1, string text2)
        {
            AddDictionary(fullNames, keyOfDictionary, text1);
            AddDictionary(jobs, keyOfDictionary, text2);
        }

        static void ViewFile(Dictionary<int, string> fullNames, Dictionary<int, string> jobs)
        {
            Console.WriteLine("Все досье:");
            int keyOfDictionary = 0;

            for (int i = 0; i < fullNames.Count; i++)
            {
                Console.WriteLine($"{keyOfDictionary + 1}.{fullNames[keyOfDictionary]} - {jobs[keyOfDictionary]}");
                keyOfDictionary++;
            }
        }

        static void DeleteFile(Dictionary<int, string> fullNames, Dictionary<int, string> jobs)
        {
            Console.WriteLine("Введите номер досье по индексу:");
            int deletingKeyOfDictionary = int.Parse(Console.ReadLine()) - 1;
            bool contains = fullNames.ContainsKey(deletingKeyOfDictionary);

            if (contains)
            {
                DeleteDictionarys(fullNames, jobs, deletingKeyOfDictionary);
                Console.WriteLine("Досье успешно удаленно!");
            }
            else
            {
                Console.WriteLine("Такого досье нет!");
            }
        }
        static void DeleteDictionarys(Dictionary<int, string> fullNames, Dictionary<int, string> jobs, int deletingKeyOfDictionary)
        {
            if (deletingKeyOfDictionary == fullNames.Count - 1)
            {
                DeleteByKey(fullNames, jobs, deletingKeyOfDictionary);
            }
            else
            {
                DeleteByKey(fullNames, jobs, deletingKeyOfDictionary);
                RemoveDictionarys(fullNames, jobs, deletingKeyOfDictionary);
                DeleteByKey(fullNames, jobs, deletingKeyOfDictionary + 1);
            }
        }

        static void RemoveDictionarys(Dictionary<int, string> fullNames, Dictionary<int, string> jobs, int deletingKeyOfDictionary)
        {
            fullNames[deletingKeyOfDictionary] = fullNames[deletingKeyOfDictionary + 1];
            jobs[deletingKeyOfDictionary] = jobs[deletingKeyOfDictionary + 1];
        }

        static void DeleteByKey(Dictionary<int, string> fullNames, Dictionary<int, string> jobs, int deletingKeyOfDictionary)
        {
            fullNames.Remove(deletingKeyOfDictionary);
            jobs.Remove(deletingKeyOfDictionary);
        }

        static void AddDictionary(Dictionary<int, string> dictionary, int keyOfDictionary, string text)
        {
            Console.WriteLine(text);
            string input = Console.ReadLine();
            dictionary.Add(keyOfDictionary, input);
        }
    }
}
