using System.Collections.Generic;
using System.Linq;
using Dapper;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Oportunidades.Interfaces;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Repositorios.Oportunidades
{
    public class RepositorioOportunidadeCandidatura : IRepositorioOportunidadeCandidatura
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string QueryInserirCandidatura = @"
            INSERT INTO OportunidadeCandidatura
            (
                IdOportunidade,
                IdVoluntario,
                DataCriacao,
                Aprovada
            )
            VALUES
            (
                @IdOportunidade,
                @IdVoluntario,
                @DataCriacao,
                @Aprovada
            );
            SELECT SCOPE_IDENTITY();
        ";

        private const string QueryConsultarCandidatura = @"
            SELECT
                oc.Id,
                oc.Aprovada,
                oc.DataCriacao,
                oc.DataAtualizacao,
                oc.Justificativa,
                oc.IdOportunidade,
                candidato.Id,
                candidato.Nome,
                candidato.Email,
                candidato.Telefone,
                instituicao.Id,
                instituicao.Nome,
                instituicao.Email
            FROM
                OportunidadeCandidatura oc
            JOIN Usuario candidato ON candidato.Id = oc.IdVoluntario
            JOIN Oportunidade o ON o.Id = oc.IdOportunidade
            JOIN Usuario instituicao ON instituicao.Id = o.IdInstituicao
            WHERE 
                (@Id IS NULL OR oc.Id = @Id) AND
                (@IdOportunidade IS NULL OR oc.IdOportunidade = @IdOportunidade)
        ";

        private const string QueryAtualizarCandidatura = @"
            UPDATE 
                OportunidadeCandidatura
            SET 
                Aprovada = @Aprovada,
                DataAtualizacao = @DataAtualizacao,
                Justificativa = @Justificativa
            WHERE
                Id = @Id
        ";

        public RepositorioOportunidadeCandidatura(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Inserir(Candidatura candidatura)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                candidatura.IdOportunidade,
                IdVoluntario = candidatura.Voluntario.Id,
                candidatura.DataCriacao,
                candidatura.Aprovada
            };
            var id = conexao.QueryFirst<long>(QueryInserirCandidatura, parametros, _gerenciadorConexao.TransacaoAtiva);
            candidatura.DefinirId(id);
        }

        public IList<Candidatura> Consultar(long idOportunidade)
        {
            var conexao = _gerenciadorConexao.ObterConexao();

            return conexao.Query<Candidatura, Usuario, Usuario, Candidatura>(QueryConsultarCandidatura,
                MontarCandidatura, 
                new ParametroConsulta (idOportunidade, true),
                _gerenciadorConexao.TransacaoAtiva).ToList();
        }

        private static Candidatura MontarCandidatura(Candidatura candidatura, Usuario voluntario, Usuario instituicao)
        {
            candidatura.DefinirInstituicao(instituicao);
            candidatura.DefinirVoluntario(voluntario);
            return candidatura;
        }

        public Candidatura Obter(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();

            return conexao.Query<Candidatura, Usuario, Usuario, Candidatura>(QueryConsultarCandidatura,
                MontarCandidatura, new ParametroConsulta(id),
                _gerenciadorConexao.TransacaoAtiva).FirstOrDefault();
        }

        public void Aprovar(Candidatura candidatura)
        {
            Atualizar(candidatura);
        }

        public void Reprovar(Candidatura candidatura)
        {
            Atualizar(candidatura);
        }

        private void Atualizar(Candidatura candidatura)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            conexao.Execute(QueryAtualizarCandidatura,
                new
                {
                    candidatura.Id,
                    candidatura.Aprovada,
                    candidatura.DataAtualizacao,
                    candidatura.Justificativa
                }, _gerenciadorConexao.TransacaoAtiva);
        }

        private class ParametroConsulta
        {
            public long? Id { get; set; }
            public long? IdOportunidade { get; set; }

            public ParametroConsulta(long id)
            {
                Id = id;
            }

            public ParametroConsulta(long idOportunidade, bool porOportunidade)
            {
                IdOportunidade = idOportunidade;
            }
        }
    }
}
