namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public required string Email { get; set; }
    }
}
