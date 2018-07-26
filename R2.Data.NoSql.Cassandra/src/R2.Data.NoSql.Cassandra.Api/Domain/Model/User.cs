using System;

namespace R2.Data.NoSql.Cassandra.Api.Domain.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
