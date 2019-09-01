using Voluntariese.Api.Aplicacao.Base;
using Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers;

namespace Voluntariese.Api.Aplicacao.Usuarios.Requests
{
    public class AtualizarSenhaRequest : BaseRequest
    {
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Senha))
                AdicionarErroCampoObrigatorio(nameof(Senha));

            if (string.IsNullOrEmpty(ConfirmacaoSenha))
                AdicionarErroCampoObrigatorio(nameof(ConfirmacaoSenha));
            
            if (Senha != ConfirmacaoSenha)
                AdicionarErroCampoInvalido("A senha e a confirmação não conferem.");

            if (!string.IsNullOrEmpty(Senha) && !SenhaHelper.Validar(Senha))
                AdicionarErroCampoInvalido("A senha deve ter pelo menos 6 caracteres, 1 letra, 1 número e um caracter especial.");
        }
    }
}
