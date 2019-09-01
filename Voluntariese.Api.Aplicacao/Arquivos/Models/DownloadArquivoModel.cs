using Voluntariese.Api.Dominio.Arquivos;

namespace Voluntariese.Api.Aplicacao.Arquivos.Models
{
    public class DownloadArquivoModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public byte[] Conteudo { get; set; }
        public string Tipo { get; set; }

        public DownloadArquivoModel() { }

        public DownloadArquivoModel(Arquivo arquivo, byte[] conteudo)
        {
            Nome = arquivo.Nome;
            Tipo = arquivo.Tipo;
            Endereco = arquivo.Endereco;
            Conteudo = conteudo;
        }
    }
}
