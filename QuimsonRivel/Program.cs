class ManagementSystem
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
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

            if (choice == 1) AddStudent();
            else if (choice == 2) ViewStudents();
            else if (choice == 3) ComputeClassAverage();
            else if (choice == 4) ShowTopStudent();
            else if (choice == 5) Console.WriteLine("\n----- Exit -----\nGoodbye!");
            else Console.WriteLine("\n----- Invalid Choice -----");

        } while (choice != 5);
    }

    static void AddStudent()
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

        students.Add(new Student { Name = name, ID = id, Grades = grades });
        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\n----- View Students -----");
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        foreach (Student s in students)
        {
            double sum = 0;
            foreach (double g in s.Grades) sum += g;
            double avg = sum / s.Grades.Count;

            Console.WriteLine("ID: " + s.ID + ", Name: " + s.Name + ", Average: " + avg.ToString("F2"));
        }
    }

    static void ComputeClassAverage()
    {
        Console.WriteLine("\n----- Compute Class Average -----");
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double total = 0;
        foreach (Student s in students)
        {
            double sum = 0;
            foreach (double g in s.Grades) sum += g;
            total += sum / s.Grades.Count;
        }

        double classAvg = total / students.Count;
        Console.WriteLine("Class Average: " + classAvg.ToString("F2"));
    }

    static void ShowTopStudent()
    {
        Console.WriteLine("\n----- Show Top Student -----");
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Student top = students[0];
        double topAvg = 0;
        foreach (double g in top.Grades) topAvg += g;
        topAvg /= top.Grades.Count;

        foreach (Student s in students)
        {
            double sum = 0;
            foreach (double g in s.Grades) sum += g;
            double avg = sum / s.Grades.Count;

            if (avg > topAvg)
            {
                top = s;
                topAvg = avg;
            }
        }

        Console.WriteLine("Top Student: " + top.Name + " (ID: " + top.ID + ") with Average: " + topAvg.ToString("F2"));
    }
}

class Student
{
    public string Name { get; set; }
    public string ID { get; set; }
    public List<double> Grades { get; set; }
}