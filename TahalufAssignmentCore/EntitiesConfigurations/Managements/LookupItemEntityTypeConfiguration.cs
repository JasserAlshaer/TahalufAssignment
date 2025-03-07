using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TahalufAssignmentCore.Entities.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.EntitiesConfigurations.Managements
{
    public class LookupItemEntityTypeConfiguration : IEntityTypeConfiguration<LookupItem>
    {
        public void Configure(EntityTypeBuilder<LookupItem> builder)
        {
            builder.ToTable("LookupItems");
            builder.Property(x => x.IsActive).HasDefaultValue(true);
             
            
            //Allow Arabics 
            builder.Property(x => x.NameAr).IsUnicode(true);
            builder.Property(x => x.Name).IsUnicode(false);
            //Let Uniques 
            builder.HasIndex(x => x.NameAr).IsUnique(false);
            builder.HasIndex(x => x.Name).IsUnique(false);
            //Check 
            builder.Property(x => x.CreatedBy).HasColumnType("VARCHAR(255)").HasDefaultValue("System");
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "CHAR_LENGTH(Name) >= 2"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "CHAR_LENGTH(NameAr) >= 2"));
            //Relationships 
        }
    }
}
