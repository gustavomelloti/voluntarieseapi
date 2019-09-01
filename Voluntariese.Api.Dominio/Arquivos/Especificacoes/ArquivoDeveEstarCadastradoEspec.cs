using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Arquivos.Especificacoes
{
    public class ArquivoDeveEstarCadastradoEspec : Especificacao<Arquivo>
    {
        public override bool EstaAtendidaPor(Arquivo arquivo)
        {
            return arquivo != null && arquivo.Id != 0;
        }
    }
}
