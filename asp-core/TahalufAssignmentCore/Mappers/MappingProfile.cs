using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.DTOs.Companies;
using TahalufAssignmentCore.DTOs.Orgnizations;
using TahalufAssignmentCore.Entities.Companies;
using TahalufAssignmentCore.Entities.Orgnizations;

namespace TahalufAssignmentCore.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Company, CreateUpdateCompanyDTO>().ReverseMap();
           CreateMap<Orgnization, CreateUpdateOrganizationDTO>().ReverseMap();
        }
    }
}
