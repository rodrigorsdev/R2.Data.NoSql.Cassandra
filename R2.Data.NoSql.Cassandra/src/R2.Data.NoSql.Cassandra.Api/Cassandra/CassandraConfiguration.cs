using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace R2.Data.NoSql.Cassandra.Api.Cassandra
{
    public static class CassandraConfiguration
    {
        public static void AddCassandra(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.Configure<Settings>(options =>
            {
                options.Ip = configuration.GetSection("CassandraConnection:Ip").Value;
                options.Keyspace = configuration.GetSection("CassandraConnection:Keyspace").Value;
            });
        }
    }
}
