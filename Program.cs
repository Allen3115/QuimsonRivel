using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();
        List<string> ids = new List<string>();
        List<List<double>> gradesList = new List<List<double>>();

        int choice;
        do
        {
            Console.WriteLine("\n----- Student Management System -----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Compute Class Average");
            Console.WriteLine("4. Show Top Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\n----- Add Student -----");
                Console.Write("Enter student name: ");
                names.Add(Console.ReadLine());

                Console.Write("Enter student ID: ");
                ids.Add(Console.ReadLine());

                Console.Write("Enter number of subjects: ");
                int subjectCount = int.Parse(Console.ReadLine());

                List<double> grades = new List<double>();
                for (int i = 0; i < subjectCount; i++)
                {
                    Console.Write("Enter grade for subject " + (i + 1) + ": ");
                    grades.Add(double.Parse(Console.ReadLine()));
                }
                gradesList.Add(grades);

                Console.WriteLine("Student added successfully!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n----- View Students -----");
                if (names.Count == 0) Console.WriteLine("No students available.");
                else
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        double sum = 0;
                        foreach (double g in gradesList[i]) sum += g;
                        double avg = sum / gradesList[i].Count;
                        Console.WriteLine($"ID: {ids[i]}, Name: {names[i]}, Average: {avg:F2}");
                    }
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("\n----- Compute Class Average -----");
                if (names.Count == 0) Console.WriteLine("No students available.");
                else
                {
                    double total = 0;
                    for (int i = 0; i < names.Count; i++)
                    {
                        double sum = 0;
                        foreach (double g in gradesList[i]) sum += g;
                        total += sum / gradesList[i].Count;
                    }
                    Console.WriteLine($"Class Average: {total / names.Count:F2}");
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("\n----- Show Top Student -----");
                if (names.Count == 0) Console.WriteLine("No students available.");
                else
                {
                    int topIndex = 0;
                    double topAvg = 0;
                    for (int i = 0; i < names.Count; i++)
                    {
                        double sum = 0;
                        foreach (double g in gradesList[i]) sum += g;
                        double avg = sum / gradesList[i].Count;
                        if (avg > topAvg)
                        {
                            topAvg = avg;
                            topIndex = i;
                        }
                    }
                    Console.WriteLine($"Top Student: {names[topIndex]} (ID: {ids[topIndex]}) with Average: {topAvg:F2}");
                }
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 5);
    }
}
