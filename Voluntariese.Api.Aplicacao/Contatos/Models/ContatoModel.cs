using Voluntariese.Api.Repositorios.Contatos.Dtos;

namespace Voluntariese.Api.Aplicacao.Contatos.Models
{
    public class ContatoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }

        public ContatoModel(SalvarContatoDto dto)
        {
            Id = dto.Id;
            Nome = dto.Nome;
            Email = dto.Email;
            Telefone = dto.Telefone;
            Mensagem = dto.Mensagem;
        }
    }
}
