namespace Voluntariese.Api.Aplicacao.Autenticacao.Models
{
    public class TokenAutenticacaoModel
    {
        public string Token { get; set; }
        public int ExpiraEm { get; set; }

        public TokenAutenticacaoModel(string token, int expiraEm)
        {
            Token = token;
            ExpiraEm = expiraEm;
        }
    }
}
