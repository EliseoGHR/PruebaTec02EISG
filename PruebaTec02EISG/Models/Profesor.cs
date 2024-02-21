using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PruebaTec02EISG.Models
{
    public class Profesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfesorId { get; set; }

        [Required(ErrorMessage = "El nombre de profesor es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido de profesor es requerido")]
        public string Apellido { get; set; }
        [Display(Name ="Correo Electronico")]
        [Required(ErrorMessage = "El correo electronico de profesor es requerido")]
        public string? CorreoElectronico { get; set; }
        public string Telefono { get; set; }    
        public byte[]? Imagen { get; set; }

        [Display(Name ="Carrera")]
        public int? CarreraId { get; set; }

        [ForeignKey("CarreraId")]
        public virtual Carrera? Carrera { get; set; }

    }
}
