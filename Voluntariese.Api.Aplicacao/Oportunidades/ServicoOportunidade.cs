using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Oportunidades.Models;
using Voluntariese.Api.Aplicacao.Oportunidades.Requests;
using Voluntariese.Api.Dominio.Oportunidades.Interfaces;
using Voluntariese.Api.Dominio.Oportunidades.Validacoes;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Infraestrutura.Email;

namespace Voluntariese.Api.Aplicacao.Oportunidades
{
    public class ServicoOportunidade : IServicoOportunidade
    {
        private readonly IRepositorioOportunidade _repositorioOportunidade;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioOportunidadeCandidatura _repositorioOportunidadeCandidatura;
        private readonly IServicoEmail _servicoEmail;

        public ServicoOportunidade(
            IRepositorioOportunidade repositorioOportunidade, 
            IRepositorioUsuario repositorioUsuario,
            IRepositorioOportunidadeCandidatura repositorioOportunidadeCandidatura,
            IServicoEmail servicoEmail)
        {
            _repositorioOportunidade = repositorioOportunidade;
            _repositorioUsuario = repositorioUsuario;
            _repositorioOportunidadeCandidatura = repositorioOportunidadeCandidatura;
            _servicoEmail = servicoEmail;
        }

        public IEnumerable<OportunidadeModel> Consultar(long? idCausa)
        {
            var oportunidades = _repositorioOportunidade.Consultar(idCausa);
            return oportunidades.Select(oportunidade => new OportunidadeModel(oportunidade));
        }

        public OportunidadeModel Cadastrar(CadastrarOportunidadeRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var instituicao = _repositorioUsuario.Obter(idUsuarioAutenticado);

            var oportunidade = request.ParaEntidade(instituicao);
            new ValidacaoCadastroOportunidade().Validar(oportunidade);

            _repositorioOportunidade.Inserir(oportunidade);

            return new OportunidadeModel(oportunidade);
        }

        public OportunidadeModel Atualizar(long id, AtualizarOportunidadeRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var oportunidade = _repositorioOportunidade.Obter(id);
            new ValidacaoAtualizacaoOportunidade(idUsuarioAutenticado).Validar(oportunidade);

            oportunidade.Atualizar(request.ParaEntidade());
            _repositorioOportunidade.Atualizar(oportunidade);

            return new OportunidadeModel(oportunidade);
        }

        public void Candidatar(long id, long idUsuarioAutenticado)
        {
            var oportunidade = _repositorioOportunidade.Obter(id);
            new ValidacaoOportunidadeCandidatura().Validar(oportunidade);

            var voluntario = _repositorioUsuario.Obter(idUsuarioAutenticado);
            new ValidacaoVoluntarioCandidatura(oportunidade).Validar(voluntario);

            var candidatura = oportunidade.Candidatar(voluntario);
            _repositorioOportunidadeCandidatura.Inserir(candidatura);

            _servicoEmail.EnviarEmailCandidatura(candidatura);
        }

        public void Aprovar(long id, long idUsuarioAutenticado)
        {
            var candidatura = _repositorioOportunidadeCandidatura.Obter(id);
            new ValidacaoCandidaturaAprovacao().Validar(candidatura);

            var instituicao = _repositorioUsuario.Obter(idUsuarioAutenticado);
   
            var oportunidade = _repositorioOportunidade.Obter(candidatura.IdOportunidade);
            new ValidacaoOportunidadeAprovacao(candidatura).Validar(oportunidade);

            candidatura.Aprovar();

            _repositorioOportunidadeCandidatura.Aprovar(candidatura);

            _servicoEmail.EnviarEmailCandidaturaAprovada(candidatura);
        }

        public void Reprovar(long id, long idUsuarioAutenticado, ReprovarCandidaturaRequest request)
        {
            request.Validar();

            var candidatura = _repositorioOportunidadeCandidatura.Obter(id);
            new ValidacaoCandidaturaAprovacao().Validar(candidatura);

            var instituicao = _repositorioUsuario.Obter(idUsuarioAutenticado);

            var oportunidade = _repositorioOportunidade.Obter(candidatura.IdOportunidade);
            new ValidacaoOportunidadeAprovacao(candidatura).Validar(oportunidade);

            candidatura.Reprovar(request.Justificativa);

            _repositorioOportunidadeCandidatura.Reprovar(candidatura);

           _servicoEmail.EnviarEmailCandidaturaReprovada(candidatura);
        }

        public IEnumerable<OportunidadeModel> ConsultarDeInstituicoes(long idUsuarioAutenticado)
        {
            var oportunidades = _repositorioOportunidade.ConsultarDeInstituicoes(idUsuarioAutenticado);
            return oportunidades.Select(oportunidade => new OportunidadeModel(oportunidade));
        }

        public IEnumerable<OportunidadeModel> ConsultarDeVoluntarios(long idUsuarioAutenticado)
        {
            var oportunidades = _repositorioOportunidade.ConsultarDeVoluntarios(idUsuarioAutenticado);
            return oportunidades.Select(oportunidade => new OportunidadeModel(oportunidade));
        }
    }
}