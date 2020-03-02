
using System.Collections.Generic;


namespace CollegeManagement.Models
{
    public interface StudentRepository
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudent();
        Student Add(Student student);
        Student Update(Student studentChanges);
        Student Delete(int id);
    }
}
