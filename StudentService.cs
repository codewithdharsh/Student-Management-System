using System;
using System.Data.SqlClient;

public class StudentService : IStudentService
{
    private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagementDB;Integrated Security=True";


    public void AddStudent(Student student)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, Age, Grade, Email) VALUES (@Name, @Age, @Grade, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Grade", student.Grade);
                cmd.Parameters.AddWithValue("@Email", student.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student added successfully.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding student: " + ex.Message);
        }
    }

    public void ViewStudents()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Grade: {reader["Grade"]}, Email: {reader["Email"]}");
                }
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error viewing students: " + ex.Message);
        }
    }

    public void UpdateStudent(Student student)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET Name = @Name, Age = @Age, Grade = @Grade, Email = @Email WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Grade", student.Grade);
                cmd.Parameters.AddWithValue("@Email", student.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student updated successfully.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating student: " + ex.Message);
        }
    }

    public void DeleteStudent(int id)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student deleted successfully.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting student: " + ex.Message);
        }
    }

    public void FilterByGrade(string grade)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students WHERE Grade = @Grade";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Grade", grade);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Students in Grade " + grade + ":");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} - {reader["Name"]}, Age: {reader["Age"]}, Email: {reader["Email"]}");
                }
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error filtering by grade: " + ex.Message);
        }
    }

    public void FilterByAge(int age)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students WHERE Age = @Age";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Age", age);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Students with Age " + age + ":");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} - {reader["Name"]}, Grade: {reader["Grade"]}, Email: {reader["Email"]}");
                }
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error filtering by age: " + ex.Message);
        }
    }
}
