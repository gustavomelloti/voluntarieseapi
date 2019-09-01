using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Aplicacao.Usuarios.Requests;
using Voluntariese.Api.Dominio;
using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using Voluntariese.Api.Dominio.Enderecos.Interfaces;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Dominio.Usuarios.Validacoes;
using Voluntariese.Api.Infraestrutura.Email;
using Voluntariesepi.Infraestrutura.Criptografia;

namespace Voluntariese.Api.Aplicacao.Usuarios
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioEndereco _repositorioEndereco;
        private readonly IRepositorioArquivo _repositorioArquivo;
        private readonly IRepositorioUsuarioCausa _repositorioUsuarioCausa;
        private readonly IServicoEmail _servicoEmail;
        private readonly IUnitOfWork _unitOfWork;

        public ServicoUsuario(
            IRepositorioUsuario repositorioUsuario,
            IRepositorioEndereco repositorioEndereco,
            IServicoEmail servicoEmail,
            IRepositorioArquivo repositorioArquivo,
            IRepositorioUsuarioCausa repositorioUsuarioCausa,
            IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicoEmail = servicoEmail;
            _unitOfWork = unitOfWork;
            _repositorioArquivo = repositorioArquivo;
            _repositorioEndereco = repositorioEndereco;
            _repositorioUsuarioCausa = repositorioUsuarioCausa;
        }

        public UsuarioModel Cadastrar(CadastrarUsuarioRequest request)
        {
            request.Validar();

            var senha = CriptografiaSha512.GerarHash(request.Senha);
            var perfilUsuario = _repositorioUsuario.ObterPerfil(request.Tipo);
            var usuario = request.ParaEntidade(senha, perfilUsuario);
            new ValidacaoCadastroUsuario(_repositorioUsuario, _repositorioArquivo).Validar(usuario);

            _unitOfWork.IniciarTransacao();

            _repositorioEndereco.Inserir(usuario.Endereco);
            _repositorioUsuario.Inserir(usuario);
            _repositorioUsuarioCausa.Inserir(usuario);

            _unitOfWork.ExecutarCommit();

            return new UsuarioModel(usuario);
        }

        public UsuarioModel Atualizar(AtualizarUsuarioRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var usuario = _repositorioUsuario.Obter(idUsuarioAutenticado);

            usuario.Atualizar(request.ParaEntidade());
            new ValidacaoAtualizacaoUsuario(_repositorioUsuario).Validar(usuario);

            _unitOfWork.IniciarTransacao();

            _repositorioEndereco.Inserir(usuario.Endereco);
            _repositorioUsuario.Atualizar(usuario);
            _repositorioUsuarioCausa.Atualizar(usuario);

            _unitOfWork.ExecutarCommit();

            return new UsuarioModel(usuario);
        }

        public async Task AtualizarSenha(AtualizarSenhaRequest request, long idUsuarioAutenticado)
        {
            request.Validar();

            var usuario = _repositorioUsuario.Obter(idUsuarioAutenticado);
            var novaSenha = CriptografiaSha512.GerarHash(request.Senha);

            new ValidacaoAtualizacaoSenhaUsuario(novaSenha).Validar(usuario);
            usuario.AtualizarSenha(novaSenha);

            _repositorioUsuario.AtualizarSenha(usuario);
            await _servicoEmail.EnviarEmailAtualizacaoSenha(usuario);
        }

        public IList<UsuarioModel> ConsultarVoluntarios(long? idCausa)
        {
            var voluntarios = _repositorioUsuario.ConsultarVoluntarios(idCausa);
            return voluntarios.Select(voluntario => new UsuarioModel(voluntario)).ToList();
        }
    }
}
