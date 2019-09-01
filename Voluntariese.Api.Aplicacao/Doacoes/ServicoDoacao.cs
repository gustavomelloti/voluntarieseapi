using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Doacoes.Models;
using Voluntariese.Api.Aplicacao.Doacoes.Requests;
using Voluntariese.Api.Dominio.Doacoes.Interfaces;
using Voluntariese.Api.Dominio.Doacoes.Validacoes;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;

namespace Voluntariese.Api.Aplicacao.Doacoes
{
    public class ServicoDoacao : IServicoDoacao
    {
        private readonly IRepositorioDoacao _repositorioDoacao;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoDoacao(IRepositorioDoacao repositorioDoacao, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioDoacao = repositorioDoacao;
            _repositorioUsuario = repositorioUsuario;
        }

        public DoacaoModel Atualizar(long id, AtualizarDoacaoRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var instituicao = _repositorioUsuario.Obter(idUsuarioAutenticado);
            new ValidacaoAtualizarDoacaoInstituicao().Validar(instituicao);

            var doacao = _repositorioDoacao.Obter(id);
            new ValidacaoAtualizarDoacao(instituicao).Validar(doacao);

            doacao.Atualizar(request.Descricao, request.Ativa);
            
            _repositorioDoacao.Atualizar(doacao);

            return new DoacaoModel(doacao);
        }

        public DoacaoModel Cadastrar(CadastrarDoacaoRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var doacao = request.ParaEntidade(idUsuarioAutenticado);
            _repositorioDoacao.Inserir(doacao);

            return new DoacaoModel(doacao);
        }

        public IList<DoacaoModel> Consultar(long? id, bool? ativa, long? idCausa)
        {
            var doacoes = _repositorioDoacao.Consultar(id, ativa, idCausa);
            return doacoes.Select(doacao => new DoacaoModel(doacao)).ToList();
        }
    }
}
