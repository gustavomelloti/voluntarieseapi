using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voluntariese.Api.Dominio;
using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using Voluntariese.Api.Dominio.Autenticacao.Interfaces;
using Voluntariese.Api.Dominio.Causas.Interfaces;
using Voluntariese.Api.Dominio.Doacoes.Interfaces;
using Voluntariese.Api.Dominio.Enderecos.Interfaces;
using Voluntariese.Api.Dominio.Oportunidades.Interfaces;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Repositorios;
using Voluntariese.Api.Repositorios.Arquivos;
using Voluntariese.Api.Repositorios.Autenticacao;
using Voluntariese.Api.Repositorios.Causas;
using Voluntariese.Api.Repositorios.Contatos;
using Voluntariese.Api.Repositorios.Doacoes;
using Voluntariese.Api.Repositorios.Enderecos;
using Voluntariese.Api.Repositorios.Oportunidades;
using Voluntariese.Api.Repositorios.Usuarios;

namespace Voluntariese.Api.InjecaoDependencia
{
    public static class RepositoriosProvider
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider => new GerenciadorConexao(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<GerenciadorConexao>());
            services.AddScoped<IGerenciadorConexao>(serviceProvider =>
                serviceProvider.GetService<GerenciadorConexao>());

            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioTokenRecuperacaoSenha, RepositorioTokenRecuperacaoSenha>();
            services.AddTransient<IRepositorioHistoricoLogin, RepositorioHistoricoLogin>();
            services.AddTransient<IRepositorioArquivo, RepositorioArquivo>();
            services.AddTransient<IRepositorioEndereco, RepositorioEndereco>();
            services.AddTransient<IRepositorioContato, RepositorioContato>();
            services.AddTransient<IRepositorioCausa, RepositorioCausa>();
            services.AddTransient<IRepositorioOportunidade, RepositorioOportunidade>();
            services.AddTransient<IRepositorioOportunidadeCandidatura, RepositorioOportunidadeCandidatura>();
            services.AddTransient<IRepositorioDoacao, RepositorioDoacao>();
            services.AddTransient<IRepositorioUsuarioCausa, RepositorioUsuarioCausa>();
        }
    }
}
