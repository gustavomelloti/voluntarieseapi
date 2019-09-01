
using Voluntariese.Api.Aplicacao.Base;

namespace Voluntariese.Api.Aplicacao.Doacoes.Models
{
    public class AtualizarDoacaoRequest : BaseRequest
    {
        public string Descricao { get; set; }
        public bool Ativa { get; set; }
        

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarErroCampoObrigatorio(nameof(Descricao));
        }
    }
}
