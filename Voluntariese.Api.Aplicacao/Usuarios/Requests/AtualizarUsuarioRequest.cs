using System;
using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Base;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Enums;

namespace Voluntariese.Api.Aplicacao.Usuarios.Requests
{
    public class AtualizarUsuarioRequest : BaseRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Qualificacoes { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public long? IdFotoPerfil { get; set; }
        public EnderecoModel Endereco { get; set; }
        public IList<CausaModel> CausasInteresse { get; set; }

        public ParametroAtualizacaoUsuario ParaEntidade()
        {
            var causasInteresse = CausasInteresse != null
                ? CausasInteresse.Select(causa => new Causa(causa.Id, causa.Descricao, causa.Ativo)).ToList()
                : null;

            return new ParametroAtualizacaoUsuario()
                .ComNome(Nome)
                .ComQualificacoes(Qualificacoes)
                .ComDescricao(Descricao)
                .ComEmail(Email)
                .ComTelefone(Telefone)
                .ComDataNascimento(DataNascimento)
                .ComIdFotoPerfil(IdFotoPerfil)
                .ComSexo(Sexo)
                .ComCausasInteresse(causasInteresse)
                .ComEndereco(Endereco.ParaEntidade());
        }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarErroCampoObrigatorio(nameof(Nome));

            if (string.IsNullOrEmpty(Email))
                AdicionarErroCampoObrigatorio(nameof(Email));

            if (DateTime.MinValue == DataNascimento || DataNascimento > DateTime.Now)
                AdicionarErroCampoInvalido("Informe uma data válida e menor que a data atual.");

            if (string.IsNullOrEmpty(Endereco?.Cep))
                AdicionarErroCampoObrigatorio("Cep");

            if (string.IsNullOrEmpty(Endereco?.Estado))
                AdicionarErroCampoObrigatorio("Estado");

            if (string.IsNullOrEmpty(Endereco?.Cidade))
                AdicionarErroCampoObrigatorio("Cidade");

            if (string.IsNullOrEmpty(Endereco?.Bairro))
                AdicionarErroCampoObrigatorio("Bairro");

            if (string.IsNullOrEmpty(Endereco?.Logradouro))
                AdicionarErroCampoObrigatorio("Logradouro");

            if (string.IsNullOrEmpty(Endereco?.Numero))
                AdicionarErroCampoObrigatorio("Número");

            if (!string.IsNullOrEmpty(Nome) && Nome.Length > 100)
                AdicionarErroCampoInvalido("O nome deve ter no máximo 100 caracteres.");

            if (!string.IsNullOrEmpty(Email) && Email.Length > 50)
                AdicionarErroCampoInvalido("O nome deve ter no máximo 50 caracteres.");
        }
    }
}
