using Dapper;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Oportunidades.Builders;
using Voluntariese.Api.Dominio.Oportunidades.Interfaces;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;

namespace Voluntariese.Api.Repositorios.Oportunidades
{
    public class RepositorioOportunidade : IRepositorioOportunidade
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;
        private readonly IRepositorioUsuarioCausa _repositorioUsuarioCausa;
        private readonly IRepositorioOportunidadeCandidatura _repositorioOportunidadeCandidatura;

        private const string QueryConsultarOportunidades = @"
            SELECT
                o.Id,
                o.Descricao,
                o.Qualificacoes,
                o.DataCriacao,
                o.DataAtualizacao,
                o.Ativa,
                o.Turno,
                o.QuantidadeVagas,
                o.Qualificacoes,
                c.Id,
                c.Descricao,
                c.Icone,
                i.Id,
                i.Nome,
                i.Email,
                i.Telefone,
                i.IdFotoPerfil,
                e.Id,
                e.Cidade,
                e.Estado,
                e.Numero,
                e.Bairro,
                e.Logradouro
            FROM 
                Oportunidade o
            JOIN 
                Causa c ON c.Id = o.IdCausa
            JOIN 
                Usuario i ON i.Id = o.IdInstituicao
            JOIN
                Endereco e ON e.Id = i.IdEndereco
            WHERE
                (@Id IS NULL OR @Id = o.Id) AND
                (@Ativa IS NULL OR @Ativa = o.Ativa) AND
                (@IdCausa IS NULL OR @IdCausa = o.IdCausa) AND
                (@IdInstituicao IS NULL OR @IdInstituicao = o.IdInstituicao)
        ";

        private const string QueryConsultarOportunidadesVoluntario = @"
            SELECT
                o.Id,
                o.Descricao,
                o.Qualificacoes,
                o.DataCriacao,
                o.DataAtualizacao,
                o.Ativa,
                o.Turno,
                o.QuantidadeVagas,
                o.Qualificacoes,
                c.Id,
                c.Descricao,
                c.Icone,
                i.Id,
                i.Nome,
                i.Email,
                i.Telefone,
                i.IdFotoPerfil,
                e.Id,
                e.Cidade,
                e.Estado,
                e.Numero,
                e.Bairro,
                e.Logradouro
            FROM 
                Oportunidade o
            JOIN 
                Causa c ON c.Id = o.IdCausa
            JOIN 
                Usuario i ON i.Id = o.IdInstituicao
            JOIN
                Endereco e ON e.Id = i.IdEndereco
            JOIN
                OportunidadeCandidatura oc ON oc.IdOportunidade = o.id
            WHERE
                o.Ativa = 1 AND oc.IdVoluntario = @IdVoluntario
        ";

        private const string QueryInserirOportunidades = @"
            INSERT INTO Oportunidade
            (
                Descricao,
                Qualificacoes,
                DataCriacao,
                Ativa,
                IdCausa,
                Turno,
                QuantidadeVagas,
                IdInstituicao
            )
            VALUES
            (
                @Descricao,
                @Qualificacoes,
                @DataCriacao,
                @Ativa,
                @IdCausa,
                @Turno,
                @QuantidadeVagas,
                @IdInstituicao
            );
            SELECT SCOPE_IDENTITY();
        ";

        private const string QueryAtualizarOportunidade = @"
            UPDATE Oportunidade
                SET
                    Descricao = @Descricao,
                    Qualificacoes = @Qualificacoes,
                    IdCausa = @IdCausa,
                    Turno = @Turno,
                    QuantidadeVagas = @QuantidadeVagas,
                    Ativa = @Ativa,
                    DataAtualizacao = SYSDATETIME()
                WHERE Id = @Id
            ";
        
        public RepositorioOportunidade(IGerenciadorConexao gerenciadorConexao, 
            IRepositorioOportunidadeCandidatura repositorioOportunidadeCandidatura,
            IRepositorioUsuarioCausa repositorioUsuarioCausa)
        {
            _gerenciadorConexao = gerenciadorConexao;
            _repositorioOportunidadeCandidatura = repositorioOportunidadeCandidatura;
            _repositorioUsuarioCausa = repositorioUsuarioCausa;
        }

        public void Inserir(Oportunidade oportunidade)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                oportunidade.Descricao,
                oportunidade.Qualificacoes,
                oportunidade.DataCriacao,
                oportunidade.Ativa,
                IdCausa = oportunidade.Causa.Id,
                oportunidade.Turno,
                oportunidade.QuantidadeVagas,   
                IdInstituicao = oportunidade.Instituicao.Id
            };
            var id = conexao.QueryFirst<long>(QueryInserirOportunidades, parametros, _gerenciadorConexao.TransacaoAtiva);
            oportunidade.DefinirId(id);
        }

        public IEnumerable<Oportunidade> Consultar(long? idCausa)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Oportunidade, Causa, Usuario, Endereco, Oportunidade>(QueryConsultarOportunidades, 
                MontarOportunidade, 
                new ParametroConsultaOportunidade(idCausa, true), 
                _gerenciadorConexao.TransacaoAtiva);
        }

        public void Atualizar(Oportunidade oportunidade)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                oportunidade.Descricao,
                oportunidade.Qualificacoes,
                IdCausa = oportunidade.Causa.Id,
                oportunidade.Turno,
                oportunidade.QuantidadeVagas,
                oportunidade.Ativa,
                oportunidade.Id
            };
            conexao.Execute(QueryAtualizarOportunidade, parametros, _gerenciadorConexao.TransacaoAtiva);
        }

        public Oportunidade Obter(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Oportunidade, Causa, Usuario, Endereco, Oportunidade>(QueryConsultarOportunidades, MontarOportunidade, new ParametroConsultaOportunidade(id), _gerenciadorConexao.TransacaoAtiva).FirstOrDefault();
        }

        private Oportunidade MontarOportunidade(Oportunidade oportunidade, Causa causa, Usuario instituicao, Endereco endereco)
        {
            instituicao.DefinirCausas(_repositorioUsuarioCausa.Consultar(instituicao.Id));

            return new OportunidadeBuilder()
                .APartir(oportunidade)
                .ComCausa(causa)
                .ComInstituicao(instituicao)
                .ComInstituicaoEndereco(endereco)
                .ComCandidatos(_repositorioOportunidadeCandidatura.Consultar(oportunidade.Id))
                .Construir();
        }

        public IEnumerable<Oportunidade> ConsultarDeInstituicoes(long idUsuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Oportunidade, Causa, Usuario, Endereco, Oportunidade>(QueryConsultarOportunidades,
                MontarOportunidade,
                new ParametroConsultaOportunidade() { IdInstituicao = idUsuario },
                _gerenciadorConexao.TransacaoAtiva);
        }

        public IEnumerable<Oportunidade> ConsultarDeVoluntarios(long idUsuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Oportunidade, Causa, Usuario, Endereco, Oportunidade>(QueryConsultarOportunidadesVoluntario,
                MontarOportunidade,
                new ParametroConsultaOportunidade() { IdVoluntario = idUsuario },
                _gerenciadorConexao.TransacaoAtiva);
        }

        private class ParametroConsultaOportunidade
        {
            public long? Id { get; set; }
            public long? IdInstituicao { get; set; }
            public long? IdVoluntario { get; set; }
            public bool? Ativa { get; set; }
            public long? IdCausa { get; set; }

            public ParametroConsultaOportunidade()
            {
                    
            }

            public ParametroConsultaOportunidade(long id)
            {
                Id = id;
            }

            public ParametroConsultaOportunidade(long? idCausa, bool ativa)
            {
                IdCausa = idCausa;
                Ativa = ativa;
            }
        }
    }
}