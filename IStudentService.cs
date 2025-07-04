using System.Collections.Generic;

public interface IStudentService
{
    void AddStudent(Student student);
    void ViewStudents();
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
    void FilterByGrade(string grade);
    void FilterByAge(int age);
}
