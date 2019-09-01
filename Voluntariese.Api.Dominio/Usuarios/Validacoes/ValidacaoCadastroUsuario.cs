using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Validacoes
{
    public sealed class ValidacaoCadastroUsuario : Validacao<Usuario>
    {
        public ValidacaoCadastroUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioArquivo repositorioArquivo)
        {
            AdicionarRegra(new EmailNaoDeveEstarCadastradoParaOutroUsuarioEspec(repositorioUsuario), "O e-mail informado já está em uso.", CodigosErro.EmailEmUso);
            AdicionarRegra(new ArquivoDaFotoPerfilSeInformadoDeveExistirEspec(repositorioArquivo), "O arquivo da foto de perfil não foi encontrado.", CodigosErro.ArquivoFotoPerfilNaoEncontrado); 
        }
    }
}
