using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Turmas")]
    public class Turmas
    {
        [Key]
        public Guid TurmaId { get; set; }
        
        public string CodigoDaTurma { get; set; }
        
        public int QtdAlunos { get; set; }

        public ICollection<Alunos> Alunos { get; set; }
    }
}