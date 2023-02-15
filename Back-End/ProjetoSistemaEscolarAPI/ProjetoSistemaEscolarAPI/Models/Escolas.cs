using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Escolas")]
    public class Escolas
    {
        [Key]
        public Guid EscolaId { get; set; }

        public int CodigoUnidade { get; set; }

        public string Endereco { get; set; }

        public int QtdTurmas { get; set; }

        public int QtdAlunos { get; set; }

        public ICollection<Alunos> Alunos { get; set; }
        public ICollection<Turmas> Turmas { get; set; }
    }
}
