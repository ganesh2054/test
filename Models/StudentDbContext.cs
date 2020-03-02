using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CollegeManagement.Models
{
    public class StudentDbContext:IdentityDbContext
    {
        
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    id = 1,
                    Name = "Mark",
                    Address = "kathmandu",
                    Email = "lmeganesh@gmail.com",
                   

                    Phon = "34579375",



                },
                new Student
                {
                    id = 2,
                    Name = "Mark",
                    Address = "ktm",
                    Email = "lmeUmeshsh@gmail.com",


                    Phon = "34579375",

                }


            );
        }
    }

}

