﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TahalufAssignmentCore.Entities.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.EntitiesConfigurations.Managements
{
    public class LookupTypeEntityConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("LookupTypes");
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            //Allow Arabics 
            builder.Property(x => x.NameAr).IsUnicode(true);
            //Let Uniques 
            builder.HasIndex(x => x.NameAr).IsUnique(true);
            builder.HasIndex(x => x.Name).IsUnique(true);
            //Check 
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "LEN(Name) >= 2"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "LEN(NameAr) >= 2"));
            //RelationShips
            builder.HasMany<LookupItem>().WithOne().HasForeignKey(x => x.LookupTypeId);
        }
    }
}
