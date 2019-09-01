using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voluntariese.Api.Infraestrutura.Arquivos;
using Voluntariese.Api.Infraestrutura.Cache;
using Voluntariese.Api.Infraestrutura.Email;
using Voluntariesepi.Api.Infraestrutura.Email.Envio;

namespace Voluntariese.Api.InjecaoDependencia
{
    public class InfraestruturaProvider
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IServicoCache, ServicoCache>();
            services.AddTransient<IEmailSender>(c => new SmtpSender(c.GetService<SmtpClient>(), configuration.GetSection("Email:Usuario").Value));
            services.AddTransient<IServicoEmail, ServicoEmail>();

            services.AddTransient<IFileManager>(
                c => new LocalFileManager(configuration.GetSection("Upload:Destino").Value));

            services.AddTransient<IEmailSender>(c => new SmtpSender(c.GetService<SmtpClient>(), configuration.GetSection("Email:Usuario").Value));
            services.AddTransient<IServicoEmail, ServicoEmail>(c => new ServicoEmail(c.GetService<IEmailSender>(), configuration.GetSection("Contato:Email").Value));

            services.AddTransient(c => new SmtpClient(configuration.GetSection("Email:Smtp").Value, 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(configuration.GetSection("Email:Usuario").Value,
                    configuration.GetSection("Email:Senha").Value),
                EnableSsl = Convert.ToBoolean(configuration.GetSection("Email:Ssl").Value),
                DeliveryMethod = SmtpDeliveryMethod.Network
            });
        }
    }
}
