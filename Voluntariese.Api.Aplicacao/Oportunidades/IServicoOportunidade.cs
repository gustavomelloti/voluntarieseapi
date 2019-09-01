using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Oportunidades.Models;
using Voluntariese.Api.Aplicacao.Oportunidades.Requests;

namespace Voluntariese.Api.Aplicacao.Oportunidades
{
    public interface IServicoOportunidade
    {
        IEnumerable<OportunidadeModel> Consultar(long? idCausa);
        IEnumerable<OportunidadeModel> ConsultarDeInstituicoes(long idUsuarioAutenticado);
        IEnumerable<OportunidadeModel> ConsultarDeVoluntarios(long idUsuarioAutenticado);
        
        OportunidadeModel Cadastrar(CadastrarOportunidadeRequest request, long idUsuarioAutenticado);
        OportunidadeModel Atualizar(long id, AtualizarOportunidadeRequest request, long idUsuarioAutenticado);
        void Candidatar(long id, long idUsuarioAutenticado);
        void Aprovar(long id, long idUsuarioAutenticado);
        void Reprovar(long id, long idUsuarioAutenticado, ReprovarCandidaturaRequest request);
    }
}