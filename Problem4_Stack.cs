using System;
using System.Collections.Generic;

namespace Problem4
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }

    class Program
    {
        static Student[] students = new Student[10];
        static int studentCount = 0;
        static Stack<Operation> operationHistory = new Stack<Operation>();

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT RECORDS AND OPERATION HISTORY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. View Operation History");
                Console.WriteLine("6. View Last Operation");
                Console.WriteLine("7. Remove Last Operation");
                Console.WriteLine("8. Exit");
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
                    UpdateStudent();
                }
                else if (choice == 3)
                {
                    DeleteStudent();
                }
                else if (choice == 4)
                {
                    DisplayAll();
                }
                else if (choice == 5)
                {
                    ViewHistory();
                }
                else if (choice == 6)
                {
                    ViewLastOperation();
                }
                else if (choice == 7)
                {
                    RemoveLastOperation();
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Program exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

                Console.WriteLine();
            } while (choice != 8);
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

        static void RecordOperation(string action, Student s)
        {
            Operation op = new Operation();
            op.Action = action;
            op.StudentNumber = s.StudentNumber;
            op.StudentName = s.Name;
            operationHistory.Push(op);
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

            RecordOperation("Added", s);
            Console.WriteLine("Student added successfully!");
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

            RecordOperation("Updated", students[index]);
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

            Student removed = students[index];

            for (int i = index; i < studentCount - 1; i++)
            {
                students[i] = students[i + 1];
            }
            studentCount--;

            RecordOperation("Deleted", removed);
            Console.WriteLine("Student deleted successfully!");
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
                Console.WriteLine("Student Number: " + students[i].StudentNumber);
                Console.WriteLine("Name: " + students[i].Name);
                Console.WriteLine("Program: " + students[i].Program);
                Console.WriteLine("Year Level: " + students[i].YearLevel);
                Console.WriteLine();
            }
        }

        static void ViewHistory()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No operations recorded.");
                return;
            }

            Console.WriteLine("OPERATION HISTORY");
            Operation[] ops = operationHistory.ToArray();
            int count = 1;
            for (int i = ops.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(count + ". " + ops[i].Action + " " + ops[i].StudentName);
                count++;
            }
        }

        static void ViewLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No operations recorded.");
                return;
            }

            Operation last = operationHistory.Peek();
            Console.WriteLine("Last Operation: " + last.Action + " " + last.StudentName);
        }

        static void RemoveLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No operations recorded.");
                return;
            }

            operationHistory.Pop();
            Console.WriteLine("Last operation removed successfully!");
        }
    }
}
