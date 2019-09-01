using Voluntariese.Api.Aplicacao.Base;
using Voluntariese.Api.Infraestrutura.Utilitarios.Helpers;
using Voluntariese.Api.Repositorios.Contatos.Dtos;

namespace Voluntariese.Api.Aplicacao.Contatos.Requests
{
    public class CadastrarContatoRequest : BaseRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }

        public SalvarContatoDto ParaDto()
        {
            return new SalvarContatoDto(Nome, Email, Telefone, Mensagem);
        }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarErroCampoObrigatorio(nameof(Email));

            if (!string.IsNullOrEmpty(Email) && !EmailHelper.Validar(Email))
                AdicionarErroCampoInvalido(nameof(Email));

            if (string.IsNullOrEmpty(Telefone))
                AdicionarErroCampoObrigatorio(nameof(Telefone));

            if (string.IsNullOrEmpty(Mensagem))
                AdicionarErroCampoObrigatorio(nameof(Mensagem));

        }
    }
}
