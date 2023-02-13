using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Materias")]
    public class Materias
    {
        [Key]
        public Guid MateriaId { get; set; }
        [Required]
        public string NomeDaMateria { get; set; }
        [Required]
        public string ProfessorDaMateria { get; set; }
        public int QtdTurmasMatriculadas { get; set; }
    }
}
