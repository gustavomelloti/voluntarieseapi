using Voluntariese.Api.Aplicacao.Base;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Oportunidades.Builders;

namespace Voluntariese.Api.Aplicacao.Oportunidades.Requests
{
    public class AtualizarOportunidadeRequest : BaseRequest
    {
        public string Descricao { get; set; }
        public string Qualificacoes { get; set; }
        public CausaModel Causa { get; set; }
        public string Turno { get; set; }
        public int QuantidadeVagas { get; set; }
        public bool Ativa { get; set; }

        public ParametroAtualizacaoOportunidade ParaEntidade()
        {
            return new ParametroAtualizacaoOportunidadeBuilder()
                .ComDescricao(Descricao)
                .ComQualificacoes(Qualificacoes)
                .ComCausa(new Causa(Causa.Id, Causa.Descricao, Causa.Ativo))
                .ComTurno(Turno)
                .ComQuantidadeVagas(QuantidadeVagas)
                .ComAtiva(Ativa)
                .Construir();
        }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarErroCampoObrigatorio(nameof(Descricao));

            if (Causa == null)
                AdicionarErroCampoObrigatorio(nameof(Causa));

            if (string.IsNullOrEmpty(Turno))
                AdicionarErroCampoObrigatorio(nameof(Turno));
        }
    }
}