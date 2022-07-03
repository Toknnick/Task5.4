using System;
using System.Collections.Generic;

namespace Task5._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int index = 0;
            List<string> fullName = new List<string>();
            List<string> job = new List<string>();

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню: \n1.Добавить досье. \n2.Вывести досье. \n3.Удалить досье.\n4.Выход.");
                string state = Console.ReadLine();

                switch (state)
                {
                    case "1":
                        AddFile(fullName, job);
                        index++;
                        break;
                    case "2":
                        ViewFile(fullName, job);
                        break;
                    case "3":
                        DeleteFile(fullName, job);
                        break;
                    case "4":
                        isWork = false;
                        break;

                }

                Console.WriteLine();
            }
        }

        static void AddFile(List<string> fullName, List<string> job)
        {
            AddList(fullName, "Введите ФИО:");
            AddList(job, "Введите должность:");
        }

        static void ViewFile(List<string> fullName, List<string> job)
        {
            Console.WriteLine("Все досье:");
            int index = 0;

            for (int i = 0; i < fullName.Count; i++)
            {
                Console.WriteLine($"{index + 1}.{fullName[index]} - {job[index]}");
                index++;
            }
        }
        
        static void DeleteFile(List<string> fullName, List<string> job)
        {
            Console.WriteLine("Введите номер досье по индексу:");
            int index = int.Parse(Console.ReadLine()) - 1;
            ReplacePlaceInList(fullName, index);
            ReplacePlaceInList(job, index);
            fullName.RemoveAt(index);
            job.RemoveAt(index);
            Console.WriteLine("Досье успешно удаленно!");

            if (index > fullName.Count)
            {
                Console.WriteLine("Такого досье нет!");
            }
        }

        static void ReplacePlaceInList(List<string> someList, int index)
        {
            someList[index] = someList[index + 1];
        }

        static void AddList(List<string> list, string text)
        {
            Console.WriteLine(text);
            string input = Console.ReadLine();
            list.Add(input);
        }
    }
}
