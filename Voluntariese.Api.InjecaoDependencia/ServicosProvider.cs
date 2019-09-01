using Microsoft.Extensions.DependencyInjection;
using Voluntariese.Api.Aplicacao.Arquivos;
using Voluntariese.Api.Aplicacao.Autenticacao;
using Voluntariese.Api.Aplicacao.Causas;
using Voluntariese.Api.Aplicacao.Contatos;
using Voluntariese.Api.Aplicacao.Doacoes;
using Voluntariese.Api.Aplicacao.Oportunidades;
using Voluntariese.Api.Aplicacao.Usuarios;

namespace Voluntariese.Api.InjecaoDependencia
{
    public static class ServicosProvider
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddTransient<IServicoAutenticacao, ServicoAutenticacao>();
            services.AddTransient<IServicoUsuario, ServicoUsuario>();
            services.AddTransient<IServicoArquivo, ServicoArquivo>();
            services.AddTransient<IServicoContato, ServicoContato>();
            services.AddTransient<IServicoCausa, ServicoCausa>();
            services.AddTransient<IServicoOportunidade, ServicoOportunidade>();
            services.AddTransient<IServicoDoacao, ServicoDoacao>();
        }
    }
}
