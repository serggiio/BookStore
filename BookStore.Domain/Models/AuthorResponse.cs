using BookStore.Infrastructure.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class AuthorResponse
    {
        public Author? Author { get; set; }

        public List<ValidationFailure>? Errors { get; set; }
    }
}
