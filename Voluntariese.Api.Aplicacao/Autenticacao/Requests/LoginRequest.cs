using Voluntariese.Api.Aplicacao.Base;

namespace Voluntariese.Api.Aplicacao.Autenticacao.Requests
{
    public class LoginRequest : BaseRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Email))
            {
                AdicionarErroCampoObrigatorio(nameof(Email));
            }
            if (string.IsNullOrEmpty(Senha))
            {
                AdicionarErroCampoObrigatorio(nameof(Senha));
            }
        }
    }
}
