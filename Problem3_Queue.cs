using System;
using System.Collections.Generic;

namespace Problem3
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Program
    {
        static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT REQUEST QUEUE");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = 0;
                }

                if (choice == 1)
                {
                    AddRequest();
                }
                else if (choice == 2)
                {
                    ViewRequests();
                }
                else if (choice == 3)
                {
                    ProcessRequest();
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

        static void AddRequest()
        {
            StudentRequest req = new StudentRequest();
            Console.Write("Enter Student Number: ");
            req.StudentNumber = Console.ReadLine();
            Console.Write("Enter Student Name: ");
            req.StudentName = Console.ReadLine();
            Console.Write("Enter Request Type: ");
            req.RequestType = Console.ReadLine();

            requestQueue.Enqueue(req);
            Console.WriteLine("Request added successfully!");
        }

        static void ViewRequests()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests.");
                return;
            }

            Console.WriteLine("REQUEST QUEUE");
            int count = 1;
            foreach (StudentRequest req in requestQueue)
            {
                Console.WriteLine(count + ". " + req.StudentName + " - " + req.RequestType);
                count++;
            }
        }

        static void ProcessRequest()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests to process.");
                return;
            }

            StudentRequest req = requestQueue.Dequeue();
            Console.WriteLine("Processing Request: " + req.StudentName + " - " + req.RequestType);
            Console.WriteLine("Request processed successfully!");
        }
    }
}
