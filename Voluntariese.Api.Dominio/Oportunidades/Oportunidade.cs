using System;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Dominio.Oportunidades
{
    public class Oportunidade
    {
        public long Id { get; internal set; }
        public string Descricao { get; internal set; }
        public string Qualificacoes { get; internal set; }
        public DateTime DataCriacao { get; internal set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; internal set; }
        public bool Ativa { get; internal set; } = true;
        public Causa Causa { get; internal set; }
        public string Turno { get; internal set; }
        public int QuantidadeVagas { get; internal set; }
        public Usuario Instituicao { get; internal set; }
        public IList<Candidatura> Candidatos { get; internal set; }
        public bool EstaAtiva => Ativa;
        public bool QuantidadeVagasPositivas => QuantidadeVagas > 0; 

        public void DefinirId(long id)
        {
            Id = id;
        }

        public bool InstituicaoVinculada(long idInstituicao)
        {
            return idInstituicao == Instituicao.Id;
        }

        public bool CandidatoVinculado(long idCandidato)
        {
            if (Candidatos == null)
                return false;

            return Candidatos.FirstOrDefault(candidato => candidato.Voluntario.Id == idCandidato) != null;
        }

        public void Atualizar(ParametroAtualizacaoOportunidade parametro)
        {
            Descricao = parametro.Descricao;
            Qualificacoes = parametro.Qualificacoes;
            Causa = parametro.Causa;
            Turno = parametro.Turno;
            QuantidadeVagas = parametro.QuantidadeVagas;
            Ativa = parametro.Ativa;
        }

        public Candidatura Candidatar(Usuario usuario)
        {
            return new Candidatura(Instituicao, usuario, Id);
        }
    }
}