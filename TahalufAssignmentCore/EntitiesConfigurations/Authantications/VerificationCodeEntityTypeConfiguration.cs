using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;
using TahalufAssignmentCore.Entities.Authantication;
using TahalufAssignmentCore.Entities.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.EntitiesConfigurations.Authantications
{
    public class VerificationCodeEntityTypeConfiguration : IEntityTypeConfiguration<VerificationCode>
    {
        public void Configure(EntityTypeBuilder<VerificationCode> builder)
        {
            builder.ToTable("VerificationCodes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySQLAutoIncrementColumn("Id");
            //Default values
            builder.Property(x => x.CreatedBy).HasColumnType("VARCHAR(255)").HasDefaultValue("System");
            builder.ToTable(x => x.HasCheckConstraint("CH_Email", "CHAR_LENGTH(Email) >= 2"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Code", "CHAR_LENGTH(Code) = 6"));
            
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsUsed).HasDefaultValue(false);
             
        }
    }
}
