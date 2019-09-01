using System;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Oportunidades;

namespace Voluntariese.Api.Aplicacao.Oportunidades.Models
{
    public class OportunidadeModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Qualificacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativa { get; set; }
        public CausaModel Causa { get; set; }
        public string Turno { get; set; }
        public int QuantidadeVagas { get; set; }
        public UsuarioModel Instituicao { get; set; }
        public IList<CandidaturaModel> Interessados { get; set; }

        public OportunidadeModel(Oportunidade oportunidade)
        {
            Id = oportunidade.Id;
            Descricao = oportunidade.Descricao;
            DataCriacao = oportunidade.DataCriacao;
            DataAtualizacao = oportunidade.DataAtualizacao;
            Qualificacoes = oportunidade.Qualificacoes;
            Ativa = oportunidade.Ativa;
            Causa = new CausaModel(oportunidade.Causa);
            Turno = oportunidade.Turno;
            QuantidadeVagas = oportunidade.QuantidadeVagas;
            Instituicao = new UsuarioModel(oportunidade.Instituicao);
            if (oportunidade.Candidatos != null)
                Interessados = oportunidade.Candidatos.Select(candidato => new CandidaturaModel(candidato)).ToList();
        }
    }
}