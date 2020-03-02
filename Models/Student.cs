
using System;


namespace CollegeManagement.Models
{
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Gender?Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phon { get; set; }
        public Faculty?Faculty { get; set; }
        public string PhotoPath { get; set; }
    }
}
