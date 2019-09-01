using System;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Enums;

namespace Voluntariese.Api.Aplicacao.Usuarios.Models
{
    public class UsuarioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Qualificacoes { get; set; }
        public IList<Causa> Causas { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Sexo? Sexo { get; set; }
        public long? IdFotoPerfil { get; set; }
        public PerfilUsuarioModel Perfil { get; set; }
        public EnderecoModel Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public IList<CausaModel> CausasInteresse { get; set; }

        private UsuarioModel() { }

        public UsuarioModel(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            IdFotoPerfil = usuario.IdFotoPerfil;
            if (usuario.Perfil != null)
                Perfil = new PerfilUsuarioModel(usuario.Perfil);
            if (usuario.Endereco != null)
                Endereco = new EnderecoModel(usuario.Endereco);
            if (usuario.CausasInteresse != null)
                CausasInteresse = usuario.CausasInteresse.Select(causa => new CausaModel(causa)).ToList();
            Ativo = usuario.Ativo;
            DataCadastro = usuario.DataCadastro;
            Telefone = usuario.Telefone;
            DataNascimento = usuario.DataNascimento;
            Sexo = usuario.Sexo;
            Qualificacoes = usuario.Qualificacoes;
        }
    }
}
