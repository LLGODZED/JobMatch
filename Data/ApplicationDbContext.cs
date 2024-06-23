using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jobmatch.Models;

namespace Jobmatch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Jobmatch.Models.Category> Category { get; set; } = default!;
        public DbSet<Jobmatch.Models.Job> Job { get; set; } = default!;
        public DbSet<Jobmatch.Models.Employer> Employer { get; set; } = default!;
        public DbSet<Jobmatch.Models.JobSeeker> JobSeeker { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedJob(builder);
            SeedCategory(builder);
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "IT"
                },
                new Category
                {
                    Id = 2,
                    Name = "Bussines"
                },
                new Category
                {
                    Id = 3,
                    Name = "Education"
                }
                );
        }

        private void SeedJob(ModelBuilder builder)
        {
            builder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Title = "FPT",
                    Description = "Bridge SE",
                    Requirment = "N2, university diploma, cv",
                    Address = "Pham Van Bach,Hanoi",
                    Salary = 2000,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPXnpGRiAcFBeh8s06rHjnJq2tZ5BNy8RtOg&s",
                    CategoryId = 1
                },
                new Job
                {
                    Id = 2,
                    Title = "Nissan tech",
                    Description = "Front-end",
                    Requirment = "HTML,PHP,JAVA,C#",
                    Address = "Pham Van Dong,Hanoi",
                    Salary = 800,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTuhRMWw3eTOcHg3rg9eVfhFLaQsZdJzpSrw&s",
                    CategoryId = 1
                },
                new Job
                {
                    Id = 3,
                    Title = "THPT HOA BINH LATROBE",
                    Description = "Teacher Match",
                    Requirment = "university diploma",
                    Address = "Cam Hoi,Hanoi",
                    Salary = 300,
                    Image = "https://iweb.tatthanh.com.vn/pic/1115/setting/Logo-Landingpage.png",
                    CategoryId = 3
                },
                new Job
                {
                    Id = 4,
                    Title = "Techcombank",
                    Description = "accountantt",
                    Requirment = "university diploma",
                    Address = "Phan Chu Trinh,Hanoi",
                    Salary = 500,
                    Image = "https://media.loveitopcdn.com/3807/thumb/logo-techcombank-dongphucsongphu.png",
                    CategoryId = 2
                },
                new Job
                {
                    Id = 5,
                    Title = "ABC Corp",
                    Description = "Software Developer",
                    Requirment = "Bachelor's degree, 2+ years experience, portfolio",
                    Address = "Nguyen Trai, Hanoi",
                    Salary = 2500,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1yQ8f0k8eIj3F_gwXGF8Z4eTQMQbFqOj8uQ&s",
                    CategoryId = 2
                },
                new Job
                {
                    Id = 6,
                    Title = "XYZ Ltd",
                    Description = "System Analyst",
                    Requirment = "Bachelor's degree, analytical skills, 3+ years experience",
                    Address = "Le Duan, Ho Chi Minh City",
                    Salary = 3000,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO9kt8wCj9eQKmT5BoFmnOrT8VNNc9YF_T5g&s",
                    CategoryId = 3
                },
                new Job
                {
                    Id = 7,
                    Title = "DEF Solutions",
                    Description = "Project Manager",
                    Requirment = "PMP certification, 5+ years experience, leadership skills",
                    Address = "Hai Ba Trung, Hanoi",
                    Salary = 3500,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5zH7U8tPnQGpQa6IeI8txzQcYjeNzlxXL8A&s",
                    CategoryId = 1
                },
                new Job
                {
                    Id = 8,
                    Title = "GHI Tech",
                    Description = "QA Engineer",
                    Requirment = "Bachelor's degree, 3+ years experience in QA, attention to detail",
                    Address = "Tran Hung Dao, Da Nang",
                    Salary = 2800,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4oQ3hzj5RlTruVmK_f5WZ8d9lryOgtl3tPw&s",
                    CategoryId = 1
                },
                new Job
                {
                    Id = 9,
                    Title = "JKL Innovations",
                    Description = "UI/UX Designer",
                    Requirment = "Bachelor's degree, portfolio of design projects, proficiency in design software",
                    Address = "Nguyen Van Linh, Ho Chi Minh City",
                    Salary = 2700,
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTc3k2_vDc4CJyHYhrUzSgM9cM1a_xr85DutA&s",
                    CategoryId = 1
                },
                new Job
                {
                    Id = 10,
                    Title = "VTC",
                    Description = "Full Stack",
                    Requirment = "HTML,PHP,JAVA,C#, SQL, No SQL",
                    Address = "Tran Quy Kien,Hanoi",
                    Salary = 800,
                    Image = "https://vtc.gov.vn/site/img/anhvtc.jpg",
                    CategoryId = 1
                }
             );
        }
    }
}
