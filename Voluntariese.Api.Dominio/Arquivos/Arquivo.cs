using System.IO;

namespace Voluntariese.Api.Dominio.Arquivos
{
    public class Arquivo
    {
        public long Id { get; private set; }
        public string Nome { get; }
        public string Endereco { get; private set; }
        public string Tipo { get; }
        public long Tamanho { get; }

        private Arquivo() { }

        public Arquivo(string nome, string endereco, string tipo, long tamanho)
        {
            Nome = nome;
            Endereco = endereco;
            Tipo = tipo;
            Tamanho = tamanho;
        }

        public Arquivo(long id, string nome, string endereco, string tipo, long tamanho)
            : this(nome, endereco, tipo, tamanho)
        {
            Id = id;
        }

        public void DefinirId(long id)
        {
            Id = id;
        }

        public void DefinirEnderecoCompleto(string enderecoAbsolutoUpload)
        {
            Endereco = Path.Combine(enderecoAbsolutoUpload, Endereco);
        }
    }
}
