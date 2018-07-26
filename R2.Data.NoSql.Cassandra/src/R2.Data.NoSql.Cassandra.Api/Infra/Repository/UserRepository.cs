using R2.Data.NoSql.Cassandra.Api.Cassandra;
using R2.Data.NoSql.Cassandra.Api.Domain.Interface;
using R2.Data.NoSql.Cassandra.Api.Domain.Model;

namespace R2.Data.NoSql.Cassandra.Api.Infra.Repository
{
    public class UserRepository : BaseCassandraRepository<User, Cassandra.Mapping>, IUserRepository
    {
        public UserRepository(Context<Mapping> context) : base(context)
        {
        }
    }
}
