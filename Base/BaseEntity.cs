
namespace dotnet.Base 
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime  CreationDate { get; set; } = DateTime.UtcNow;
    }
}