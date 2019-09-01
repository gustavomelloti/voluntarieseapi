using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Aplicacao.Usuarios.Models
{
    public class PerfilUsuarioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        private PerfilUsuarioModel() { }

        public PerfilUsuarioModel(PerfilUsuario perfil)
        {
            Id = perfil.Id;
            Nome = perfil.Nome;
            Codigo = perfil.Codigo;
        }
    }
}
