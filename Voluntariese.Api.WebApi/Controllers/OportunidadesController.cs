using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Oportunidades;
using Voluntariese.Api.Aplicacao.Oportunidades.Models;
using Voluntariese.Api.Aplicacao.Oportunidades.Requests;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/oportunidades")]
    public class OportunidadesController : ApiController
    {
        private readonly IServicoOportunidade _servicoOportunidade;

        public OportunidadesController(IServicoOportunidade servicoOportunidade)
        {
            _servicoOportunidade = servicoOportunidade;
        }

        /// <summary>
        /// Endpoint para consultar as oportunidades.
        /// </summary>
        /// <returns>As oportunidades</returns>
        [HttpGet]
        public IEnumerable<OportunidadeModel> Consultar([FromQuery] long? idCausa) 
            => _servicoOportunidade.Consultar(idCausa);

        /// <summary>
        /// Endpoint para consultar as oportunidades de uma instituição.
        /// </summary>
        /// <returns>As oportunidades</returns>
        [HttpGet("instituicao")]
        [Authorize]
        public IEnumerable<OportunidadeModel> ConsultarDeInsituicoes()
            => _servicoOportunidade.ConsultarDeInstituicoes(IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para consultar as oportunidades de um voluntário.
        /// </summary>
        /// <returns>As oportunidades</returns>
        [HttpGet("voluntario")]
        [Authorize]
        public IEnumerable<OportunidadeModel> ConsultarDeVoluntarios()
            => _servicoOportunidade.ConsultarDeVoluntarios(IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para cadastrar oportunidade.
        /// </summary>
        /// <returns>A oportunidade criada</returns>
        [HttpPost]
        [Authorize]
        public OportunidadeModel Cadastrar([FromBody] CadastrarOportunidadeRequest request) 
            => _servicoOportunidade.Cadastrar(request, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para atualizar oportunidade.
        /// </summary>
        /// <returns>A oportunidade atualizada</returns>
        [HttpPut("{id}")]
        [Authorize]
        public OportunidadeModel Atualizar(long id, [FromBody] AtualizarOportunidadeRequest request) 
            => _servicoOportunidade.Atualizar(id, request, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para candidatar-se a oportunidade.
        /// </summary>
        [HttpPost("{id}/candidatura")]
        [Authorize]
        public void Candidatar(long id)  => _servicoOportunidade.Candidatar(id, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para aprovar candidatura.
        /// </summary>
        [HttpPost("{id}/aprovacao")]
        [Authorize]
        public void Aprovar(long id) => _servicoOportunidade.Aprovar(id, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para reprovar candidatura.
        /// </summary>
        [HttpPost("{id}/reprovacao")]
        [Authorize]
        public void Reprovar(long id, [FromBody] ReprovarCandidaturaRequest request)
            => _servicoOportunidade.Reprovar(id, IdUsuarioAutenticado, request);
    }
}