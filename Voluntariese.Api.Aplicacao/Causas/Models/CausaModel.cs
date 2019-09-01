using Voluntariese.Api.Dominio.Causas;

namespace Voluntariese.Api.Aplicacao.Causas.Models
{
    public class CausaModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public bool Ativo { get; set; }

        public CausaModel() { }

        public CausaModel(Causa causa)
        {
            Id = causa.Id;
            Descricao = causa.Descricao;
            Icone = causa.Icone;
            Ativo = causa.Ativo;
        }
    }
}
