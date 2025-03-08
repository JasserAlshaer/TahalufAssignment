using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.Entities.Companies;
using TahalufAssignmentCore.Entities.Orgnizations;

namespace TahalufAssignmentCore.EntitiesConfigurations.Orgnizations
{
    public class OrgnizationEntityTypeConfiguration : IEntityTypeConfiguration<Orgnization>
    {
        public void Configure(EntityTypeBuilder<Orgnization> builder)
        {
            builder.ToTable("Orgnizations");
            //Relationships
            builder.HasMany<Company>().WithOne().HasForeignKey(x=>x.OrganizationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
