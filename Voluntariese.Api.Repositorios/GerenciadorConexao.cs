using System;
using System.Data;
using System.Data.SqlClient;
using Voluntariese.Api.Dominio;

namespace Voluntariese.Api.Repositorios
{
    public class GerenciadorConexao : IGerenciadorConexao, IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;

        public IDbTransaction TransacaoAtiva { get; private set; }

        public GerenciadorConexao(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void IniciarTransacao()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            TransacaoAtiva = _connection.BeginTransaction();
        }

        public IDbConnection ObterConexao()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void ExecutarCommit()
        {
            if (TransacaoAtiva == null)
            {
                throw new InvalidOperationException("A transação precisa estar aberta.");
            }
            TransacaoAtiva.Commit();
            TransacaoAtiva = null;
        }

        public void ExecutarRollback()
        {
            if (TransacaoAtiva == null)
            {
                throw new InvalidOperationException("A transação precisa estar aberta.");
            }
            TransacaoAtiva.Rollback();
            TransacaoAtiva = null;
        }

        public void Dispose()
        {
            TransacaoAtiva?.Dispose();
            _connection.Close();
        }
    }
}
