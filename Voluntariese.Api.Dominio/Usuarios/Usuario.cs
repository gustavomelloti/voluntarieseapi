using System;
using System.Collections.Generic;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios.Enums;

namespace Voluntariese.Api.Dominio.Usuarios
{
    public class Usuario
    {
        public long Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Telefone { get; internal set; }
        public string Descricao { get; internal set; }
        public string Qualificacoes { get; internal set; }
        public string Email { get; internal set; }
        public string Senha { get; internal set; }
        public Sexo? Sexo { get; internal set; }
        public long? IdFotoPerfil { get; internal set; }
        public PerfilUsuario Perfil { get; internal set; }
        public Endereco Endereco { get; internal set; }
        public DateTime DataCadastro { get; internal set; }
        public DateTime DataNascimento { get; internal set; }
        public bool Ativo { get; internal set; }
        public IList<Causa> CausasInteresse { get; internal set; }

        internal Usuario()
        {
            DataCadastro = DateTime.Now;
        }

        public Usuario(long id)
        {
            Id = id;
        }
        
        public bool ValidarSenha(string senha)
        {
            return Senha == senha;
        }

        public void AtualizarSenha(string senha)
        {
            Senha = senha;
        }

        public void DefinirId(long id)
        {
            Id = id;
        }
        
        public void Atualizar(ParametroAtualizacaoUsuario parametroAtualizacao)
        {
            Nome = parametroAtualizacao.Nome;
            Email = parametroAtualizacao.Email;
            IdFotoPerfil = parametroAtualizacao.IdFotoPerfil;
            Endereco = parametroAtualizacao.Endereco;
            Telefone = parametroAtualizacao.Telefone;
            DataNascimento = parametroAtualizacao.DataNascimento;
            Sexo = parametroAtualizacao.Sexo;
            Qualificacoes = parametroAtualizacao.Qualificacoes;
            CausasInteresse = parametroAtualizacao.CausasInteresse;
        }

        public void AtualizarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public void DefinirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void DefinirCausas(IList<Causa> causas)
        {
            CausasInteresse = causas;
        }
    }
}
