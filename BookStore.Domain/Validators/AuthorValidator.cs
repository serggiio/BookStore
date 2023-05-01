using BookStore.Infrastructure.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Validators
{
    internal class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator() 
        { 
            this.RuleFor(author => author.Name)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty.")
                .MaximumLength(50).WithMessage("'{PropertyName}' must contain at most {MaxLength} characters.");

            this.RuleFor(author => author.Country)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty.")
                .MaximumLength(50).WithMessage("'{PropertyName}' must contain at most {MaxLength} characters.");
        }
    }
}
