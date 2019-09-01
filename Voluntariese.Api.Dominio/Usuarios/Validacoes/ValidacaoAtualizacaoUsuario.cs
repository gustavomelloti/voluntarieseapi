using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Validacoes
{
    public sealed class ValidacaoAtualizacaoUsuario : Validacao<Usuario>
    {
        public ValidacaoAtualizacaoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            AdicionarRegra(new UsuarioDeveEstarAtivoEspec(), "O usuário está inativo.", CodigosErro.UsuarioInativo);
            AdicionarRegra(new EmailNaoDeveEstarCadastradoParaOutroUsuarioEspec(repositorioUsuario), "O e-mail informado já está em uso.", CodigosErro.EmailEmUso);            
        }
    }
}
