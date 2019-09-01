using Dapper;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Dominio.Doacoes;
using Voluntariese.Api.Dominio.Doacoes.Interfaces;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;

namespace Voluntariese.Api.Repositorios.Doacoes
{
    public class RepositorioDoacao : IRepositorioDoacao
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;
        private readonly IRepositorioUsuarioCausa _repositorioUsuarioCausa;

        private const string QueryConsultarDoacoes = @"
            SELECT
                d.Id,
                d.Descricao,
                d.DataCadastro,
                d.Ativa,
                i.Id,
                i.Nome,
                i.Email,
                i.Telefone,
                i.IdFotoPerfil,
                i.DataNascimento,
                e.Id,
                e.Cep,
                e.Estado,
                e.Cidade,
                e.Bairro,
                e.Logradouro,
                e.Numero,
                e.Complemento
            FROM 
                Doacao d
            JOIN 
                Usuario i ON i.Id = d.IdInstituicao
            JOIN Endereco e ON e.Id = i.IdEndereco
            WHERE
                (@Id IS NULL OR @Id = d.Id) AND
                (@Ativa IS NULL OR @Ativa = d.Ativa) AND
                (@IdInstituicao IS NULL OR @IdInstituicao = d.IdInstituicao) AND
                (@IdCausa IS NULL OR (SELECT COUNT(1) FROM UsuarioCausa uc WHERE uc.IdCausa = @IdCausa AND uc.IdUsuario = i.Id) > 0);
        ";

        private const string QueryInserirDoacao = @"
            INSERT INTO Doacao
            (
                Descricao,
                Ativa,
                DataCadastro,
                IdInstituicao
            )
            VALUES
            (
                @Descricao,
                @Ativa,
                @DataCadastro,
                @IdInstituicao
            );
            SELECT SCOPE_IDENTITY();
        ";

        private const string QueryAtualizarOportunidade = @"
            UPDATE Doacao
                SET
                    Descricao = @Descricao,
                    Ativa = @Ativa,
                    DataAtualizacao = SYSDATETIME()
                WHERE Id = @Id
            ";

        public RepositorioDoacao(IGerenciadorConexao gerenciadorConexao, IRepositorioUsuarioCausa repositorioUsuarioCausa)
        {
            _gerenciadorConexao = gerenciadorConexao;
            _repositorioUsuarioCausa = repositorioUsuarioCausa;
        }

        public void Inserir(Doacao doacao)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                doacao.Descricao,
                doacao.Ativa,
                doacao.DataCadastro,
                IdInstituicao = doacao.Instituicao.Id
            };
            var id = conexao.QueryFirst<long>(QueryInserirDoacao, parametros, _gerenciadorConexao.TransacaoAtiva);
            doacao.DefinirId(id);
        }

        public IList<Doacao> Consultar(long? id, bool? ativa, long? idCausa)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Doacao, Usuario, Endereco, Doacao>(QueryConsultarDoacoes,
                MontarDoacao,
                new ParametroConsultaDoacao(id, ativa, idCausa),
                _gerenciadorConexao.TransacaoAtiva).ToList();
        }

        public Doacao Obter(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.Query<Doacao, Usuario, Endereco, Doacao>(QueryConsultarDoacoes, MontarDoacao, 
                new ParametroConsultaDoacao(id), 
                _gerenciadorConexao.TransacaoAtiva).FirstOrDefault();
        }

        public void Atualizar(Doacao doacao)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                doacao.Id,
                doacao.Descricao,
                doacao.Ativa,
                doacao.DataAtualizacao
            };
            conexao.Execute(QueryAtualizarOportunidade, parametros, _gerenciadorConexao.TransacaoAtiva);
        }

        private Doacao MontarDoacao(Doacao doacao, Usuario instituicao, Endereco endereco)
        {
            instituicao.DefinirCausas(_repositorioUsuarioCausa.Consultar(instituicao.Id));
            instituicao.DefinirEndereco(endereco);

            doacao.DefinirInstituicao(instituicao);

            return doacao;
        }

        private class ParametroConsultaDoacao
        {
            public long? Id { get; set; }
            public long? IdCausa { get; set; }
            public long? IdInstituicao { get; set; }
            public bool? Ativa { get; set; }

            public ParametroConsultaDoacao(long id)
            {
                Id = id;
            }

            public ParametroConsultaDoacao(long? idInstituicao, bool? ativa, long? idCausa)
            {
                Ativa = ativa;
                IdInstituicao = idInstituicao;
                IdCausa = idCausa;
            }
        }
    }
}
