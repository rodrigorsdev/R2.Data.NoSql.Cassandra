using Cassandra.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R2.Data.NoSql.Cassandra.Api.Domain.Interface
{
    public interface IBaseCassandraRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Executar(string commandText);
        void Executar(string commandText, object[] attributes);
        Task<AppliedInfo<TEntity>> Insert(TEntity entity);
        Task<AppliedInfo<TEntity>> Atualizar(string commandText, object[] attributes);
        Task<AppliedInfo<TEntity>> Excluir(string commandText, object[] attributes);
    }
}
