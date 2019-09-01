using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Voluntariese.Api.WebApi.Config.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Voluntaria-se - API", Version = "v1" });
            });
            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                options.OperationFilter<FormFileOperationFilter>();
                options.IncludeXmlComments("XmlDocumentation.xml");
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "Voluntaria-se - API"); });
        }
    }
}
