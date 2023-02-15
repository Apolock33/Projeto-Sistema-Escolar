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

        public string NomeAluno { get; set; }

        [StringLength(20,ErrorMessage = "Você atingiu o máximo de caracteres para esse campo: CPF")]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }

        [ForeignKey("Turmas")]
        public Guid Turma { get; set; }
        public Turmas Turmas { get; set; }

        [ForeignKey("Escolas")]
        public Guid Escola { get; set; }
        public Escolas Escolas { get; set; }
    }
}
