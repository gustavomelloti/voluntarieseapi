using Voluntariese.Api.Aplicacao.Base;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Oportunidades.Builders;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Aplicacao.Oportunidades.Requests
{
    public class CadastrarOportunidadeRequest : BaseRequest
    {
        public string Descricao { get; set; }
        public string Qualificacoes { get; set; }
        public CausaModel Causa { get; set; }
        public string Turno { get; set; }
        public int QuantidadeVagas { get; set; }

        public Oportunidade ParaEntidade(Usuario instituicao) 
        {
            return new OportunidadeBuilder()
                .ComDescricao(Descricao)
                .ComQualificacoes(Qualificacoes)
                .ComCausa(new Causa(Causa.Id, Causa.Descricao, Causa.Ativo))
                .ComTurno(Turno)
                .ComInstituicao(instituicao)
                .ComQuantidadeVagas(QuantidadeVagas)
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

            if (QuantidadeVagas <= 0)
                AdicionarErroCampoInvalido(nameof(QuantidadeVagas));
        }
    }
}