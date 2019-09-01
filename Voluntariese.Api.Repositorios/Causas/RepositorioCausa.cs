using System.Collections.Generic;
using Dapper;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Causas.Interfaces;

namespace Voluntariese.Api.Repositorios.Causas
{
    public class RepositorioCausa : IRepositorioCausa
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string QueryConsultarCausas = @"
            SELECT
                Id,
                Descricao,
                Icone,
                Ativo
            FROM
                Causa
            WHERE
                Ativo = 1
        ";

        public RepositorioCausa(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public IEnumerable<Causa> Consultar()
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Causa>(QueryConsultarCausas, _gerenciadorConexao.TransacaoAtiva);
        }
    }
}
