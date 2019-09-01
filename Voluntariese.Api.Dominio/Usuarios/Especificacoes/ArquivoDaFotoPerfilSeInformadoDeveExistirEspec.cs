using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Especificacoes
{
    public class ArquivoDaFotoPerfilSeInformadoDeveExistirEspec : Especificacao<Usuario>
    {
        private readonly IRepositorioArquivo _repositorioArquivo;

        public ArquivoDaFotoPerfilSeInformadoDeveExistirEspec(IRepositorioArquivo repositorioArquivo)
        {
            _repositorioArquivo = repositorioArquivo;
        }

        public override bool EstaAtendidaPor(Usuario usuario)
        {
            if (!usuario.IdFotoPerfil.HasValue || usuario.IdFotoPerfil.Value == 0)
                return true;

            var arquivo = _repositorioArquivo.Obter(usuario.IdFotoPerfil.Value);

            return arquivo != null;
        }
    }
}
