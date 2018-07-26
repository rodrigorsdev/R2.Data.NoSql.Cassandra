using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.Options;

namespace R2.Data.NoSql.Cassandra.Api.Cassandra
{
    public class Context<TMap> where TMap : Mappings, new()
    {
        private readonly ISession _session;

        private readonly IMapper _mapper;

        public Context(IOptions<Settings> settings)
        {
            MappingConfiguration.Global.Define<TMap>();

            var cluster = Cluster.Builder().AddContactPoint(settings.Value.Ip).Build();
            _session = cluster.Connect(settings.Value.Keyspace);
            _mapper = new Mapper(_session);
        }

        public ISession Session => _session;

        public IMapper Mapper => _mapper;
    }
}
