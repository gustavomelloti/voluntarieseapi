namespace Voluntariese.Api.Dominio.Validacoes
{
    public class ErroValidacao
    {
        public string Codigo { get; }

        public string Mensagem { get; }

        public ErroValidacao(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public ErroValidacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
