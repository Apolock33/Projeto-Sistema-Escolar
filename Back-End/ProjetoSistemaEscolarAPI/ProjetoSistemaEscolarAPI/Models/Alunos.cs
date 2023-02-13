using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Alunos")]
    public class Alunos
    {
        [Key]
        public Guid AlunoId { get; set; }
        public int Matricula { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public string CPF { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("Turmas")]
        public Guid TurmaId { get; set; }
        public Turmas Turma { get; set; }

        [ForeignKey("Escolas")]
        public Guid EscolaId { get; set; }
        public Escolas Escolas { get; set; }
    }
}
