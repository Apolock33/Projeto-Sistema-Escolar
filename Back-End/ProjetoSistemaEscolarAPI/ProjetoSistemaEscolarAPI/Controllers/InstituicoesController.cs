using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSistemaEscolarAPI.Models;
using ProjetoSistemaEscolarAPI.Models.Context;
using ProjetoSistemaEscolarAPI.Models.Retorno;

namespace ProjetoSistemaEscolarAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class InstituicoesController : Controller
    {
        private readonly AppDbContext _context;

        public InstituicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        [HttpGet("/api/v1/[controller]/getlist")]
        public Task<IEnumerable<Instituicao>?> GetInstituicoes()
        {
            Retorno retorno = new Retorno();

            var getListaInstituicao = _context.Instituicao.AsEnumerable();

            if (getListaInstituicao == null)
            {
                retorno.Success = true;
                retorno.Message = "Nenhuma Instituição Encontrada!";
                retorno.StatusCode = StatusCode(200);
            }
            else
            {
                retorno.Success = true;
                retorno.Message = "";
                retorno.StatusCode = StatusCode(200);
            }
            return Task.FromResult(getListaInstituicao);
        }

        [HttpGet("/api/v1/[controller]/getInstituicaobyid/{id}")]
        public Task<Instituicao> GetInstituicaoById(Guid idInstituicao)
        {
            Retorno retorno = new Retorno();

            var getInstituicao = _context.Instituicao.Find(idInstituicao);

            if (getInstituicao == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhuma Instituição Encontrada!";
                retorno.StatusCode = StatusCode(500);
            }
            else
            {
                retorno.Success = true;
                retorno.Message = "";
                retorno.StatusCode = StatusCode(200);
            }

            return Task.FromResult(getInstituicao);
        }

        //[HttpPost("/api/v1/[controller]/postinstituicao")]
        //public Task<Instituicao> GetInstituicaoById(Instituicao instituicao)
        //{

        //}

    }
}
