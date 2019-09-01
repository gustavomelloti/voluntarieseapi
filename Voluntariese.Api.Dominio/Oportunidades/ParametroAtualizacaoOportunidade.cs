using Voluntariese.Api.Dominio.Causas;

namespace Voluntariese.Api.Dominio.Oportunidades
{
    public class ParametroAtualizacaoOportunidade
    {
        public string Descricao { get; internal set; }
        public string Qualificacoes { get; internal set; }
        public Causa Causa { get; internal set; }
        public string Turno { get; internal set; }
        public int QuantidadeVagas { get; internal set; }
        public bool Ativa { get; internal set; }
    }
}
