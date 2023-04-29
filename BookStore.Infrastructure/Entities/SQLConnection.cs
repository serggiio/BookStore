using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Entities
{
    public class SQLConnection
    {
        public string? Database { get; init; }

        public string? Host { get; init; }

        public string ConnectionString => $"Server={this.Host ?? string.Empty}\\SQLEXPRESS;Database={this.Database ?? string.Empty};Trusted_Connection=True;Encrypt=False";
    }
}
