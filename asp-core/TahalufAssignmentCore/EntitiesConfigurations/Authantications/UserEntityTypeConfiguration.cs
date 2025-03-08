using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahalufAssignmentCore.Entities.Authantication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.EntitiesConfigurations.Authantications
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            //Default values
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsLoggedIn).HasDefaultValue(false);
            builder.Property(x => x.UserType).HasColumnType("VARCHAR(255)").HasDefaultValue("Student");

            //Manage Type
            builder.Property(x => x.FirstName).IsUnicode(false);
            builder.Property(x => x.LastName).IsUnicode(false);
            builder.Property(x => x.Email).IsUnicode(false);
            builder.Property(x => x.Password).IsUnicode(false);
            //unique
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.Username).IsUnique(true);
            //Check Constraints
            builder.ToTable(x => x.HasCheckConstraint("CH_UserFirstName", "LEN(FirstName)>=3"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserLastName", "LEN(LastName)>=3"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserType", "UserType like 'Admin'"));
        }
    }
}
