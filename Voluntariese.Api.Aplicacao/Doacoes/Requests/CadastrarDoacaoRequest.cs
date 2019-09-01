using Voluntariese.Api.Aplicacao.Base;
using Voluntariese.Api.Dominio.Doacoes;

namespace Voluntariese.Api.Aplicacao.Doacoes.Requests
{
    public class CadastrarDoacaoRequest : BaseRequest
    {
        public string Descricao { get; set; }

        public Doacao ParaEntidade(long idInstituicao)
        {
            return new Doacao(Descricao, idInstituicao);
        }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarErroCampoObrigatorio(nameof(Descricao));
        }
    }
}
