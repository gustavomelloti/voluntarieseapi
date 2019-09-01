using System;
using System.Collections.Generic;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios.Enums;

namespace Voluntariese.Api.Dominio.Usuarios
{
    public class ParametroAtualizacaoUsuario
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Qualificacoes { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public Sexo Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public long? IdFotoPerfil { get; private set; }
        public Endereco Endereco { get; private set; }
        public IList<Causa> CausasInteresse { get; internal set; }

        public ParametroAtualizacaoUsuario ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ParametroAtualizacaoUsuario ComQualificacoes(string qualificacoes)
        {
            Qualificacoes = qualificacoes;
            return this;
        }

        public ParametroAtualizacaoUsuario ComEmail(string email)
        {
            Email = email;
            return this;
        }

        public ParametroAtualizacaoUsuario ComSenha(string senha)
        {
            Senha = senha;
            return this;
        }

        public ParametroAtualizacaoUsuario ComTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public ParametroAtualizacaoUsuario ComDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public ParametroAtualizacaoUsuario ComIdFotoPerfil(long? idFotoPerfil)
        {
            IdFotoPerfil = idFotoPerfil;
            return this;
        }

        public ParametroAtualizacaoUsuario ComEndereco(Endereco endereco)
        {
            Endereco = endereco;
            return this;
        }

        public ParametroAtualizacaoUsuario ComDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
            return this;
        }

        public ParametroAtualizacaoUsuario ComSexo(Sexo sexo)
        {
            Sexo = sexo;
            return this;
        }

        public ParametroAtualizacaoUsuario ComCausasInteresse(IList<Causa> causasInteresse)
        {
            CausasInteresse = causasInteresse;
            return this;
        }
    }
}
