using Cassandra.Mapping;
using R2.Data.NoSql.Cassandra.Api.Cassandra;
using R2.Data.NoSql.Cassandra.Api.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R2.Data.NoSql.Cassandra.Api.Infra.Repository
{
    public class BaseCassandraRepository<TEntity, TMap> : IBaseCassandraRepository<TEntity> where TEntity : class where TMap : Mappings, new()
    {
        private readonly Cassandra.Context<Mapping> _context;

        public BaseCassandraRepository(Cassandra.Context<Mapping> context)
        {
            _context = context;
        }

        public Task<IEnumerable<TEntity>> Executar(string commandText)
        {
            return _context.Mapper.FetchAsync<TEntity>(commandText);
        }

        public async void Executar(string commandText, object[] attributes)
        {
            var stm = _context.Session.Prepare(commandText);
            var result = await _context.Session.ExecuteAsync(stm.Bind(attributes));
        }

        public Task<AppliedInfo<TEntity>> Insert(TEntity entity)
        {
            return _context.Mapper.InsertIfNotExistsAsync(entity);
        }

        public Task<AppliedInfo<TEntity>> Atualizar(string commandText, object[] attributes)
        {
            return _context.Mapper.UpdateIfAsync<TEntity>(commandText, attributes);
        }

        public Task<AppliedInfo<TEntity>> Excluir(string commandText, object[] attributes)
        {
            return _context.Mapper.DeleteIfAsync<TEntity>(commandText, attributes);
        }
    }
}
