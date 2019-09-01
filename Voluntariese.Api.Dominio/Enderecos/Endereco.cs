
namespace Voluntariese.Api.Dominio.Enderecos
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Cep { get; internal set; }
        public string Estado { get; internal set; }
        public string Cidade { get; internal set; }
        public string Bairro { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Numero { get; internal set; }
        public string Complemento { get; internal set; }

        public void DefinirId(long id)
        {
            Id = id;
        }
    }
}
