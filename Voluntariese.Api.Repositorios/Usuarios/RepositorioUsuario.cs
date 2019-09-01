using System.Collections.Generic;
using System.Linq;
using Dapper;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Builders;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;

namespace Voluntariese.Api.Repositorios.Usuarios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;
        private readonly IRepositorioUsuarioCausa _repositorioUsuarioCausa;
        
        private const string QueryObterUsuario = @"
            SELECT 
	            u.Id,
	            u.Nome,
	            u.Telefone,
	            u.Descricao,
                u.Qualificacoes,
                u.Email,
                u.Senha,
                u.Sexo,
                u.IdFotoPerfil,
	            u.DataCriacao DataCadastro,
                u.DataNascimento,
                u.Ativo,
                e.Id,
                e.Cep,
                e.Estado,
                e.Cidade,
                e.Bairro,
                e.Logradouro,
                e.Numero,
                e.Complemento,
	            p.Id,
	            p.Nome,
	            p.Codigo
            FROM 
	            Usuario u
                INNER JOIN Endereco e ON e.Id = u.IdEndereco
                INNER JOIN PerfilUsuario p ON p.Id = u.IdPerfil
            WHERE
                (@Email IS NULL OR u.Email = @Email) AND
                (@Id IS NULL OR u.Id = @Id) AND
                (@IdPerfil IS NULL OR u.IdPerfil = @IdPerfil) AND
                (@IdCausa IS NULL OR (SELECT COUNT(1) FROM UsuarioCausa uc WHERE uc.IdCausa = @IdCausa AND uc.IdUsuario = u.Id) > 0);
        ";

        private const string UpdateSenha = @"UPDATE Usuario SET Senha = @Senha, DataAtualizacao = SYSDATETIME() WHERE Id = @Id";

        private const string QueryEmailExiste = @"SELECT 1 FROM Usuario u WHERE u.Email = @Email AND u.Id <> @Id";

        private const string InsertUsuario = @"
            INSERT INTO Usuario 
            (
                Nome, 
                Email, 
                Senha,
                Telefone,
                IdFotoPerfil,
                IdPerfil,
                IdEndereco,
                Ativo,
                DataCriacao,
                DataNascimento,
                Sexo,
                Descricao,
                Qualificacoes
            ) 
            VALUES 
            (
                @Nome, 
                @Email, 
                @Senha,
                @Telefone,
                @IdFotoPerfil,
                @IdPerfil,
                @IdEndereco,
                @Ativo, 
                @DataCadastro,
                @DataNascimento,
                @Sexo,
                @Descricao,
                @Qualificacoes
            );
            SELECT SCOPE_IDENTITY();
        ";

        private const string UpdateUsuario = @"
            UPDATE 
                Usuario 
            SET 
                Nome = @Nome, 
                Email = @Email,
                Ativo = @Ativo, 
                Telefone = @Telefone,
                IdFotoPerfil = @IdFotoPerfil,
                IdEndereco = @IdEndereco,
                DataNascimento = @DataNascimento,
                Sexo = @Sexo,
                DataAtualizacao = SYSDATETIME(),
                Descricao = @Descricao,
                Qualificacoes = @Qualificacoes
            WHERE
                Id = @Id
        ";

        private const string QueryObterPerfilUsuario = @"
            SELECT
                p.Id,
                p.Nome,
                p.Codigo
            FROM
                PerfilUsuario p
            WHERE
                p.Codigo = @Codigo
        ";

        public RepositorioUsuario(IGerenciadorConexao gerenciadorConexao, IRepositorioUsuarioCausa repositorioUsuarioCausa)
        {
            _gerenciadorConexao = gerenciadorConexao;
            _repositorioUsuarioCausa = repositorioUsuarioCausa;
        }

        public Usuario Obter(long id)
        {
            return Obter(new ParametroConsultaUsuario(id));
        }
        
        public Usuario Obter(string email)
        {
            return Obter(new ParametroConsultaUsuario(email));
        }

        private Usuario Obter(ParametroConsultaUsuario parametroConsulta)
        {
            var conexao = _gerenciadorConexao.ObterConexao();

            return conexao
                .Query<Usuario, Endereco, PerfilUsuario, Usuario>(QueryObterUsuario, 
                    MontarUsuario,
                    parametroConsulta)
                .FirstOrDefault();
        }

        public PerfilUsuario ObterPerfil(string codigo)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirst<PerfilUsuario>(QueryObterPerfilUsuario, new { Codigo = codigo },
                _gerenciadorConexao.TransacaoAtiva);
        }

        public void AtualizarSenha(Usuario usuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            conexao.Execute(UpdateSenha, usuario, _gerenciadorConexao.TransacaoAtiva);
        }
        
        public bool EmailExiste(string email, long id = 0)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirstOrDefault<bool>(QueryEmailExiste, new { Email = email, Id = id }, _gerenciadorConexao.TransacaoAtiva);
        }

        public void Inserir(Usuario usuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();

            var parametros = new
            {
                usuario.Nome,
                usuario.Email,
                usuario.Senha,
                IdFotoPerfil = usuario.IdFotoPerfil == 0 ? null : usuario.IdFotoPerfil,
                IdPerfil = usuario.Perfil.Id,
                IdEndereco = usuario.Endereco.Id,
                usuario.Ativo,
                usuario.DataCadastro,
                usuario.DataNascimento,
                usuario.Telefone,
                usuario.Sexo,
                usuario.Descricao,
                usuario.Qualificacoes
            };
            var id = conexao.QueryFirst<long>(InsertUsuario, parametros, _gerenciadorConexao.TransacaoAtiva);
            usuario.DefinirId(id);
        }

        public void Atualizar(Usuario usuario)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Descricao,
                IdFotoPerfil = usuario.IdFotoPerfil > 0 ? usuario.IdFotoPerfil : null,
                IdEndereco = usuario?.Endereco?.Id,
                usuario.DataNascimento,
                usuario.Telefone,
                usuario.Ativo,
                usuario.Sexo,
                usuario.Qualificacoes
            };
            conexao.Execute(UpdateUsuario, parametros, _gerenciadorConexao.TransacaoAtiva);
        }

        private Usuario MontarUsuario(Usuario usuario, Endereco endereco, PerfilUsuario perfilUsuario)
        {
            return new UsuarioBuilder()
                .APartir(usuario)
                .ComEndereco(endereco)
                .ComPerfilUsuario(perfilUsuario)
                .ComCausasInteresse(_repositorioUsuarioCausa.Consultar(usuario.Id))
                .Construir();
        }

        public IList<Usuario> ConsultarVoluntarios(long? idCausa)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao
                .Query<Usuario, Endereco, PerfilUsuario, Usuario>(QueryObterUsuario,
                    MontarUsuario,
                    new ParametroConsultaUsuario() { IdPerfil  = 1, IdCausa = idCausa}).ToList();
        }

        private class ParametroConsultaUsuario
        {
            public long? Id { get; set; }
            public long? IdPerfil { get; set; }
            public long? IdCausa { get; set; }
            public string Email { get; set; }

            public ParametroConsultaUsuario() { }

            public ParametroConsultaUsuario(long id)
            {
                Id = id;
            }

            public ParametroConsultaUsuario(string email)
            {
                Email = email;
            }
        }
    }
}
