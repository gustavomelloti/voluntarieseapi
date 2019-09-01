namespace Voluntariese.Api.Repositorios.Contatos.Dtos
{
    public class SalvarContatoDto
    {
        public long Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Email { get; internal set; }
        public string Telefone { get; internal set; }
        public string Mensagem { get; internal set; }

        public SalvarContatoDto(string nome, string email, string telefone, string mensagem)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Mensagem = mensagem;
        }
    }
}
