using Microsoft.AspNetCore.Mvc;
using Voluntariese.Api.Aplicacao.Contatos;
using Voluntariese.Api.Aplicacao.Contatos.Models;
using Voluntariese.Api.Aplicacao.Contatos.Requests;
using System.Threading.Tasks;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/contatos")]
    public class ContatosController : ApiController
    {
        private readonly IServicoContato _servicoContato;

        public ContatosController(IServicoContato servicoContato)
        {
            _servicoContato = servicoContato;
        }

        /// <summary>
        /// Endpoint para cadastrar contatos realizados pelo site.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>O contato</returns>
        [HttpPost]
        public async Task<ContatoModel> Cadastrar([FromBody]CadastrarContatoRequest request) 
            => await _servicoContato.Cadastrar(request);
    }
}
