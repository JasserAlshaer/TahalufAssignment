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
        public DbSet<User> Users { get; set; }
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
            new LookupType { Id = 1, Name = "Country", NameAr = "الدولة" }
            );

            modelBuilder.Entity<LookupItem>().HasData(
            new LookupItem { Id = 1, Name = "United States", NameAr = "الولايات المتحدة", LookupTypeId = 1 },
            new LookupItem { Id = 2, Name = "Jordan", NameAr = "الأردن", LookupTypeId = 1 },
            new LookupItem { Id = 3, Name = "Saudi Arabia", NameAr = "المملكة العربية السعودية", LookupTypeId = 1 },
            new LookupItem { Id = 4, Name = "United Arab Emirates", NameAr = "الإمارات العربية المتحدة", LookupTypeId = 1 },
            new LookupItem { Id = 5, Name = "Egypt", NameAr = "مصر", LookupTypeId = 1 },
            new LookupItem { Id = 6, Name = "Morocco", NameAr = "المغرب", LookupTypeId = 1 },
            new LookupItem { Id = 7, Name = "France", NameAr = "فرنسا", LookupTypeId = 1 },
            new LookupItem { Id = 8, Name = "Germany", NameAr = "ألمانيا", LookupTypeId = 1 },
            new LookupItem { Id = 9, Name = "United Kingdom", NameAr = "المملكة المتحدة", LookupTypeId = 1 },
            new LookupItem { Id = 10, Name = "Italy", NameAr = "إيطاليا", LookupTypeId = 1 },
            new LookupItem { Id = 11, Name = "Spain", NameAr = "إسبانيا", LookupTypeId = 1 },
            new LookupItem { Id = 12, Name = "Qatar", NameAr = "قطر", LookupTypeId = 1 },
            new LookupItem { Id = 13, Name = "Lebanon", NameAr = "لبنان", LookupTypeId = 1 },
            new LookupItem { Id = 14, Name = "Syria", NameAr = "سوريا", LookupTypeId = 1 },
            new LookupItem { Id = 15, Name = "Iraq", NameAr = "العراق", LookupTypeId = 1 },
            new LookupItem { Id = 16, Name = "Kuwait", NameAr = "الكويت", LookupTypeId = 1 },
            new LookupItem { Id = 17, Name = "Oman", NameAr = "عمان", LookupTypeId = 1 },
            new LookupItem { Id = 18, Name = "Bahrain", NameAr = "البحرين", LookupTypeId = 1 },
            new LookupItem { Id = 19, Name = "Algeria", NameAr = "الجزائر", LookupTypeId = 1 },
            new LookupItem { Id = 20, Name = "Tunisia", NameAr = "تونس", LookupTypeId = 1 },
            new LookupItem { Id = 21, Name = "Libya", NameAr = "ليبيا", LookupTypeId = 1 },
            new LookupItem { Id = 22, Name = "Palestine", NameAr = "فلسطين", LookupTypeId = 1 },
            new LookupItem { Id = 23, Name = "Turkey", NameAr = "تركيا", LookupTypeId = 1 },
            new LookupItem { Id = 24, Name = "Greece", NameAr = "اليونان", LookupTypeId = 1 },
            new LookupItem { Id = 25, Name = "Portugal", NameAr = "البرتغال", LookupTypeId = 1 },
            new LookupItem { Id = 26, Name = "Netherlands", NameAr = "هولندا", LookupTypeId = 1 },
            new LookupItem { Id = 27, Name = "Belgium", NameAr = "بلجيكا", LookupTypeId = 1 },
            new LookupItem { Id = 28, Name = "Sweden", NameAr = "السويد", LookupTypeId = 1 },
            new LookupItem { Id = 29, Name = "Norway", NameAr = "النرويج", LookupTypeId = 1 },
            new LookupItem { Id = 30, Name = "Denmark", NameAr = "الدنمارك", LookupTypeId = 1 },
            new LookupItem { Id = 31, Name = "Switzerland", NameAr = "سويسرا", LookupTypeId = 1 },
            new LookupItem { Id = 32, Name = "Austria", NameAr = "النمسا", LookupTypeId = 1 },
            new LookupItem { Id = 33, Name = "Russia", NameAr = "روسيا", LookupTypeId = 1 },
            new LookupItem { Id = 34, Name = "China", NameAr = "الصين", LookupTypeId = 1 },
            new LookupItem { Id = 35, Name = "Japan", NameAr = "اليابان", LookupTypeId = 1 },
            new LookupItem { Id = 36, Name = "India", NameAr = "الهند", LookupTypeId = 1 },
            new LookupItem { Id = 37, Name = "Canada", NameAr = "كندا", LookupTypeId = 1 },
            new LookupItem { Id = 38, Name = "Australia", NameAr = "أستراليا", LookupTypeId = 1 },
            new LookupItem { Id = 39, Name = "Brazil", NameAr = "البرازيل", LookupTypeId = 1 },
            new LookupItem { Id = 40, Name = "South Africa", NameAr = "جنوب أفريقيا", LookupTypeId = 1 },
            new LookupItem { Id = 41, Name = "Other", NameAr = "غير ذلك", LookupTypeId = 1 }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Jasser",
                    LastName = "Alshaer",
                    Email = "joshaer17@gmail.com",
                    Password = HashingHelper.GenerateSHA384String("123qwe0"),
                    Username = HashingHelper.GenerateSHA384String("joshaer"),
                    UserType = "Admin"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Assignement",
                    Email = "admin@tahaluf.com",
                    Password = HashingHelper.GenerateSHA384String("123qwe"),
                    Username = HashingHelper.GenerateSHA384String("admin"),
                    UserType = "Admin"
                }
                );
        }
        protected void ApplayConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LookupTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupItemEntityTypeConfiguration());

        }
    }
}
