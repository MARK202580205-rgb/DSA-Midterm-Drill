using System;
using System.Collections.Generic;

namespace Problem2
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Program
    {
        static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = 0;
                }

                if (choice == 1)
                {
                    AddStudent();
                }
                else if (choice == 2)
                {
                    SearchStudent();
                }
                else if (choice == 3)
                {
                    DisplayAll();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Program exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

                Console.WriteLine();
            } while (choice != 4);
        }

        static void PrintStudent(Student s)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }

        static void AddStudent()
        {
            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine();

            if (studentDictionary.ContainsKey(number))
            {
                Console.WriteLine("Student Number already exists.");
                return;
            }

            Student s = new Student();
            s.StudentNumber = number;
            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine();

            int year;
            Console.Write("Enter Year Level: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 4)
            {
                Console.Write("Year level must be 1, 2, 3, or 4. Enter again: ");
            }
            s.YearLevel = year;

            studentDictionary.Add(number, s);
            Console.WriteLine("Student added successfully!");
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string number = Console.ReadLine();

            if (studentDictionary.TryGetValue(number, out Student found))
            {
                Console.WriteLine("Student Found!");
                PrintStudent(found);
            }
            else
            {
                Console.WriteLine("Student Number not found.");
            }
        }

        static void DisplayAll()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT RECORDS");
            Console.WriteLine("========================================");

            if (studentDictionary.Count == 0)
            {
                Console.WriteLine("No student records yet.");
                return;
            }

            foreach (KeyValuePair<string, Student> item in studentDictionary)
            {
                PrintStudent(item.Value);
                Console.WriteLine();
            }
        }
    }
}
