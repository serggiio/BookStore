using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class ServiceResult<TResult>
        where TResult : class
    {
        public TResult? Result { get; set; }

        public IEnumerable<ValidationFailure>? Errors { get; set; }

        public bool IsValid { get; set; }

        public static implicit operator ServiceResult<TResult>(TResult result) => new ServiceResult<TResult>
        {
            Result = result,
            IsValid = true,
        };

        public static implicit operator ServiceResult<TResult>(List<ValidationFailure> errors) => new ServiceResult<TResult>
        {
            Errors = errors,
            IsValid = false,
        };
    }
}
