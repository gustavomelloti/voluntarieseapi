using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public void Manipular(IApplicationBuilder app)
        {
            app.Run(
                async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = HttpStatusCode.InternalServerError;
                    object resposta = null;
                    switch (exception.Error)
                    {
                        case ErroValidacaoException _:
                            statusCode = HttpStatusCode.BadRequest;
                            resposta = ((ErroValidacaoException)exception.Error).Erros;
                            break;
                        case AcessoNegadoException _:
                            statusCode = HttpStatusCode.Unauthorized;
                            resposta = new[] { new ErroValidacao(exception.Error.Message) };
                            break;
                        default:
                            resposta = new[] { new ErroValidacao(exception.Error.Message) };
                            break;
                    }
                    context.Response.StatusCode = (int)statusCode;
                    await MiddlewareHelper.EscreverRespostaAsync(context, statusCode, resposta);
                }
            );
        }
    }
}
