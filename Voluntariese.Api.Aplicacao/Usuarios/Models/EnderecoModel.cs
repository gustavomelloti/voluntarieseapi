using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Enderecos.Builders;

namespace Voluntariese.Api.Aplicacao.Usuarios.Models
{
    public class EnderecoModel
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        
        public EnderecoModel() { }

        public EnderecoModel(Endereco endereco)
        {
            Id = endereco.Id;
            Cep = endereco.Cep;
            Estado = endereco.Estado;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
        }

        public Endereco ParaEntidade()
        {
            return new EnderecoBuilder()
                .ComCep(Cep)
                .ComEstado(Estado)
                .ComCidade(Cidade)
                .ComBairro(Bairro)
                .ComLogradouro(Logradouro)
                .ComComplemento(Complemento)
                .ComNumero(Numero)
                .Construir();
        }
    }
}
