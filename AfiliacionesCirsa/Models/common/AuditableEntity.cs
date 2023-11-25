namespace AfiliacionesCirsa.Models
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.UtcNow;
    }
}
