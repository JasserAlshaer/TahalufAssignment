using TahalufAssignmentCore.Entities.Authantication;
using TahalufAssignmentCore.Entities.Management;
using TahalufAssignmentCore.EntitiesConfigurations.Authantications;
using TahalufAssignmentCore.EntitiesConfigurations.Managements;
using TahalufAssignmentCore.Helpers;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Context
{
    public class TahalufAssignmentDbContext : DbContext
    {
        //Management Entities
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<Person> Users { get; set; }
        public DbSet<VerificationCode> VerificationCodes { get; set; }
        

        public TahalufAssignmentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Data (Optional)
            SeedData(modelBuilder);

            // Apply Configurations 
            ApplayConfigurations(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupType>().HasData(
            new LookupType { Id = 1, Name = "Nationality", NameAr = "الجنسية" },
            new LookupType { Id = 2, Name = "Language", NameAr = " اللغة" },
            new LookupType { Id = 3, Name = "Spectilization", NameAr = "التخصص الجامعي" },
            new LookupType { Id = 4, Name = "Salary Scale", NameAr = "نطاق الرواتب" },
            new LookupType { Id = 5, Name = "Hiring Rate", NameAr = "معدل التوظيف" },
            new LookupType { Id = 6, Name = "Question Type", NameAr = "نوع السؤال" },
            new LookupType { Id = 7, Name = "Question Level", NameAr = "مستوى صعوبة السؤال" },
            new LookupType { Id = 8, Name = "Exam Level", NameAr = "مستوى صعوبة الأختبار" }
            );

            modelBuilder.Entity<LookupItem>().HasData(
            new LookupItem { Id = 10, Name = "Jordanian", NameAr = "اردني", LookupTypeId = 1 },
            new LookupItem { Id = 11, Name = "Other", NameAr = "غير ذلك", LookupTypeId = 1 },
            new LookupItem { Id = 20, Name = "Arabic", NameAr = "العربيه", LookupTypeId = 2 },
            new LookupItem { Id = 21, Name = "English", NameAr = "الانجليزية", LookupTypeId = 2 },
            new LookupItem { Id = 30, Name = "Software Engineering", NameAr = "هندسة البرمجيات", LookupTypeId = 3 },
            new LookupItem { Id = 31, Name = "Computer Engineering", NameAr = "هندسة الحاسوب", LookupTypeId = 3 },
            new LookupItem { Id = 32, Name = "Computer Since", NameAr = "علم الحاسوب", LookupTypeId = 3 },
            new LookupItem { Id = 33, Name = "Computer Inbformation Technologt", NameAr = "نظم معلومات الحاسوبيه", LookupTypeId = 3 },
            new LookupItem { Id = 34, Name = "Engineering", NameAr = "التخصصات الهندسيه", LookupTypeId = 3 },
            new LookupItem { Id = 40, Name = "Low", NameAr = "منخفض", LookupTypeId = 4 },
            new LookupItem { Id = 41, Name = "Medium", NameAr = "متوسط", LookupTypeId = 4 },
            new LookupItem { Id = 42, Name = "High", NameAr = "مرتفع", LookupTypeId = 4 },
            new LookupItem { Id = 43, Name = "Very High", NameAr = "مرتفع جدًا", LookupTypeId = 4 },
            new LookupItem { Id = 44, Name = "Executive Level", NameAr = "مستوى تنفيذي", LookupTypeId = 4 },
            new LookupItem { Id = 50, Name = "High Hiring Rate", NameAr = "معدل طلب عالي ", LookupTypeId = 5 },
            new LookupItem { Id = 51, Name = "Medium Hiring Rate", NameAr = "معدل طلب متوسط ", LookupTypeId = 5 },
            new LookupItem { Id = 52, Name = "Low Hiring Rate", NameAr = "معدل طلب ضعيف ", LookupTypeId = 5 },
            new LookupItem { Id = 60, Name = "Multiple Choice", NameAr = "اختيار من متعدد", LookupTypeId = 6 },
            new LookupItem { Id = 61, Name = "True/False", NameAr = "صواب/خطأ", LookupTypeId = 6 },
            new LookupItem { Id = 62, Name = "Short Answer", NameAr = "إجابة قصيرة", LookupTypeId = 6 },
            new LookupItem { Id = 63, Name = "Essay", NameAr = "مقال", LookupTypeId = 6 },
            new LookupItem { Id = 64, Name = "Matching", NameAr = "مطابقة", LookupTypeId = 6 },
            new LookupItem { Id = 70, Name = "Easy", NameAr = "سهل", LookupTypeId = 7 },
            new LookupItem { Id = 71, Name = "Medium", NameAr = "متوسط", LookupTypeId = 7 },
            new LookupItem { Id = 72, Name = "Hard", NameAr = "صعب", LookupTypeId = 7 },
            new LookupItem { Id = 73, Name = "Very Hard", NameAr = "صعب جدًا", LookupTypeId = 7 },
            new LookupItem { Id = 80, Name = "Easy", NameAr = "سهل", LookupTypeId = 8 },
            new LookupItem { Id = 81, Name = "Medium", NameAr = "متوسط", LookupTypeId = 8},
            new LookupItem { Id = 82, Name = "Hard", NameAr = "صعب", LookupTypeId = 8 },
            new LookupItem { Id = 83, Name = "Very Hard", NameAr = "صعب جدًا", LookupTypeId = 8 }

            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Jasser",
                    MiddleName = "Khaled",
                    LastName = "Alshaer",
                    Email = "joshaer17@gmail.com"
                ,
                    Password = HashingHelper.GenerateSHA384String("123qwe0"),
                    Phone = "0787700833",
                    Username = HashingHelper.GenerateSHA384String("joshaer"),
                    UserType = "Admin"
                }
                );
        }
        protected void ApplayConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VerificationCodeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LookupTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupItemEntityTypeConfiguration());

        }
    }
}
