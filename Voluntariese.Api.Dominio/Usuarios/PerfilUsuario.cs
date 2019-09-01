namespace Voluntariese.Api.Dominio.Usuarios
{
    public class PerfilUsuario
    {
        public const string Voluntario = "VOLUNTARIO";
        public const string Instituicao = "INSTITUICAO";

        public long Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Codigo { get; internal set; }

        private PerfilUsuario() { }

        public PerfilUsuario(long id)
        {
            Id = id;
        }
    }
}
