using BookStore.Infrastructure.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class BookResponse
    {
        public Book? Book { get; set; }

        public List<ValidationFailure>? Errors { get; set; }
    }
}
