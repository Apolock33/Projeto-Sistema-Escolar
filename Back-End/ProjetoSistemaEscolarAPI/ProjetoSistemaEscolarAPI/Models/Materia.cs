using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSistemaEscolarAPI.Models
{
    [Table("Materia")]
    public class Materia
    {
        [Key]
        public Guid IdMateria { get; set; }
        public string? NomeMateria { get; set; }
        public string? ProfessorDaMateria { get; set; }
    }
}