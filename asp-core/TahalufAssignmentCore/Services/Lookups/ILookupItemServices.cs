using TahalufAssignmentCore.DTOs.LookupItem;

namespace TahalufAssignmentCore.Services
{
    public interface ILookupItemServices
    {
        Task<List<LookupItemDto>> GetLookupItem(int? typeId);

        Task<string> CreateLookupItem(CreateLookupItemDto input);


        Task<string> ManageLookupItemActivation(LookupItemActivationDto input);
    }
}
