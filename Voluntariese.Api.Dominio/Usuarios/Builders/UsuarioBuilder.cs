using System;
using System.Collections;
using System.Collections.Generic;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios.Enums;

namespace Voluntariese.Api.Dominio.Usuarios.Builders
{
    public class UsuarioBuilder
    {
        private readonly Usuario _usuario = new Usuario();

        public UsuarioBuilder APartir(Usuario usuario)
        {
            _usuario.Id = usuario.Id;
            _usuario.Nome = usuario.Nome;
            _usuario.Qualificacoes = usuario.Qualificacoes;
            _usuario.Senha = usuario.Senha;
            _usuario.Email = usuario.Email;
            _usuario.IdFotoPerfil = usuario.IdFotoPerfil;
            _usuario.Endereco = usuario.Endereco;
            _usuario.Ativo = usuario.Ativo;
            _usuario.DataCadastro = usuario.DataCadastro;
            _usuario.DataNascimento = usuario.DataNascimento;
            _usuario.Telefone = usuario.Telefone;
            _usuario.Sexo = usuario.Sexo;
            _usuario.Descricao = usuario.Descricao;
            return this;
        }

        public UsuarioBuilder ComNome(string nome)
        {
            _usuario.Nome = nome;
            return this;
        }

        public UsuarioBuilder ComDescricao(string descricao)
        {
            _usuario.Descricao = descricao;
            return this;
        }

        public UsuarioBuilder ComQualificacoes(string qualificacoes)
        {
            _usuario.Qualificacoes = qualificacoes;
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            _usuario.Senha = senha;
            return this;
        }

        public UsuarioBuilder ComEmail(string email)
        {
            _usuario.Email = email;
            return this;
        }
        
        public UsuarioBuilder ComAtivo(bool ativo)
        {
            _usuario.Ativo = ativo;
            return this;
        }

        public UsuarioBuilder ComIdFotoPerfil(long? idFotoPerfil)
        {
            _usuario.IdFotoPerfil = idFotoPerfil;
            return this;
        }
        public UsuarioBuilder ComEndereco(Endereco endereco)
        {
            _usuario.Endereco = endereco;
            return this;
        }

        public UsuarioBuilder ComPerfilUsuario(PerfilUsuario perfil)
        {
            _usuario.Perfil = perfil;
            return this;
        }

        public UsuarioBuilder ComTelefone(string telefone)
        {
            _usuario.Telefone = telefone;
            return this;
        }

        public UsuarioBuilder ComDataNascimento(DateTime dataNascimento)
        {
            _usuario.DataNascimento = dataNascimento;
            return this;
        }

        public UsuarioBuilder ComSexo(Sexo? sexo)
        {
            _usuario.Sexo = sexo;
            return this;
        }

        public UsuarioBuilder ComCausasInteresse(IList<Causa> causasInteresse)
        {
            _usuario.CausasInteresse = causasInteresse;
            return this;
        }

        public Usuario Construir()
        {
            if (string.IsNullOrEmpty(_usuario.Nome))
                throw new EntidadeEmEstadoInvalidoException(nameof(_usuario.Nome));

            if (string.IsNullOrEmpty(_usuario.Email))
                throw new EntidadeEmEstadoInvalidoException(nameof(_usuario.Email));

            if (_usuario.Perfil == null)
                throw new EntidadeEmEstadoInvalidoException(nameof(_usuario.Perfil));

            return _usuario;
        }
    }
}
