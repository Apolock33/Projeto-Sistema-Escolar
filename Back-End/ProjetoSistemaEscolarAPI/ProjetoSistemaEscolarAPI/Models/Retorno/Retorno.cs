using Microsoft.AspNetCore.Mvc;

namespace ProjetoSistemaEscolarAPI.Models.Retorno
{
    public class Retorno
    {
        public StatusCodeResult StatusCode { get; set; }
        public string? Message { get; set; }
        public bool? Success { get; set; }
    }
}
