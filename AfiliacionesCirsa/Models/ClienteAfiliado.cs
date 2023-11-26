using System.ComponentModel.DataAnnotations;

namespace AfiliacionesCirsa.Models
{
    public class ClienteAfiliado : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = String.Empty;

        [Required] // TODO hash
        [StringLength(100)]
        public string Password { get; set; } = String.Empty;

        [Required] 
        public int TotalSpent { get; set; } = 0;

        [Required]
        public int Afiliador_id { get; set; }


    }
}
