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

        // Data Source=localhost;Initial Catalog=BOOK_STORE;User ID=sa;Password=***********
        // public string ConnectionString => $"Server={this.Host ?? string.Empty};Database={this.Database ?? string.Empty};User=sa;Password=S3cur3P@ssW0rd!;";
        public string ConnectionString => $"Data Source=bookstore-db;Initial Catalog=BOOK_STORE;User ID=sa;Password=S3cur3P@ssW0rd!;";
    }
}
