using Dapper;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Autenticacao.Interfaces;

namespace Voluntariese.Api.Repositorios.Autenticacao
{
    public class RepositorioHistoricoLogin : IRepositorioHistoricoLogin
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string InsertHistoricoLogin = @"INSERT INTO HistoricoLogin (IdUsuario, TokenAutenticacao, EnderecoIp, DataCriacao) VALUES (@IdUsuario, @TokenAutenticacao, @EnderecoIp, SYSDATETIME())";

        public RepositorioHistoricoLogin(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Inserir(HistoricoLogin historicoLogin)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            conexao.Execute(InsertHistoricoLogin, historicoLogin, _gerenciadorConexao.TransacaoAtiva);
        }
    }
}
