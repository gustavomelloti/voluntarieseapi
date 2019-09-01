using Voluntariese.Api.InjecaoDependencia;
using Voluntariese.Api.WebApi.Config.Swagger;
using Voluntariese.Api.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Voluntariese.Api.WebApi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });

            services.AddMemoryCache();

            SwaggerConfiguration.ConfigureServices(services);
            RepositoriosProvider.Configurar(services, Configuration);
            ServicosProvider.Configurar(services);
            InfraestruturaProvider.Configurar(services, Configuration);
            ConfigureAuthServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(cors =>
            {
                cors.AllowAnyHeader();
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
            });
            SwaggerConfiguration.Configure(app);

            app.UseExceptionHandler(a => new ExceptionHandlerMiddleware().Manipular(a));

            ConfigureAuth(app);
           
            app.UseMvc();
        }
    }
}
