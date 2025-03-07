using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;
using TahalufAssignmentCore.Entities.Authantication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.EntitiesConfigurations.Authantications
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);
            //Default values
            builder.Property(x => x.Id).UseMySQLAutoIncrementColumn("Id");
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsPhoneConfirmed).HasDefaultValue(false);
            builder.Property(x => x.IsEmailConfirmed).HasDefaultValue(false);
            builder.Property(x => x.IsLoggedIn).HasDefaultValue(false);
            builder.Property(x => x.UserType).HasColumnType("VARCHAR(255)").HasDefaultValue("Student");
            builder.Property(x => x.CreatedBy).HasColumnType("VARCHAR(255)").HasDefaultValue("System");

            //Manage Type
            builder.Property(x => x.FirstName).IsUnicode(false);
            builder.Property(x => x.MiddleName).IsUnicode(false);
            builder.Property(x => x.LastName).IsUnicode(false);
            builder.Property(x => x.Phone).IsUnicode(false);
            builder.Property(x => x.Email).IsUnicode(false);
            builder.Property(x => x.Password).IsUnicode(false);
            builder.Property(x => x.FirstNameAr).IsUnicode(true);
            builder.Property(x => x.MiddleNameAr).IsUnicode(true);
            builder.Property(x => x.LastNameAr).IsUnicode(true);
            //unique
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.Phone).IsUnique(true);
            //Check Constraints
            builder.ToTable(x => x.HasCheckConstraint("CH_UserFirstName", "CHAR_LENGTH(FirstName)>=3"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserMiddleName", "CHAR_LENGTH(MiddleName)>=3"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserLastName", "CHAR_LENGTH(LastName)>=3"));
            //builder.ToTable(x => x.HasCheckConstraint("CH_Password", "CHAR_LENGTH(Password)>=6 AND CHAR_LENGTH(Password)<=16"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserType", "UserType like 'Admin' or UserType like 'Student' or UserType like 'Instructor'"));
        }
    }
}
