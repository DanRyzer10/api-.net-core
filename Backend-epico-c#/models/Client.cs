using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Backend_epico_c_.models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        [Required(ErrorMessage ="el campo {0} es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage ="el campo {0} es requerido")]
        public string  LastName { get; set; }

        [Required(ErrorMessage ="el campo {0} es requerido")]
        [EmailAddress(ErrorMessage ="el campo {0} debe ser un correo valido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="el campo {0} es requerido")]
        [Phone(ErrorMessage ="el campo {0} debe ser un numero de telefono valido")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="el campo {0} es requerido")]
        public string Address { get; set; }

        public bool Active { get; set; }
    }
}
