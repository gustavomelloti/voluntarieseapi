namespace Voluntariese.Api.Dominio.Enderecos.Builders
{
    public class EnderecoBuilder
    {
        private readonly Endereco _endereco = new Endereco();

        public EnderecoBuilder APartir(Endereco endereco)
        {
            _endereco.Id = endereco.Id;
            _endereco.Cep = endereco.Cep;
            _endereco.Estado = endereco.Estado;
            _endereco.Cidade = endereco.Cidade;
            _endereco.Bairro = endereco.Bairro;
            _endereco.Logradouro = endereco.Logradouro;
            _endereco.Complemento = endereco.Complemento;
            _endereco.Numero = endereco.Numero;
            return this;
        }

        public EnderecoBuilder ComCep(string cep)
        {
            _endereco.Cep = cep;
            return this;
        }

        public EnderecoBuilder ComEstado(string estado)
        {
            _endereco.Estado = estado;
            return this;
        }

        public EnderecoBuilder ComCidade(string cidade)
        {
            _endereco.Cidade = cidade;
            return this;
        }

        public EnderecoBuilder ComBairro(string bairro)
        {
            _endereco.Bairro = bairro;
            return this;
        }

        public EnderecoBuilder ComLogradouro(string logradouro)
        {
            _endereco.Logradouro = logradouro;
            return this;
        }

        public EnderecoBuilder ComNumero(string numero)
        {
            _endereco.Numero = numero;
            return this;
        }

        public EnderecoBuilder ComComplemento(string complemento)
        {
            _endereco.Complemento = complemento;
            return this;
        }

        public Endereco Construir()
        {
            if (string.IsNullOrEmpty(_endereco.Cep))
                throw new EntidadeEmEstadoInvalidoException(nameof(_endereco.Cep));

            if (string.IsNullOrEmpty(_endereco.Estado))
                throw new EntidadeEmEstadoInvalidoException(nameof(_endereco.Estado));

            if (string.IsNullOrEmpty(_endereco.Cidade))
                throw new EntidadeEmEstadoInvalidoException(nameof(_endereco.Cidade));

            if (string.IsNullOrEmpty(_endereco.Bairro))
                throw new EntidadeEmEstadoInvalidoException(nameof(_endereco.Bairro));

            if (string.IsNullOrEmpty(_endereco.Logradouro))
                throw new EntidadeEmEstadoInvalidoException(nameof(_endereco.Logradouro));

            return _endereco;
        }
    }
}
