using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Turmas")]
    public class Turmas
    {
        [Key]
        public Guid TurmaId { get; set; }
        [Required]
        public int CodigoTurma { get; set; }
        public int QtdAlunos { get; set; }
    }
}
