using Voluntariese.Api.Dominio.Doacoes.Especificacoes;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Doacoes.Validacoes
{
    public sealed class ValidacaoAtualizarDoacao : Validacao<Doacao>
    {
        public ValidacaoAtualizarDoacao(Usuario instituicao)
        {
            AdicionarRegra(new DoacaoDeveExistirEspec(), "Doação não encontrada.", CodigosErros.DoacaoNaoEncontrada, true);
            AdicionarRegra(new DoacaoDeveEstarVinculadaComInstituicaoEspec(instituicao), "Doação não está vinculada com sua instituição.", CodigosErros.DoacaoNaoEstaVinculadaComInstituicao);
        }
    }
}
