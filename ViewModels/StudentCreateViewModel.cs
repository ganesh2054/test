using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;
using System;


namespace CollegeManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Gender?Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phon { get; set; }
        public Faculty?Faculty { get; set; }
        public IFormFile Photo { get; set; }
    }
}
