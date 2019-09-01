using Voluntariese.Api.Dominio.Arquivos;

namespace Voluntariese.Api.Aplicacao.Arquivos.Models
{
    public class ArquivoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Tipo { get; set; }
        public long Tamanho { get; set; }

        public ArquivoModel() { }

        public ArquivoModel(Arquivo arquivo)
        {
            Id = arquivo.Id;
            Nome = arquivo.Nome;
            Endereco = arquivo.Endereco;
            Tipo = arquivo.Tipo;
            Tamanho = arquivo.Tamanho;
        }

        public Arquivo ParaEntidade()
        {
            return new Arquivo(Id, Nome, Endereco, Tipo, Tamanho);
        }
    }
}
