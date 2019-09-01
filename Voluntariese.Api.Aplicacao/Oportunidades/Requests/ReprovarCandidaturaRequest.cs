using Voluntariese.Api.Aplicacao.Base;

namespace Voluntariese.Api.Aplicacao.Oportunidades.Requests
{
    public class ReprovarCandidaturaRequest : BaseRequest
    {
        public string Justificativa { get; set; }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Justificativa))
                AdicionarErroCampoObrigatorio(nameof(Justificativa));
        }
    }
}
