using System;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Doacoes;

namespace Voluntariese.Api.Aplicacao.Doacoes.Models
{
    public class DoacaoModel
    {
        public long Id { get;  set; }
        public string Descricao { get; set; }
        public UsuarioModel Instituicao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativa { get; set; }

        public DoacaoModel(Doacao doacao)
        {
            Id = doacao.Id;
            Descricao = doacao.Descricao;
            Instituicao = new UsuarioModel(doacao.Instituicao);
            DataCadastro = doacao.DataCadastro;
            Ativa = doacao.Ativa;
            DataAtualizacao = doacao.DataAtualizacao;
        }
    }
}
