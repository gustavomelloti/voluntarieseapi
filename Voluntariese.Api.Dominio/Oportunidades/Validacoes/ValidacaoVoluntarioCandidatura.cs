using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;
using Voluntariese.Api.Dominio.Usuarios.Validacoes;
using Voluntariese.Api.Dominio.Oportunidades.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Validacoes
{
    public sealed class ValidacaoVoluntarioCandidatura : Validacao<Usuario>
    {
        public ValidacaoVoluntarioCandidatura(Oportunidade oportunidade)
        {
            AdicionarRegra(new UsuarioDeveEstarAtivoEspec(), "O usuário deve estar ativo", CodigosErro.UsuarioInativo);
            AdicionarRegra(new UsuarioNaoDeveTerSeCandidatadoAnteriormenteEspec(oportunidade), "Você já se candidatou nesta oportunidade.", CodigosErro.UsuarioJaSeCandidatou);
        }
    }
}
