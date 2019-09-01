namespace Voluntariese.Api.Dominio.Autenticacao
{
    public class HistoricoLogin
    {
        public long IdUsuario { get; }
        public string TokenAutenticacao { get; }
        public string EnderecoIp { get; }

        private HistoricoLogin() { }

        public HistoricoLogin(long idUsuario, string tokenAutenticacao, string enderecoIp)
        {
            IdUsuario = idUsuario;
            TokenAutenticacao = tokenAutenticacao;
            EnderecoIp = enderecoIp;
        }
    }
}
