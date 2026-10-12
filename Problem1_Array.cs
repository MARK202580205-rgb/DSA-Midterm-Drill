using System;

namespace Problem1
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
        static Student[] students = new Student[10];
        static int studentCount = 0;

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT RECORD MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
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
                    DisplayAll();
                }
                else if (choice == 3)
                {
                    SearchStudent();
                }
                else if (choice == 4)
                {
                    UpdateStudent();
                }
                else if (choice == 5)
                {
                    DeleteStudent();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Program exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

                Console.WriteLine();
            } while (choice != 6);
        }

        static int FindStudent(string number)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == number)
                {
                    return i;
                }
            }
            return -1;
        }

        static int ReadYearLevel()
        {
            int year;
            Console.Write("Enter Year Level: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 4)
            {
                Console.Write("Year level must be 1, 2, 3, or 4. Enter again: ");
            }
            return year;
        }

        static void AddStudent()
        {
            if (studentCount == 10)
            {
                Console.WriteLine("Cannot add more students. The list is full.");
                return;
            }

            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine();

            if (FindStudent(number) != -1)
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
            s.YearLevel = ReadYearLevel();

            students[studentCount] = s;
            studentCount++;
            Console.WriteLine("Student added successfully!");
        }

        static void PrintStudent(Student s)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }

        static void DisplayAll()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT RECORDS");
            Console.WriteLine("========================================");

            if (studentCount == 0)
            {
                Console.WriteLine("No student records yet.");
                return;
            }

            for (int i = 0; i < studentCount; i++)
            {
                PrintStudent(students[i]);
                Console.WriteLine();
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            int index = FindStudent(Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                Console.WriteLine("Student Found!");
                PrintStudent(students[index]);
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            int index = FindStudent(Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new Name: ");
            students[index].Name = Console.ReadLine();
            Console.Write("Enter new Program: ");
            students[index].Program = Console.ReadLine();
            students[index].YearLevel = ReadYearLevel();
            Console.WriteLine("Student updated successfully!");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            int index = FindStudent(Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            for (int i = index; i < studentCount - 1; i++)
            {
                students[i] = students[i + 1];
            }
            studentCount--;
            Console.WriteLine("Student deleted successfully!");
        }
    }
}
