using Voluntariese.Api.Dominio.Arquivos.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Arquivos.Validacoes
{
    public sealed class ValidacaoConsultaArquivo : Validacao<Arquivo>
    {
        public ValidacaoConsultaArquivo()
        {
            AdicionarRegra(new ArquivoDeveEstarCadastradoEspec(), "O arquivo não foi encontrado.", CodigosErro.ArquivoNaoEncontrado);
        }
    }
}
