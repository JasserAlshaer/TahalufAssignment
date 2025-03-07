using Microsoft.EntityFrameworkCore;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.Services;
using TahalufAssignmentCore.DTOs.LookupItem;
using TahalufAssignmentCore.Entities.Management;

namespace TahalufAssignmentInfrastructure.Services
{
    public class LookupItemServices : ILookupItemServices
    {
        private readonly TahalufAssignmentDbContext _context;

        public LookupItemServices(TahalufAssignmentDbContext context)
        {
            _context = context;
        }

        public async Task<List<LookupItemDto>> GetLookupItem()
        {
            var lookupItems = from item in _context.LookupItems
                              join parent in _context.LookupTypes
                              on item.LookupTypeId equals parent.Id
                              select new LookupItemDto
                              {
                                  Id = item.Id,
                                  LookupTypeId = item.LookupTypeId,
                                  IsActive = item.IsActive,
                                  CreationDate = item.CreationDate.ToShortDateString(),
                                  Name = item.Name,
                                  NameAr = item.NameAr,
                                  ParentName = parent.Name,
                                  ParentNameAr = parent.NameAr,
                              };
            return await lookupItems.ToListAsync();

        }

        public async Task<string> CreateLookupItem(CreateLookupItemDto input)
        {
            var lookupItem = new LookupItem
            {
                Name = input.Name,
                NameAr = input.NameAr,
                LookupTypeId = input.LookupTypeId,
            };

            _context.LookupItems.Add(lookupItem);
            await _context.SaveChangesAsync();

            return $"Lookup item with ID {lookupItem.Id} created successfully.";
        }


        public async Task<string> ManageLookupItemActivation(LookupItemActivationDto input)
        {
            var lookupItem = await _context.LookupItems.FindAsync(input.Id);

            if (lookupItem == null)
            {
                return "Lookup item not found.";
            }

            lookupItem.IsActive = input.Status;

            await _context.SaveChangesAsync();

            return "Activation status updated successfully.";
        }
    }

}
