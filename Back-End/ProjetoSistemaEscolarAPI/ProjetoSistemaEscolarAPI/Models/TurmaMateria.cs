using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("TurmaMateria")]
    public class TurmaMateria
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Turmas")]
        public Guid TurmaId { get; set; }
        public Turmas Turmas { get; set; }

        [ForeignKey("Materias")]
        public Guid MateriaId { get; set; }
        public Materias Materias { get; set; }
    }
}
