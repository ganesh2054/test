
using System.Collections.Generic;


namespace CollegeManagement.Models
{
    public class SqlStudentRepository : StudentRepository
    {
        private readonly StudentDbContext context;
        public SqlStudentRepository(StudentDbContext _context)
        {
            context = _context;
        }

       

        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Delete(int Id)
        {
            Student student = context.Students.Find(Id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return context.Students;
        }

        public Student GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public Student Update(Student studentChanges)
        {
            var student = context.Students.Attach(studentChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}
