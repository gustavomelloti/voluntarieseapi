namespace Voluntariese.Api.Dominio.Causas
{
    public class Causa
    {
        public long Id { get; internal set; }
        public string Descricao { get; internal set; }
        public string Icone { get; internal set; }
        public bool Ativo { get; internal set; }

        public Causa() { }

        public Causa(long id, string descricao, bool ativo)
        {
            Id = id;
            Descricao = descricao;
            Ativo = ativo;
        }
    }
}
