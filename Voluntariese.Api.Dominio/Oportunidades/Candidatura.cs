using System;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Dominio.Oportunidades
{
    public class Candidatura
    {
        public long Id { get; internal set; }
        public long IdOportunidade { get; internal set; }
        public Usuario Instituicao { get; internal set; }
        public Usuario Voluntario { get; internal set; }
        public bool? Aprovada { get; internal set; }
        public DateTime DataCriacao { get; internal set; }
        public DateTime DataAtualizacao { get; internal set; }
        public string Justificativa { get; internal set; }

        public Candidatura() { }

        public Candidatura(Usuario instituicao, Usuario voluntario, long idOportunidade)
        {
            Instituicao = instituicao;
            Voluntario = voluntario;
            DataCriacao = DateTime.Now;
            IdOportunidade = idOportunidade;
        }

        public void DefinirId(long id)
        {
            Id = id;
        }

        public void DefinirInstituicao(Usuario instituicao)
        {
            Instituicao = instituicao;
        }

        public void DefinirVoluntario(Usuario voluntario)
        {
            Voluntario = voluntario;
        }

        public void Aprovar()
        {
            Aprovada = true;
            DataAtualizacao = DateTime.Now;
        }

        public void Reprovar(string justificativa)
        {
            Aprovada = false;
            DataAtualizacao = DateTime.Now;
            Justificativa = justificativa;
        }
    }
}
