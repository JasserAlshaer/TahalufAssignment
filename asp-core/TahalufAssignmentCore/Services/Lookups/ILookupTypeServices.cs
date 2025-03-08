using TahalufAssignmentCore.DTOs;
using TahalufAssignmentCore.DTOs.LookupItem;
using TahalufAssignmentCore.DTOs.Lookups;

namespace TahalufAssignmentCore.Services
{
    public interface ILookupTypeServices
    {
        Task<List<LookupTypeDto>> GetLookupType();
    }
}
