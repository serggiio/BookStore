using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Entities
{
    public class Book
    {
        public int Id { get; }

        public string? Title { get; set; }

        public int? Pages { get; set; }

        public string? Description { get; set; }

        public string? Publisher { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }
    }
}
