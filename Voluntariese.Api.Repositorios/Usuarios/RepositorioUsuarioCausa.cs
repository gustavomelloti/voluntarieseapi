using Dapper;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;

namespace Voluntariese.Api.Repositorios.Usuarios
{
    public class RepositorioUsuarioCausa : IRepositorioUsuarioCausa
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string QueryConsultarCausas = @"
            SELECT 
                c.Id,
                c.Descricao,
                c.Icone,
                c.Ativo
            FROM 
	            UsuarioCausa uc
                INNER JOIN Causa c ON c.Id = uc.IdCausa
            WHERE
                uc.IdUsuario = @Id
        ";

        private const string QueryInserirCausas = @"
            INSERT INTO UsuarioCausa
            (
                IdUsuario,
                IdCausa
            ) 
            VALUES 
            (
                @IdUsuario,
                @IdCausa
            );
        ";

        private const string QueryDeletarCausas = @"
            DELETE UsuarioCausa WHERE IdUsuario = @IdUsuario
        ";

        public RepositorioUsuarioCausa(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Atualizar(Usuario usuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            conexao.Execute(QueryDeletarCausas, new { IdUsuario = usuario.Id }, _gerenciadorConexao.TransacaoAtiva);
            Inserir(usuario);
        }

        public IList<Causa> Consultar(long idUsuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Causa>(QueryConsultarCausas, 
                new
                {
                    Id = idUsuario
                }, _gerenciadorConexao.TransacaoAtiva).ToList();
        }

        public void Inserir(Usuario usuario)
        {
            if (usuario.CausasInteresse != null)
            {
                var conexao = _gerenciadorConexao.ObterConexao();
                var parametros = usuario.CausasInteresse.Select(causa => new { IdCausa = causa.Id, IdUsuario = usuario.Id });
                conexao.Execute(QueryInserirCausas, parametros, _gerenciadorConexao.TransacaoAtiva);
            }
        }
    }
}
