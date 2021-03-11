using System.Collections.Generic;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Models;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class TicketsRepository : GenericRepository<Ticket>
    {
        protected override string TableName { get; } = "Tickets";

        protected override IList<string> ExcludedProperties { get; } = new List<string>
        {
            "CreationTime"
        };

        public TicketsRepository(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        {
        }
    }
}
