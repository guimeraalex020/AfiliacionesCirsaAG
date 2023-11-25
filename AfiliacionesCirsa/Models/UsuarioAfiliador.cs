using System.ComponentModel.DataAnnotations;

namespace AfiliacionesCirsa.Models
{
    public class UsuarioAfiliador : AuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = String.Empty;

        [Required] // ha de ser un hash, tipus nidea
        [StringLength(100)]
        public string Password { get; set; } = String.Empty;


    }
}
