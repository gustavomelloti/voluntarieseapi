using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace Voluntariese.Api.WebApi.Middlewares
{
    internal static class MiddlewareHelper
    {
        private const string ContentType = "application/json";

        internal static ConfiguredTaskAwaitable EscreverRespostaAsync(HttpContext context, HttpStatusCode statusCode,
            object modelo)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = ContentType;

            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var modeloSerializado = SerializarResposta(modelo);
            return context.Response.WriteAsync(modeloSerializado).ConfigureAwait(false);
        }

        internal static TRequest DeserializarRequest<TRequest>(HttpContext context)
        {
            context.Request.EnableRewind();
            return JsonConvert.DeserializeObject<TRequest>(new StreamReader(context.Request.Body).ReadToEnd());
        }

        private static string SerializarResposta(object modelo)
        {
            return JsonConvert.SerializeObject(modelo, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
