using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("MateriaXTurma")]
    public class MateriaXTurma
    {
        [Key]
        public Guid IdMateriaTurma { get; set; }

        [ForeignKey("Turma")]
        public Guid IdTurma { get; set; }
        public Turma? Turma { get; set; }

        [ForeignKey("Materia")]
        public Guid IdMateria { get; set; }
        public Materia? Materia { get; set; }
    }
}
