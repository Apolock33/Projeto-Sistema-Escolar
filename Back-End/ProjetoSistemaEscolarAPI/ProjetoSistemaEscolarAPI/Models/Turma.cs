using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        public Guid IdTurma { get; set; }
        public string? CodigoTurma { get; set; }

        public ICollection<Aluno>? Alunos { get; set; }

        [ForeignKey("Instituicao")]
        public Guid IdInstituicao { get; set; }
        public Instituicao? Instituicao { get; set; }

    }
}
