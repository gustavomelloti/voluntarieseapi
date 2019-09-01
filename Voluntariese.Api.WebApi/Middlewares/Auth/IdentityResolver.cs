using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Voluntariese.Api.Aplicacao.Autenticacao;
using Voluntariese.Api.Aplicacao.Autenticacao.Requests;
using Voluntariese.Api.Aplicacao.Usuarios.Models;

namespace Voluntariese.Api.WebApi.Middlewares.Auth
{
    public class IdentityResolver
    {
        public UsuarioModel Resolve(LoginRequest request, HttpContext context)
        {
            return context.RequestServices.GetService<IServicoAutenticacao>().Login(request);
        }
    }
}
