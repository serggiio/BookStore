using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Entities
{
    public class Author
    {
        public int Id { get; }

        public string? Name { get; init; }

        public string? Country { get; init; }

    }
}
