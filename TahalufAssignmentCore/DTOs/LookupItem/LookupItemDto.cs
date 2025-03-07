namespace TahalufAssignmentCore.DTOs.LookupItem
{
    public class LookupItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int LookupTypeId { get; set; }
        public bool IsActive { get; set; }
        public string CreationDate { get; set; }
        public string ParentName { get; set; }
        public string ParentNameAr { get; set; }
    }
}
