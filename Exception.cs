using System;

namespace StudentManagementSystem.Exceptions
{
    
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException()
            : base("Student not found.") { }
    }

    // When invalid input is given (like age < 0 or name is empty)
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
            : base("Invalid input provided.") { }
    }

    // When a database operation fails
    public class DatabaseException : Exception
    {
        public DatabaseException()
            : base("Database operation failed.") { }
    }
}
