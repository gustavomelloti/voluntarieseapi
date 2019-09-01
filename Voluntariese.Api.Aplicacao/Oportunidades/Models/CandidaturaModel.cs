using System;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Oportunidades;

namespace Voluntariese.Api.Aplicacao.Oportunidades.Models
{
    public class CandidaturaModel
    {
        public long Id { get; set; }
        public long IdOportunidade { get; set; }
        public UsuarioModel Instituicao { get; set; }
        public UsuarioModel Voluntario { get; set; }
        public bool? Aprovada { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string Justificativa { get; set; }

        public CandidaturaModel(Candidatura candidatura)
        {
            Id = candidatura.Id;
            IdOportunidade = candidatura.IdOportunidade;
            Instituicao = new UsuarioModel(candidatura.Instituicao);
            Voluntario = new UsuarioModel(candidatura.Voluntario);
            Aprovada = candidatura.Aprovada;
            DataCriacao = candidatura.DataCriacao;
            DataAtualizacao = candidatura.DataAtualizacao;
            Justificativa = candidatura.Justificativa;
        }
    }
}
