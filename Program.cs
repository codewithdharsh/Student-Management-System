using System;

class Program
{
    static void Main(string[] args)
    {
        IStudentService studentService = new StudentService();

        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Filter by Grade");
            Console.WriteLine("6. Filter by Age");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        var newStudent = new Student();
                        Console.Write("Name: "); newStudent.Name = Console.ReadLine();
                        Console.Write("Age: "); newStudent.Age = int.Parse(Console.ReadLine());
                        Console.Write("Grade: "); newStudent.Grade = Console.ReadLine();
                        Console.Write("Email: "); newStudent.Email = Console.ReadLine();
                        studentService.AddStudent(newStudent);
                        break;

                    case "2":
                        studentService.ViewStudents();
                        break;

                    case "3":
                        var updateStudent = new Student();
                        Console.Write("Student ID to Update: "); updateStudent.Id = int.Parse(Console.ReadLine());
                        Console.Write("New Name: "); updateStudent.Name = Console.ReadLine();
                        Console.Write("New Age: "); updateStudent.Age = int.Parse(Console.ReadLine());
                        Console.Write("New Grade: "); updateStudent.Grade = Console.ReadLine();
                        Console.Write("New Email: "); updateStudent.Email = Console.ReadLine();
                        studentService.UpdateStudent(updateStudent);
                        break;

                    case "4":
                        Console.Write("Enter Student ID to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        studentService.DeleteStudent(deleteId);
                        break;

                    case "5":
                        Console.Write("Enter Grade to Filter: ");
                        string grade = Console.ReadLine();
                        studentService.FilterByGrade(grade);
                        break;

                    case "6":
                        Console.Write("Enter Age to Filter: ");
                        int age = int.Parse(Console.ReadLine());
                        studentService.FilterByAge(age);
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input error: " + ex.Message);
            }
        }
    }
}
