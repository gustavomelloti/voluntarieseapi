using System.Linq;
using Dapper;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Autenticacao.Builders;
using Voluntariese.Api.Dominio.Autenticacao.Interfaces;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Builders;

namespace Voluntariese.Api.Repositorios.Autenticacao
{
    public class RepositorioTokenRecuperacaoSenha : IRepositorioTokenRecuperacaoSenha
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string InsertTokenRecuperacaoSenha = @"
            INSERT INTO TokenRecuperacaoSenha (IdUsuario, Token, DataValidade, DataCriacao) VALUES
            (@IdUsuario, @Token, @DataValidade, SYSDATETIME())";


        private const string QueryObterTokenRecuperacaoSenha = @"
            SELECT
	            tk.Id,
	            tk.Token,
	            tk.DataValidade,
	            tk.DataUtilizacao,
                u.Id,
	            u.Nome,
	            u.Email,
                u.Telefone,
	            u.Senha,
	            u.Ativo,
                u.DataCriacao DataCadastro,
	            p.Id,
	            p.Nome,
	            p.Codigo
            FROM	
	            TokenRecuperacaoSenha tk
	            INNER JOIN Usuario u ON u.Id = tk.IdUsuario
                INNER JOIN PerfilUsuario p ON p.Id = u.IdPerfil
            WHERE
	            tk.Token = @Token";


        private const string UpdateTokenRecuperacaoSenha = @"UPDATE TokenRecuperacaoSenha SET DataUtilizacao = @DataUtilizacao WHERE IdUsuario = @IdUsuario AND DataUtilizacao IS NULL";

        private const string QueryTokenExiste = @"SELECT 1 FROM TokenRecuperacaoSenha WHERE Token = @Token AND DataUtilizacao IS NULL AND DataValidade > SYSDATETIME()";

        public RepositorioTokenRecuperacaoSenha(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Inserir(TokenRecuperacaoSenha tokenRecuperacaoSenha)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                IdUsuario = tokenRecuperacaoSenha.Usuario.Id,
                tokenRecuperacaoSenha.Token,
                tokenRecuperacaoSenha.DataValidade
            };

            conexao.Execute(InsertTokenRecuperacaoSenha, parametros, _gerenciadorConexao.TransacaoAtiva);
        }

        public TokenRecuperacaoSenha Obter(string token)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<TokenRecuperacaoSenha, Usuario, PerfilUsuario, TokenRecuperacaoSenha>(QueryObterTokenRecuperacaoSenha, 
                MontarTokenRecuperacaoSenha, new { Token = token }, _gerenciadorConexao.TransacaoAtiva).FirstOrDefault();
        }

        public bool TokenExiste(string token)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirstOrDefault<bool>(QueryTokenExiste, new {Token = token}, _gerenciadorConexao.TransacaoAtiva);
        }

        public void Utilizar(TokenRecuperacaoSenha tokenRecuperacaoSenha)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                IdUsuario = tokenRecuperacaoSenha.Usuario.Id,
                tokenRecuperacaoSenha.DataUtilizacao
            };
            conexao.Execute(UpdateTokenRecuperacaoSenha, parametros, _gerenciadorConexao.TransacaoAtiva);
        }

        private static TokenRecuperacaoSenha MontarTokenRecuperacaoSenha(TokenRecuperacaoSenha tokenRecuperacaoSenha, Usuario usuario, PerfilUsuario perfilUsuario)
        {
            var usuarioComPerfil = new UsuarioBuilder()
                .APartir(usuario)
                .ComPerfilUsuario(perfilUsuario)
                .Construir();

            return new TokenRecuperacaoSenhaBuilder()
                .APartir(tokenRecuperacaoSenha)
                .ComUsuario(usuarioComPerfil)
                .Construir();
        }
    }
}
