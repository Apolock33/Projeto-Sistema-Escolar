using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("MateriasDasTurmas")]
    public class MateriasDasTurmas
    {
        [Key]
        public Guid MateriaDaTurmaId { get; set; }
        
        [ForeignKey("Turmas")]
        public Guid Turma { get; set; }
        public Turmas Turmas { get; set; }

        [ForeignKey("Materias")]
        public Guid Materia { get; set; }
        public Materias Materias { get; set; }
    }
}
