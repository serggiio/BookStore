using BookStore.Infrastructure.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            this.RuleFor(book => book.Title)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty.")
                .MinimumLength(3).WithMessage("'{PropertyName}' should have at least 3 characters.")
                .MaximumLength(50).WithMessage("'{PropertyName}' must not have more than {MaxLength} characters.");

            this.RuleFor(book => book.Pages)
                .GreaterThan(1).WithMessage("'{PropertyName}' must not be empty.");

            this.RuleFor(book => book.Description)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty.")
                .MaximumLength(150).WithMessage("'{PropertyName}' must not have more than {MaxLength} characters.");

            this.RuleFor(book => book.Publisher)
                .NotEmpty().WithMessage("'{PropertyName}' must not be empty.")
                .MaximumLength(50).WithMessage("'{PropertyName}' must not have more than {MaxLength} characters.");
        }
    }
}
