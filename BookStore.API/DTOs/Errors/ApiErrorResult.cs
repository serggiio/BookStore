using BookStore.API.Constants;
using BookStore.API.DTOs.ApiResult;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.API.DTOs.Errors
{
    public class ApiErrorResult : ApiCommonResult
    {
        public ApiErrorResult(IEnumerable<BaseError> errors, string message)
            : base(false, message)
        {
            this.Errors = errors;
        }

        public ApiErrorResult(ModelStateDictionary modelState, string bodyString)
           : base(false, ResponseMessages.RequestError)
        {
            this.Errors = modelState.Select(x => new BaseError(x, bodyString)).ToList();
        }

        public IEnumerable<BaseError>? Errors { get; init; }
    }
}
