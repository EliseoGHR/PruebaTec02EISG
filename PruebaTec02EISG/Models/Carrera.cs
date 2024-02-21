using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTec02EISG.Models
{
    public class Carrera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarreraId { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es requerido")]
        public string Nombre { get; set; }

        // Clave foránea
        public int ProfesorId { get; set; }

        public virtual ICollection<Profesor> Profesores { get; set; }
    }
}
