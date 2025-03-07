using Microsoft.EntityFrameworkCore;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.DTOs.Lookups;
using TahalufAssignmentCore.Services;


namespace TahalufAssignmentInfrastructure.Services
{
    public class LookupTypeServices : ILookupTypeServices
    {
        private readonly TahalufAssignmentDbContext _context;

        public LookupTypeServices(TahalufAssignmentDbContext context)
        {
            _context = context;
        }

        public async Task<List<LookupTypeDto>> GetLookupType()
        {
            var lookupType = await _context.LookupTypes.ToListAsync();

            return lookupType.Select(x => new LookupTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                NameAr = x.NameAr,
                CreationDate = x.CreationDate.ToShortDateString()
            }).ToList();

        }
    }
}
