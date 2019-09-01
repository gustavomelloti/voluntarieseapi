using Voluntariese.Api.Aplicacao.Base;

namespace Voluntariese.Api.Aplicacao.Autenticacao.Requests
{
    public class SolicitarRecuperacaoSenhaRequest : BaseRequest
    {
        public string Email { get; set; }
        
        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarErroCampoObrigatorio(nameof(Email));
        }
    }
}
