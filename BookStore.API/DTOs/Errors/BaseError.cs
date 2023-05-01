using BookStore.API.Constants;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.API.DTOs.Errors
{
    public class BaseError
    {
        public BaseError(ValidationFailure error)
        {
            this.PropertyName = error.PropertyName;
            this.ErrorMessage = error.ErrorMessage;
            this.AttemptedValue = error.AttemptedValue.ToString() ?? ResponseMessages.NoValueProvidedMessage;
        }

        public BaseError(KeyValuePair<string, ModelStateEntry?> pair, string attemptedValue)
        {
            string key = pair.Key.ToString();
            this.PropertyName = key.Equals("$") ? "Request body" : key;
            this.ErrorMessage = pair.Value is not null ? pair.Value.Errors[0].ErrorMessage : ResponseMessages.NoValueProvidedMessage;
            this.AttemptedValue = attemptedValue.ToString() ?? ResponseMessages.NoValueProvidedMessage;
        }

        public string PropertyName { get; init; }

        public string ErrorMessage { get; init; }

        public string AttemptedValue { get; init; }
    }
}
