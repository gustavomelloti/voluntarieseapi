using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Voluntariese.Api.Aplicacao.Autenticacao;
using Voluntariese.Api.Aplicacao.Autenticacao.Models;
using Voluntariese.Api.Aplicacao.Autenticacao.Requests;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.WebApi.Middlewares.Auth
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
            DispararExcecaoOpcoesInvalidas(_options);
        }

        public Task Invoke(HttpContext context)
        {
            if (!EhLogin(context))
            {
                return _next(context);
            }

            DispararExcecaoCasoRequisicaoInvalida(context);

            return AutenticarLogin(context);
        }

        private async Task GerarToken(HttpContext context, UsuarioModel usuario)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Role, usuario.Perfil.Codigo)
            };

            var jwt = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                now,
                now.Add(_options.Expiration),
                _options.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var tokenModel = new TokenAutenticacaoModel(token, (int)_options.Expiration.TotalSeconds);

            CriarHistoricoLogin(context, usuario, token);

            await MiddlewareHelper.EscreverRespostaAsync(context, HttpStatusCode.OK, tokenModel);
        }

        private async Task AutenticarLogin(HttpContext context)
        {
            var request = MiddlewareHelper.DeserializarRequest<LoginRequest>(context);

            var usuario = _options.IdentityResolver.Resolve(request, context);

            await GerarToken(context, usuario);
        }

        private static void DispararExcecaoOpcoesInvalidas(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
            }

            if (string.IsNullOrEmpty(options.Issuer))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
            }

            if (string.IsNullOrEmpty(options.Audience))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
            }

            if (options.Expiration == TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
            }

            if (options.IdentityResolver == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
            }

            if (options.NonceGenerator == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
            }
        }

        private static void DispararExcecaoCasoRequisicaoInvalida(HttpContext context)
        {
            if (!context.Request.Method.Equals("POST") ||
                !context.Request.ContentType.StartsWith("application/json") && !context.Request.ContentType.StartsWith("application/json-patch+json"))
            {
                throw new ErroValidacaoException("REQUISICAO_INVALIDA", "Requisição inválida.");
            }
        }

        private bool EhLogin(HttpContext context)
        {
            return context.Request.Path.Equals(_options.Path, StringComparison.Ordinal);
        }

        private static void CriarHistoricoLogin(HttpContext context, UsuarioModel usuario, string token)
        {
            context.RequestServices.GetService<IServicoAutenticacao>().CriarHistoricoLogin(usuario.Id, token,
                context.Request.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}
