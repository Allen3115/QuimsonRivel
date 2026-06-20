using System;
using System.Collections.Generic;

List<Student> students = new List<Student>();
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
        string name = Console.ReadLine();

        Console.Write("Enter student ID: ");
        string id = Console.ReadLine();

        Console.Write("Enter number of subjects: ");
        int subjectCount = int.Parse(Console.ReadLine());

        List<double> grades = new List<double>();

        for (int i = 0; i < subjectCount; i++)
        {
            Console.Write("Enter grade for subject " + (i + 1) + ": ");
            grades.Add(double.Parse(Console.ReadLine()));
        }

        students.Add(new Student
        {
            Name = name,
            ID = id,
            Grades = grades
        });

        Console.WriteLine("Student added successfully!");
    }
    else if (choice == 2)
    {
        Console.WriteLine("\n----- View Students -----");

        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
        }
        else
        {
            foreach (Student s in students)
            {
                double sum = 0;

                foreach (double g in s.Grades)
                {
                    sum += g;
                }

                double avg = sum / s.Grades.Count;

                Console.WriteLine(
                    $"ID: {s.ID}, Name: {s.Name}, Average: {avg:F2}");
            }
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine("\n----- Compute Class Average -----");

        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
        }
        else
        {
            double total = 0;

            foreach (Student s in students)
            {
                double sum = 0;

                foreach (double g in s.Grades)
                {
                    sum += g;
                }

                total += sum / s.Grades.Count;
            }

            Console.WriteLine(
                $"Class Average: {(total / students.Count):F2}");
        }
    }
    else if (choice == 4)
    {
        Console.WriteLine("\n----- Show Top Student -----");

        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
        }
        else
        {
            Student top = students[0];
            double topAvg = 0;

            foreach (double g in top.Grades)
            {
                topAvg += g;
            }

            topAvg /= top.Grades.Count;

            foreach (Student s in students)
            {
                double sum = 0;

                foreach (double g in s.Grades)
                {
                    sum += g;
                }

                double avg = sum / s.Grades.Count;

                if (avg > topAvg)
                {
                    top = s;
                    topAvg = avg;
                }
            }

            Console.WriteLine(
                $"Top Student: {top.Name} (ID: {top.ID}) with Average: {topAvg:F2}");
        }
    }
    else if (choice == 5)
    {
        Console.WriteLine("\n----- Exit -----");
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("\n----- Invalid Choice -----");
    }

} while (choice != 5);

class Student
{
    public string Name { get; set; }
    public string ID { get; set; }
    public List<double> Grades { get; set; }
}