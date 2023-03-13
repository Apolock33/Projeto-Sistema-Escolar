using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public Guid IdAluno { get; set; }
        public int Matricula { get; set; }
        [StringLength(20, ErrorMessage = "O número máximo de caracteres foi atingido para o campo CPF!")]
        public string? CPF { get; set; }
        public string? NomeAluno { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataDeNascimento { get; set; }

        [ForeignKey("Turma")]
        public Guid IdTurma { get; set; }
        public Turma? Turma { get; set; }
    }
}
