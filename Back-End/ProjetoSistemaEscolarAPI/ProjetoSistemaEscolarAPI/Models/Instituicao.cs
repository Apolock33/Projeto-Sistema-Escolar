using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Instituicao")]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; }
        public int CodigoInstituicao { get; set; }
        public int QtdAlunos { get; set; }
        public int QtdTurmas { get; set; }
        public int QtdCursos { get; set; }

        public ICollection<Turma>? Turmas { get; set; }
    }
}
